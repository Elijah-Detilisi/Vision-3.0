
namespace Vision.Services.VideoService
{
    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;
    using System.Diagnostics;

    public class VideoFeed
    {

        #region Instances
        private Mat _captureFrame;
        private VideoCapture _videoCapture;
        private Dimensions _imageDimensions;
        private Image<Bgr, byte> _curretImageFrame;
        #endregion

        public VideoFeed()
        {
            _videoCapture = new VideoCapture();
            _imageDimensions = new Dimensions();
            _captureFrame = new Mat();

            SetDimension(400, 400);
        }

        #region Setter and Getter Methods
        public void SetDimension(int width, int hieght)
        {
            _imageDimensions.width = width;
            _imageDimensions.height = hieght;
        }

        public Image<Bgr, byte>? GetCurrentImageFrame()
        {
            if (_curretImageFrame != null)
            {
                return _curretImageFrame;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Camera Control Methods
        public void OpenCamera()
        {
            Debug.WriteLine("[INFO]: Opening camera...");

            if (_videoCapture.IsOpened)
            {
                _videoCapture.ImageGrabbed += _videoCapture_ImageGrabbed;
                _videoCapture.Start();
            }
        }
        public void CloseCamera()
        {
            Debug.WriteLine("[INFO]: Closing camera...");
            Task.Factory.StartNew(() =>
            {
                _videoCapture.Stop();
                _videoCapture.Dispose();
                _videoCapture = new VideoCapture();
            });
        }
        #endregion

        #region Video Handler Methods
        private void _videoCapture_ImageGrabbed(object? sender, EventArgs e)
        {
            int cameraIndex = 0;
            _videoCapture.Retrieve(_captureFrame, cameraIndex);
            _curretImageFrame = _captureFrame.ToImage<Bgr, Byte>().Resize(
                _imageDimensions.width,
                _imageDimensions.height,
                Inter.Cubic
            );
        }
        #endregion

        #region Helper Entities
        private struct Dimensions
        {
            public int width;
            public int height;
        }
        #endregion

    }
}
