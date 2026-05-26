using System;
using System.Windows.Forms;

namespace PROG6221POE_PART_2_ST10496962
{
    public partial class Form1 : Form
    {
        private ChatBot bot;

        public Form1()
        {
            InitializeComponent();

            // Ask for name
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter your name:", "Welcome to BotManta", "User");
            if (string.IsNullOrWhiteSpace(name)) name = "User";
            name = char.ToUpper(name[0]) + name.Substring(1).ToLower();

            // Create chatbot
            bot = new ChatBot(name);

            // Welcome message with name
            chatListBox.Items.Add($"BotManta: Hello {name}! Welcome to my school project.");
            chatListBox.Items.Add($"BotManta: Please choose an option:");
            chatListBox.Items.Add("");
            chatListBox.Items.Add($"BotManta: 1 - Password Safety");
            chatListBox.Items.Add($"BotManta: 2 - Phishing Tips");
            chatListBox.Items.Add($"BotManta: 3 - Safe Browsing");
            chatListBox.Items.Add($"BotManta: 4 - How are you?");
            chatListBox.Items.Add($"BotManta: 0 - Exit");

            // Connect send button
            sendButton.Click += sendButton_Click;
            this.AcceptButton = sendButton;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string userMessage = inputTextBox.Text.Trim();
            if (userMessage == "") return;

            chatListBox.Items.Add($"You: {userMessage}");
            inputTextBox.Text = "";

            string botReply = bot.GetResponse(userMessage);
            chatListBox.Items.Add($"BotManta: {botReply}");
            chatListBox.Items.Add("");

            chatListBox.TopIndex = chatListBox.Items.Count - 1;
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chatListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}