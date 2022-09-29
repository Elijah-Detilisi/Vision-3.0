#pragma warning disable CA1416 // Validate platform compatibility

namespace Vision.Services.AudioService
{
    using System.Diagnostics;
    using System.Globalization;
    using System.Speech.Recognition;

    public class SpeechRecognition
    {
        #region Instances
        private Action<string> _controlAction;
        private Action<string> _commandAction;
        private CultureInfo _recognizerDialact;

        private readonly SpeechRecognitionEngine _commandRecognizer;

        #endregion

        public SpeechRecognition()
        {
            _controlAction = Console.WriteLine;
            _commandAction = Console.WriteLine;

            _recognizerDialact = new CultureInfo("en-GB");
            _commandRecognizer = new SpeechRecognitionEngine(_recognizerDialact);

            initializeRecognizer();
        }

        #region Setter methods
        public void SetCommandAction(Action<string> action)
        {
            _commandAction = action;
        }
        #endregion

        #region Recognizer Launching
        public void StartCommandRecognizer()
        {
            _commandRecognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
        public void StopCommandRecognizer()
        {
            _commandRecognizer.RecognizeAsyncStop();
        }
        #endregion

        #region Recognizer Initialization
        private void LoadSystemVocabulary()
        {
            //Get commands
            var controlCommands = Vocabulary.GetCommands("Security: StandDown");
            var controlChoices = new Choices(controlCommands);
            var controlGrammarBuilder = new GrammarBuilder();

            //Get grammer
            controlGrammarBuilder.Append(controlChoices);
            var controlGrammar = new Grammar(controlGrammarBuilder);

            //Load Grammar
            _commandRecognizer.LoadGrammar(controlGrammar);

        }
        private void initializeRecognizer()
        {
            LoadSystemVocabulary();
            _commandRecognizer.SetInputToDefaultAudioDevice();

            //Speech event Handlers
            _commandRecognizer.SpeechRecognized +=
                new EventHandler<SpeechRecognizedEventArgs>(CommandSpeechRecognized);
        }
        #endregion

        #region Recognizer Event Handlers
        private void CommandSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var textResult = e.Result.Text;
            _commandAction(textResult);

            Debug.WriteLine("Command recognizer: " + textResult);
        }
        #endregion
    }
}

#pragma warning restore CA1416 // Validate platform compatibility