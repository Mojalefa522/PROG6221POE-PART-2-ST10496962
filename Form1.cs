using System;
using System.Windows.Forms;

namespace PROG6221POE_PART_2_ST10496962
{
    public partial class Form1 : Form
    {
        private ChatBot bot;
        private bool waitingForName = true;
        private DatabaseHelper dbHelper;

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

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
                chatRichTextBox.AppendText($"BotManta: 0 - Exit" + Environment.NewLine);
            }
            else
            {
                string botReply = bot.GetResponse(userMessage);
                chatRichTextBox.AppendText($"BotManta: {botReply}" + Environment.NewLine);
                chatRichTextBox.AppendText(Environment.NewLine);
            }

            chatRichTextBox.ScrollToCaret();
        }
    }
}