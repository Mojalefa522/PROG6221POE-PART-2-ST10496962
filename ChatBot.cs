using System;
using System.Collections.Generic;

namespace PROG6221POE_PART_2_ST10496962
{
    public class ChatBot
    {
        private string userName;
        private Random random = new Random();
        private string lastTopic = "";
        private Dictionary<string, string> userMemory = new Dictionary<string, string>();

        public delegate string SentimentModifier(string botResponse, string sentiment);
        public SentimentModifier ModifyBySentiment;

        public string LastSentiment { get; private set; } = "neutral";

        public ChatBot(string name)
        {
            userName = name;
            ModifyBySentiment = ApplySentimentAdjustment;
            userMemory["name"] = name;
        }

        private string[] passwordTips = new string[]
        {
            "{0}, strong passwords should include letters, numbers, and symbols.",
            "{0}, never use the same password for multiple accounts.",
            "{0}, a good password is at least 12 characters long.",
            "{0}, use a passphrase like 'PurpleDinosaur$42!' instead of a single word.",
            "{0}, enable two-factor authentication whenever possible."
        };

        private string[] phishingTips = new string[]
        {
            "{0}, phishing scams try to trick you into revealing personal information.",
            "{0}, always check the sender's email address before clicking links.",
            "{0}, hover over links to see where they really go before clicking.",
            "{0}, never share personal info via email - legitimate companies won't ask for it.",
            "{0}, if an email creates urgency ('act now!'), it's likely a phishing scam."
        };

        private string[] safeBrowsingTips = new string[]
        {
            "{0}, always check for HTTPS when entering sensitive information online.",
            "{0}, avoid using public Wi-Fi for banking or shopping.",
            "{0}, keep your browser and antivirus software updated.",
            "{0}, use a VPN when connecting to public networks.",
            "{0}, clear your browser cache and cookies regularly."
        };

        private string[] howAreYouResponses = new string[]
        {
            "I'm doing great, {0}! Ready to help you stay safe online.",
            "All systems secure! Thanks for asking, {0}.",
            "Doing fantastic! What cybersecurity topic can I help with today, {0}?",
            "I'm here 24/7 to help you with online safety, {0}!"
        };

        private string[] defaultResponses = new string[]
        {
            "{0}, I didn't understand that. Try typing 1 (passwords), 2 (phishing), 3 (safe browsing), or 0 (exit).",
            "Hmm, not sure what you mean. Please type 1, 2, 3, 4, or 0.",
            "I'm still learning! Try typing a number from the menu: 1, 2, 3, 4, or 0."
        };

        public string GetResponse(string userInput)
        {
            string lowerInput = userInput.ToLower().Trim();

            StoreUserInterest(lowerInput);

            if (IsFollowUpRequest(lowerInput) && !string.IsNullOrEmpty(lastTopic))
            {
                string topicResponse = GetResponseForTopic(lastTopic);
                LastSentiment = DetectSentiment(lowerInput);
                return ApplySentiment(topicResponse);
            }

            string choice = NormalizeChoice(lowerInput);
            LastSentiment = DetectSentiment(lowerInput);
            string botReply = HandleChoice(choice);
            return ApplySentiment(botReply);
        }

        private bool IsFollowUpRequest(string input)
        {
            string[] followKeywords = { "another tip", "tell me more", "explain more", "more about", "continue", "go on", "another one", "more tips" };
            foreach (string keyword in followKeywords)
            {
                if (input.Contains(keyword))
                    return true;
            }
            return false;
        }

        private string GetResponseForTopic(string topic)
        {
            if (topic == "password")
                return GetRandomResponse(passwordTips);
            else if (topic == "phishing")
                return GetRandomResponse(phishingTips);
            else if (topic == "safe browsing")
                return GetRandomResponse(safeBrowsingTips);
            else
                return GetRandomResponse(defaultResponses);
        }

        private void StoreUserInterest(string input)
        {
            if (input.Contains("interested in") || input.Contains("i like") || input.Contains("my favorite"))
            {
                if (input.Contains("password"))
                    userMemory["interest"] = "passwords";
                else if (input.Contains("phishing"))
                    userMemory["interest"] = "phishing";
                else if (input.Contains("safe browsing"))
                    userMemory["interest"] = "safe browsing";
            }
        }

        private string NormalizeChoice(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";

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
                    lastTopic = "password";
                    return GetRandomResponse(passwordTips);
                case "2":
                    lastTopic = "phishing";
                    return GetRandomResponse(phishingTips);
                case "3":
                    lastTopic = "safe browsing";
                    return GetRandomResponse(safeBrowsingTips);
                case "4":
                    return GetRandomResponse(howAreYouResponses);
                case "0":
                    return $"Goodbye, {userName}! Stay safe online.";
                default:
                    if (userMemory.ContainsKey("interest"))
                    {
                        return $"{userName}, I remember you're interested in {userMemory["interest"]}. " + GetRandomResponse(defaultResponses);
                    }
                    return GetRandomResponse(defaultResponses);
            }
        }

        private string GetRandomResponse(string[] responses)
        {
            int index = random.Next(responses.Length);
            return string.Format(responses[index], userName);
        }

        private string DetectSentiment(string input)
        {
            input = input.ToLower();
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("nervous") || input.Contains("anxious") || input.Contains("afraid"))
                return "worried";
            if (input.Contains("curious") || input.Contains("interested") || input.Contains("tell me") || input.Contains("want to learn"))
                return "curious";
            if (input.Contains("frustrated") || input.Contains("annoyed") || input.Contains("confused") || input.Contains("hate") || input.Contains("stupid"))
                return "frustrated";
            return "neutral";
        }

        private string ApplySentiment(string botResponse)
        {
            if (ModifyBySentiment != null)
                return ModifyBySentiment(botResponse, LastSentiment);
            return botResponse;
        }

        private string ApplySentimentAdjustment(string botResponse, string sentiment)
        {
            switch (sentiment)
            {
                case "worried":
                    return $"Hey {userName}, don't stress too much. {botResponse}";
                case "curious":
                    return $"Good question! {botResponse}";
                case "frustrated":
                    return $"Yeah I get it, this stuff can be annoying. {botResponse}";
                default:
                    return botResponse;
            }
        }
    }
}