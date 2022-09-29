

namespace Vision.GUI
{
    using System.Windows.Forms;
    using System.ComponentModel;
    using Vision.Services.AudioService;
    using Vision.Services.ComputationServices;
    using Vision.Services.VideoService;

    public partial class VisionForm : Form
    {
        #region Instances
        private Boolean _securityEnabled;
        private VideoFeed _videoFeed;
        private TextToSpeech _textToSpeech;
        private ImageProcessor _imageProcessor;
        private SpeechRecognition _speechRecognition;
       

        #endregion

        public VisionForm()
        {
            _securityEnabled = false;
            _videoFeed = new VideoFeed();
            _textToSpeech = new TextToSpeech();
            _imageProcessor = new ImageProcessor();
            _speechRecognition = new SpeechRecognition();

            InitializeComponent();
            this.Load += VisionForm_Load;
        }

        #region Surveillance Methods
        private void OpenVideoSurveillance()
        {
            var feed = _videoFeed.GetCurrentImageFrame();
            if (feed != null)
            {
                _imageProcessor.ShowDetectedHeadAndShoulders(feed);
                MonitorThreshold();
            }
        }

        private void MonitorThreshold()
        {
            var distance = ProximityEstimater.GetEstimatedProximityDistance();

            if (distance > 0 && distance < 90)
            {
                Console.Beep();
                ShowAlarm( intruderDetected : true);
                _ = _textToSpeech.SpeakAsync(Vocabulary.GetPromptMessage("Security: Alert"));
            }
            else
            {
                ShowAlarm(intruderDetected: false);
            }
        }
        #endregion

        #region Event Handler Methods
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!_securityEnabled)
            {
                EnableSecurity();
            }
            else
            {
                DisableSecurity();
            }
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Initialization Methods
        private void VisionForm_Load(object? sender, EventArgs e)
        {
            SurveillanceWorker.RunWorkerAsync();
            _speechRecognition.SetCommandAction(this.ProccessCommands);
        }
        #endregion

        #region Background Worker Methods
        private void SurveillanceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!SurveillanceWorker.CancellationPending && _securityEnabled)
            {
                OpenVideoSurveillance();
            }

        }
        private void SurveillanceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SurveillanceWorker.RunWorkerAsync();
        }
        #endregion

        
        #region Helper Methods
        private void EnableSecurity()
        {
            _securityEnabled = true;
            this.CloseButton.Hide();
            this.StartButton.BackgroundImage = Properties.Resources.stop;

            _videoFeed.OpenCamera();
            _speechRecognition.StartCommandRecognizer();
            _ = _textToSpeech.SpeakAsync(Vocabulary.GetPromptMessage("Security: Launch"));
            
        }
        private void DisableSecurity()
        {
            _securityEnabled = false;
            this.CloseButton.Show();
            this.StartButton.BackgroundImage = Properties.Resources.start_button;

            _videoFeed.CloseCamera();
            _speechRecognition.StopCommandRecognizer();
            _textToSpeech.Speak(Vocabulary.GetPromptMessage("Security: Terminate"));

        }
        private void ShowAlarm(bool intruderDetected)
        {
            if (intruderDetected)
            {
                Invoke((MethodInvoker)(() =>
                {
                    this.AlarmPicturebox.Show();
                }));
            }
            else
            {
                Invoke((MethodInvoker)(() =>
                {
                    this.AlarmPicturebox.Hide();
                }));
            }
        }
        private void ProccessCommands(string userInput)
        {
            if (Vocabulary.GetCommands("Security: StandDown").Contains(userInput))
            {
                DisableSecurity();
            }
        }
        #endregion

    }
}
