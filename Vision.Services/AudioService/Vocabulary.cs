namespace Vision.Services.AudioService
{
    public static class Vocabulary
    {
        #region Data fields
        private readonly static Dictionary<string, string> _promptMessages = new Dictionary<string, string>(){
            {
                "Security: Alert",
                    "Intruder please step away from the computer!"
            },
            {
                "Security: Launch",
                    "Vision security system engaged!"
            },
            {
                "Security: Terminate",
                    "Surveillance down, Vision security system terminated!"
            }
        };

        private readonly static Dictionary<string, string[]> _commands = new Dictionary<string, string[]>()
        {
            {
                "Security: StandDown",
                    new string[]{
                        "Vision Terminate Security System Now"
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
