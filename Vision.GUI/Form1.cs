namespace Vision.GUI
{
    using System.ComponentModel;
    using System.Diagnostics;
    using Vision.Services.ComputationServices;
    using Vision.Services.VideoService;

    public partial class Form1 : Form
    {
        #region Instances
        private VideoFeed _videoFeed;
        private Boolean _shouldDisplayFeed;
        private ImageProcessor _imageProcessor;
        #endregion

        public Form1()
        {
            _videoFeed = new VideoFeed();
            _shouldDisplayFeed = true;
            _imageProcessor = new ImageProcessor();

            InitializeComponent();
            this.Load += Form1_Load;
        }

        
        #region Display Methods
        private void DisplayFeed()
        {
            var feed = _videoFeed.GetCurrentImageFrame();
            if (feed != null)
            {
                _imageProcessor.ShowDetectedHeadAndShoulders(feed);

                Debug.WriteLine(ProximityEstimater.GetEstimatedDistance());
                if (_shouldDisplayFeed)
                {
                    pictureBox1.BackgroundImage = _imageProcessor.ConvertBgrImageToBitMap(feed);
                }
            }
        }
        
        public void DisplayDefualtBg()
        {
            /*pictureBox1.BackgroundImage = Properties.Resources.face_recognition;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;*/
        }
        
        public void ClearFeedDisplay()
        {
            _imageProcessor.ChangeBorderColor(1);
            DisplayDefualtBg();
        }

        #endregion

        #region Background Worker Methods
        private void videoBgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!videoBgWorker.CancellationPending)
            {
                DisplayFeed();
            }
        }

        private void videoBgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            videoBgWorker.RunWorkerAsync();
        }
        #endregion

        #region Event Handler Methods
        private void Form1_Load(object? sender, EventArgs e)
        {
            InitializeVideoFeed();
            videoBgWorker.RunWorkerAsync();
        }
        private void InitializeVideoFeed()
        {
            _videoFeed.SetDimension(
               width: pictureBox1.Width,
               hieght: pictureBox1.Height
            );

            _videoFeed.OpenCamera();
        }
        #endregion
    }
}