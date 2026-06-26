using System;
using System.Collections.Generic;

namespace PROG6221POE_PART_2_ST10496962
{
    public class NLPProcessor
    {
        private Dictionary<string, List<string>> intentKeywords;

        public NLPProcessor()
        {
            LoadKeywords();
        }

        private void LoadKeywords()
        {
            intentKeywords = new Dictionary<string, List<string>>();

            // Task related keywords
            intentKeywords["add_task"] = new List<string>
            {
                "add task", "new task", "create task", "add a task", "make task",
                "create a task", "task add", "task new", "add to do", "new to do"
            };

            // Delete task keywords
            intentKeywords["delete_task"] = new List<string>
            {
                "delete task", "remove task", "erase task", "delete", "remove",
                "delete to do", "remove to do", "task delete", "task remove"
            };

            // Complete task keywords
            intentKeywords["complete_task"] = new List<string>
            {
                "complete task", "finish task", "done task", "mark task",
                "task complete", "task done", "finish", "complete"
            };

            // View tasks keywords
            intentKeywords["view_tasks"] = new List<string>
            {
                "show tasks", "view tasks", "list tasks", "tasks", "task manager",
                "view all tasks", "show all tasks", "get tasks", "task list"
            };

            // Quiz keywords
            intentKeywords["quiz"] = new List<string>
            {
                "quiz", "play quiz", "start quiz", "take quiz", "game",
                "test", "knowledge test", "cybersecurity quiz", "do quiz"
            };

            // Activity log keywords
            intentKeywords["activity_log"] = new List<string>
            {
                "show log", "view log", "activity log", "log",
                "history", "what have you done", "show history",
                "view activity", "recent actions"
            };

            // Add task with reminder phrases
            intentKeywords["add_task_with_reminder"] = new List<string>
            {
                "remind me to", "set reminder for", "remind me about",
                "set a reminder", "remind to", "remember to"
            };
        }

        public string DetectIntent(string userInput)
        {
            string lowerInput = userInput.ToLower().Trim();

            foreach (var intent in intentKeywords)
            {
                foreach (string keyword in intent.Value)
                {
                    if (lowerInput.Contains(keyword))
                    {
                        return intent.Key;
                    }
                }
            }

            return "unknown";
        }

        public string ExtractTaskDescription(string userInput)
        {
            string lowerInput = userInput.ToLower().Trim();

            // Check for "remind me to" pattern
            if (lowerInput.Contains("remind me to"))
            {
                int startIndex = lowerInput.IndexOf("remind me to") + 12;
                if (startIndex < lowerInput.Length)
                {
                    string description = lowerInput.Substring(startIndex).Trim();
                    if (!string.IsNullOrEmpty(description))
                    {
                        return char.ToUpper(description[0]) + description.Substring(1);
                    }
                }
            }

            // Check for "add task" patterns
            string[] taskPrefixes = { "add task", "new task", "create task", "add a task", "make task" };
            foreach (string prefix in taskPrefixes)
            {
                if (lowerInput.Contains(prefix))
                {
                    int startIndex = lowerInput.IndexOf(prefix) + prefix.Length;
                    if (startIndex < lowerInput.Length)
                    {
                        string description = lowerInput.Substring(startIndex).Trim();
                        // Remove "to" if it's at the start
                        if (description.StartsWith("to "))
                        {
                            description = description.Substring(3);
                        }
                        if (!string.IsNullOrEmpty(description))
                        {
                            return char.ToUpper(description[0]) + description.Substring(1);
                        }
                    }
                }
            }

            return "";
        }

        public DateTime? ExtractReminderDate(string userInput)
        {
            string lowerInput = userInput.ToLower().Trim();

            // Check for "in X days" pattern
            if (lowerInput.Contains(" in ") && lowerInput.Contains(" day"))
            {
                try
                {
                    int startIndex = lowerInput.IndexOf(" in ") + 4;
                    int endIndex = lowerInput.IndexOf(" day", startIndex);
                    if (endIndex > startIndex)
                    {
                        string dayStr = lowerInput.Substring(startIndex, endIndex - startIndex).Trim();
                        if (int.TryParse(dayStr, out int days))
                        {
                            return DateTime.Now.AddDays(days);
                        }
                    }
                }
                catch { }
            }

            // Check for "tomorrow"
            if (lowerInput.Contains("tomorrow"))
            {
                return DateTime.Now.AddDays(1);
            }

            // Check for "next week"
            if (lowerInput.Contains("next week"))
            {
                return DateTime.Now.AddDays(7);
            }

            // Default: 7 days from now if they said "remind"
            if (lowerInput.Contains("remind"))
            {
                return DateTime.Now.AddDays(7);
            }

            return null;
        }

        public bool IsTaskCommand(string userInput)
        {
            string intent = DetectIntent(userInput);
            return intent == "add_task" || intent == "add_task_with_reminder" ||
                   intent == "delete_task" || intent == "complete_task" ||
                   intent == "view_tasks";
        }

        public bool IsQuizCommand(string userInput)
        {
            return DetectIntent(userInput) == "quiz";
        }

        public bool IsActivityLogCommand(string userInput)
        {
            return DetectIntent(userInput) == "activity_log";
        }

        public string GetIntentHelp()
        {
            return "I can understand these commands:\n" +
                   "- 'add task [description]' or 'new task [description]'\n" +
                   "- 'delete task X' or 'remove task X'\n" +
                   "- 'complete task X' or 'finish task X'\n" +
                   "- 'tasks' or 'show tasks' to view all tasks\n" +
                   "- 'quiz' or 'play quiz' to start the quiz\n" +
                   "- 'show log' or 'activity log' to see your history\n" +
                   "- 'remind me to [description]' to add a task with reminder";
        }
    }
}