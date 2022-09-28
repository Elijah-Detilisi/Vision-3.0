namespace Vision.GUI
{
    using System.Diagnostics;
    using System.ComponentModel;
    using Vision.Services.VideoService;
    using Vision.Services.AudioService;
    using Vision.Services.ComputationServices;
    
    public partial class Form1 : Form
    {
        #region Instances
        private VideoFeed _videoFeed;
        private Boolean _shouldDisplayFeed;
        private TextToSpeech _textToSpeech;
        private ImageProcessor _imageProcessor;
        
        #endregion

        public Form1()
        {
            _videoFeed = new VideoFeed();
            _shouldDisplayFeed = true;
            _textToSpeech = new TextToSpeech();
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

                MonitorThreshold();

                if (_shouldDisplayFeed)
                {
                    pictureBox1.BackgroundImage = _imageProcessor.ConvertBgrImageToBitMap(feed);
                }
            }
        }
        
        private void MonitorThreshold()
        {
            var distance = ProximityEstimater.GetEstimatedProximityDistance();
            
            if (distance>0 && distance <90)
            {
                Console.Beep();
                _textToSpeech.SpeakAsync(Vocabulary.GetPromptMessage("Security: Alert"));
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

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}