using System;
using System.Windows.Forms;

namespace PROG6221POE_PART_2_ST10496962
{
    public partial class Form1 : Form
    {
        private ChatBot bot;
        private bool waitingForName = true;
        private DatabaseHelper dbHelper;
        private ActivityLog activityLog;
        private QuizGame quizGame;
        private NLPProcessor nlpProcessor;
        private string pendingTask = "";
        private bool waitingForReminder = false;

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            activityLog = new ActivityLog();
            quizGame = new QuizGame();
            nlpProcessor = new NLPProcessor();

            chatRichTextBox.Clear();
            ShowAsciiArt();

            chatRichTextBox.AppendText(Environment.NewLine);
            chatRichTextBox.AppendText("BotManta: Hello! Welcome to Cybersecurity Chatbot Manta." + Environment.NewLine);
            chatRichTextBox.AppendText("BotManta: Please tell me your name first." + Environment.NewLine);
            chatRichTextBox.AppendText(Environment.NewLine);

            sendButton.Click += sendButton_Click;
            this.AcceptButton = sendButton;

            try
            {
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "welcome.wav");
                if (System.IO.File.Exists(path))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
                    player.Play();
                }
            }
            catch { }
        }

        private void ShowAsciiArt()
        {
            chatRichTextBox.AppendText("================================================================" + Environment.NewLine);
            chatRichTextBox.AppendText("||                                                            ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||   |        \\ /      \\  /      \\ |       \\                  ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||   | $$$$$$$$|  $$$$$$\\|  $$$$$$\\| $$$$$$$\\                 ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||   | $$__    | $$___\\$$| $$   \\$$| $$__/ $$                 ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||   | $$  \\    \\$$    \\ | $$      | $$    $$                 ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||   | $$$$$    _\\$$$$$$\\| $$   __ | $$$$$$$\\                 ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||   | $$_____ |  \\__| $$| $$__/  \\| $$__/ $$                 ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||   | $$     \\ \\$$    $$ \\$$    $$| $$    $$                 ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||    \\$$$$$$$$  \\$$$$$$   \\$$$$$$  \\$$$$$$$                  ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||                                                            ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||                CYBERSECURITY CHATBOT SYSTEM                ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||                         BOTMANTA                           ||" + Environment.NewLine);
            chatRichTextBox.AppendText("||                                                            ||" + Environment.NewLine);
            chatRichTextBox.AppendText("================================================================" + Environment.NewLine);
        }

        private string FormatName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "User";

            name = name.Trim().ToLower();
            return char.ToUpper(name[0]) + name.Substring(1);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string userMessage = inputTextBox.Text.Trim();
            if (userMessage == "") return;

            chatRichTextBox.AppendText($"You: {userMessage}" + Environment.NewLine);
            inputTextBox.Text = "";
            activityLog.LogAction("User input", userMessage);

            if (waitingForName)
            {
                string name = FormatName(userMessage);
                bot = new ChatBot(name);
                waitingForName = false;

                chatRichTextBox.Clear();

                chatRichTextBox.AppendText($"BotManta: Nice to meet you, {name}!" + Environment.NewLine);
                chatRichTextBox.AppendText($"BotManta: Please choose an option:" + Environment.NewLine);
                chatRichTextBox.AppendText(Environment.NewLine);
                chatRichTextBox.AppendText($"BotManta: 1 - Password Safety" + Environment.NewLine);
                chatRichTextBox.AppendText($"BotManta: 2 - Phishing Tips" + Environment.NewLine);
                chatRichTextBox.AppendText($"BotManta: 3 - Safe Browsing" + Environment.NewLine);
                chatRichTextBox.AppendText($"BotManta: 4 - How are you?" + Environment.NewLine);
                chatRichTextBox.AppendText($"BotManta: 5 - Task Manager" + Environment.NewLine);
                chatRichTextBox.AppendText($"BotManta: 6 - Play Quiz" + Environment.NewLine);
                chatRichTextBox.AppendText($"BotManta: 7 - Show Activity Log" + Environment.NewLine);
                chatRichTextBox.AppendText($"BotManta: 0 - Exit" + Environment.NewLine);
            }
            else
            {
                string botReply = ProcessUserInput(userMessage);
                chatRichTextBox.AppendText($"BotManta: {botReply}" + Environment.NewLine);
                chatRichTextBox.AppendText(Environment.NewLine);
            }

            chatRichTextBox.ScrollToCaret();
        }

        private string ProcessUserInput(string userInput)
        {
            string lowerInput = userInput.ToLower().Trim();

            // Handle reminder confirmation
            if (waitingForReminder)
            {
                return HandleReminderResponse(userInput);
            }

            // Use NLP to detect intent
            string intent = nlpProcessor.DetectIntent(userInput);

            // Handle different intents
            switch (intent)
            {
                case "add_task":
                case "add_task_with_reminder":
                    return HandleAddTask(userInput);

                case "delete_task":
                    return HandleDeleteTask(userInput);

                case "complete_task":
                    return HandleCompleteTask(userInput);

                case "view_tasks":
                    return HandleTaskManager();

                case "quiz":
                    return HandleQuizCommand();

                case "activity_log":
                    return HandleActivityLog();

                default:
                    // If no intent is detected then try to extract task from natural language
                    if (lowerInput.Contains("remind me to") || lowerInput.Contains("remind me about"))
                    {
                        string description = nlpProcessor.ExtractTaskDescription(userInput);
                        if (!string.IsNullOrEmpty(description))
                        {
                            // Create a task with reminder
                            pendingTask = description;
                            waitingForReminder = true;
                            activityLog.LogAction("Task pending from NLP", $"'{description}' - waiting for reminder");
                            return $"Task '{description}' added. Would you like to set a reminder? (yes/no)";
                        }
                    }

                    // Fall back to existing ChatBot logic
                    return bot.GetResponse(userInput);
            }
        }

        private string HandleTaskManager()
        {
            if (dbHelper == null) return "Database not available.";

            var tasks = dbHelper.GetAllTasks();
            if (tasks.Count == 0)
            {
                activityLog.LogAction("Task manager viewed", "No tasks found");
                return "You have no tasks yet. Type 'add task [description]' to create one!";
            }

            string result = "YOUR TASKS:\n\n";
            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];
                string status = task.Status == "completed" ? "[COMPLETED]" : "[PENDING]";
                string reminder = task.ReminderDate.HasValue ? $" (Reminder: {task.ReminderDate.Value:yyyy-MM-dd})" : "";
                result += $"{i + 1}. {status} {task.Title}{reminder}\n   {task.Description}\n\n";
            }

            activityLog.LogAction("Task manager viewed", $"{tasks.Count} tasks displayed");
            return result + "\nCommands:\n- 'delete task X' - Delete task X\n- 'complete task X' - Mark task X as done";
        }

        private string HandleAddTask(string userInput)
        {
            string description = userInput.Replace("add task", "").Replace("new task", "").Trim();

            if (string.IsNullOrEmpty(description))
            {
                return "What task would you like to add? Type 'add task [description]'";
            }

            pendingTask = description;
            waitingForReminder = true;

            activityLog.LogAction("Task pending", $"'{description}' - waiting for reminder");

            return $"Task '{description}' added. Would you like to set a reminder? (yes/no)";
        }

        private string HandleReminderResponse(string userInput)
        {
            string lowerInput = userInput.ToLower().Trim();

            if (lowerInput.Contains("yes") || lowerInput.Contains("sure") || lowerInput.Contains("ok"))
            {
                waitingForReminder = false;
                DateTime reminderDate = DateTime.Now.AddDays(7);
                dbHelper.AddTask(pendingTask, pendingTask, reminderDate);

                activityLog.LogAction("Task added with reminder", $"'{pendingTask}' - reminder in 7 days");

                return $"Reminder set for '{pendingTask}' on {reminderDate:yyyy-MM-dd}. I'll remind you!";
            }
            else if (lowerInput.Contains("no") || lowerInput.Contains("nope"))
            {
                waitingForReminder = false;
                dbHelper.AddTask(pendingTask, pendingTask, null);

                activityLog.LogAction("Task added without reminder", $"'{pendingTask}'");

                return $"Task '{pendingTask}' added with no reminder.";
            }
            else
            {
                return "Please answer 'yes' or 'no' for setting a reminder.";
            }
        }

        private string HandleDeleteTask(string userInput)
        {
            try
            {
                string[] parts = userInput.Split(' ');
                if (parts.Length >= 3 && int.TryParse(parts[2], out int taskId))
                {
                    dbHelper.DeleteTask(taskId);
                    activityLog.LogAction("Task deleted", $"Task ID: {taskId}");
                    return $"Task {taskId} deleted successfully!";
                }
                return "Please specify the task number: 'delete task X'";
            }
            catch
            {
                return "Error deleting task. Please try again.";
            }
        }

        private string HandleCompleteTask(string userInput)
        {
            try
            {
                string[] parts = userInput.Split(' ');
                if (parts.Length >= 3 && int.TryParse(parts[2], out int taskId))
                {
                    dbHelper.MarkTaskCompleted(taskId);
                    activityLog.LogAction("Task completed", $"Task ID: {taskId}");
                    return $"Task {taskId} marked as completed! Great job!";
                }
                return "Please specify the task number: 'complete task X'";
            }
            catch
            {
                return "Error completing task. Please try again.";
            }
        }

        private string HandleQuizCommand()
        {
            if (quizGame == null) return "Quiz not available.";

            activityLog.LogAction("Quiz started", "User started cybersecurity quiz");
            quizGame.StartQuiz();
            activityLog.LogAction("Quiz completed", "User finished the quiz");

            return "Quiz completed! Check your results!";
        }

        private string HandleActivityLog()
        {
            if (activityLog == null) return "Activity log not available.";

            string log = activityLog.DisplayLog();
            activityLog.LogAction("Activity log viewed", "User checked their activity history");

            return log;
        }
    }
}