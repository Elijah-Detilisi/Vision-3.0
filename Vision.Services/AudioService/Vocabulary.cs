namespace Vision.Services.AudioService
{
    public static class Vocabulary
    {
        #region Data fields
        private readonly static Dictionary<string, string> _promptMessages = new Dictionary<string, string>(){
            {
                "Security: Alert",
                    "Intruder alert please step away from the computer!"
            },
            {
                "Security: Launch",
                    "Vision security system engaged!"
            }
        };

        private readonly static Dictionary<string, string[]> _commands = new Dictionary<string, string[]>()
        {
            {
                "Security: Engage",
                    new string[]{
                        "Engage vision", "Launch vision"
                    }
            }
        };
        #endregion

        #region Class methods
        public static string GetPromptMessage(string promptKey)
        {
            string message = _promptMessages[promptKey];

            return message;
        }

        public static string[] GetCommands(string commandKey)
        {
            var commands = _commands[commandKey];
            return commands;
        }
        #endregion

    }
}
