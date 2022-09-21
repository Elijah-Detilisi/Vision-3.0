
namespace Vision.Services.VideoService
{
    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;
    using System.Diagnostics;
    using System.Drawing;
    using Vision.Services.ComputationServices;

    public class ImageProcessor
    {
        #region Instances
        private Bgr _borderColor;
        private Rectangle[] _detectedFaces;
        private Rectangle[] _detectedBodies;
        private readonly string _cascadePath;
        private readonly CascadeClassifier _faceCascade;
        private readonly CascadeClassifier _upperBodyCascade;
        #endregion

        public ImageProcessor()
        {
            _detectedFaces = new Rectangle[3];
            _detectedBodies = new Rectangle[3];
            _borderColor = new Bgr(Color.SteelBlue);
            _cascadePath = Directory.GetCurrentDirectory() + @"\VideoService\Haarcascades\";
            _upperBodyCascade = new CascadeClassifier(_cascadePath + "haarcascade_upperbody.xml");
            _faceCascade = new CascadeClassifier(_cascadePath + "haarcascade_frontalface_default.xml");
            
        }

        #region Setter and Getter Methods
        public void ChangeBorderColor(int state)
        {
            if (state == 1)
            {
                _borderColor = new Bgr(Color.SteelBlue);
            }
            else
            {
                _borderColor = new Bgr(Color.Tomato);
            }
        }
        #endregion

        #region Graphics Altering Methods
        public Mat? ConvertBgr2Gray(Image<Bgr, byte>? imageFrame)
        {
            try
            {
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(imageFrame, grayImage, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(grayImage, grayImage);
                return grayImage;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[INFO]: Error in ImageProssesor.ConvertBgr2Gray(): " + ex.Message);
                return null;
            }
        }
        public Bitmap ConvertBgrImageToBitMap(Image<Bgr, byte>? imageFrame)
        {
            return imageFrame.ToBitmap();
        }
        #endregion

        #region Face and Body Detection Methods
        private void DetectFacesAndBodiesFromImage(Image<Bgr, Byte> imageFrame)
        {
            try
            {
                Mat grayImage = ConvertBgr2Gray(imageFrame);
                //Detect faces
                _detectedFaces = _faceCascade.DetectMultiScale(
                    image: grayImage,
                    scaleFactor: 1.1,
                    minNeighbors: 3,
                    minSize: Size.Empty,
                    maxSize: Size.Empty
                );
                //Detect bodies
                _detectedBodies = _upperBodyCascade.DetectMultiScale(
                    image: grayImage,
                    scaleFactor: 1.1,
                    minNeighbors: 3,
                    minSize: Size.Empty,
                    maxSize: Size.Empty
                );
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[INFO]: Error in ImageProssesor.DetectFacesAndBodiesFromImage(): " + ex.Message);
            }
        }

        public void ShowDetectedHeadAndShoulders(Image<Bgr, Byte> imageFrame)
        {
            double faceWidth = 0.0;
            double bodyWidth = 0.0;

            DetectFacesAndBodiesFromImage(imageFrame);
            
            //show detected faces
            if (_detectedFaces != null && _detectedFaces.Length > 0)
            {
                foreach (var face in _detectedFaces.Concat(_detectedBodies))
                {
                    faceWidth = face.Width;

                    CvInvoke.Rectangle(
                        img: imageFrame,
                        rect: face,
                        color: _borderColor.MCvScalar,
                        thickness: 3
                    );
                }
            }

            //show detected bodies
            if (_detectedBodies != null && _detectedBodies.Length > 0)
            {
                foreach (var body in _detectedBodies)
                {
                    bodyWidth = body.Width;

                    CvInvoke.Rectangle(
                        img: imageFrame,
                        rect: body,
                        color: _borderColor.MCvScalar,
                        thickness: 3
                    );
                }
            }

            ProximityEstimater.SetDetectedFaceAndBodyWidth(faceWidth, bodyWidth);
        }
        #endregion

    }
}
