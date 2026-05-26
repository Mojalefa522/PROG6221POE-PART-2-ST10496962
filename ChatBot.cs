using System;

namespace PROG6221POE_PART_2_ST10496962
{
    public class ChatBot
    {
        private string userName;

        public ChatBot(string name)
        {
            userName = name;
        }

        public string GetResponse(string input)
        {
            string choice = NormalizeChoice(input);
            return HandleChoice(choice);
        }

        private string NormalizeChoice(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";

            input = input.Trim().ToLower();

            if (input == "1" || input.Contains("password"))
                return "1";
            else if (input == "2" || input.Contains("phishing") || input.Contains("scam"))
                return "2";
            else if (input == "3" || input.Contains("safe browsing") || input.Contains("safe"))
                return "3";
            else if (input == "4" || input.Contains("how are you"))
                return "4";
            else if (input == "0" || input.Contains("exit") || input.Contains("quit") || input.Contains("close"))
                return "0";

            return input;
        }

        private string HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    return $"{userName}, strong passwords should include letters, numbers, and symbols.";

                case "2":
                    return $"{userName}, phishing scams try to trick you into revealing personal information.";

                case "3":
                    return $"{userName}, always check for HTTPS when entering sensitive information online. It appears at the top of the search bar before the website name.";

                case "4":
                    return $"I'm doing great, {userName}! Feel free to ask any more questions about online safety. I can give you tips on avoiding phishing traps, making strong passwords, and checking if a website is safe.";

                case "0":
                    return $"Goodbye, {userName}! Stay safe online.";

                default:
                    return $"{userName}, I didn't understand that option. Try typing a number (1-4) or a topic name (password, phishing, safe browsing). Type 0 to exit.";
            }
        }
    }
}
