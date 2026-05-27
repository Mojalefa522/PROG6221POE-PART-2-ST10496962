namespace PROG6221POE_PART_2_ST10496962
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            topPanel = new Panel();
            asciiLabel = new Label();
            chatRichTextBox = new RichTextBox();
            inputTextBox = new TextBox();
            sendButton = new Button();
            topPanel.SuspendLayout();
            SuspendLayout();

            // topPanel
            topPanel.BackColor = Color.FromArgb(0, 20, 30);
            topPanel.Controls.Add(asciiLabel);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(500, 50);
            topPanel.TabIndex = 0;

            // asciiLabel
            asciiLabel.AutoSize = false;
            asciiLabel.Dock = DockStyle.Fill;
            asciiLabel.Font = new Font("Consolas", 9, FontStyle.Bold);
            asciiLabel.ForeColor = Color.FromArgb(0, 255, 200);
            asciiLabel.BackColor = Color.FromArgb(0, 20, 30);
            asciiLabel.Text = ">>> BOTMANTA - CYBERSECURITY CHATBOT <<<";
            asciiLabel.TextAlign = ContentAlignment.MiddleCenter;

            // chatRichTextBox
            chatRichTextBox.BackColor = Color.FromArgb(20, 25, 35);
            chatRichTextBox.ForeColor = Color.White;
            chatRichTextBox.Font = new Font("Segoe UI", 10);
            chatRichTextBox.Location = new Point(15, 65);
            chatRichTextBox.Name = "chatRichTextBox";
            chatRichTextBox.Size = new Size(470, 400);
            chatRichTextBox.TabIndex = 1;
            chatRichTextBox.ReadOnly = true;
            chatRichTextBox.WordWrap = true;
            chatRichTextBox.Multiline = true;
            chatRichTextBox.BorderStyle = BorderStyle.FixedSingle;

            // inputTextBox
            inputTextBox.BackColor = Color.FromArgb(30, 35, 45);
            inputTextBox.ForeColor = Color.White;
            inputTextBox.Font = new Font("Segoe UI", 10);
            inputTextBox.Location = new Point(15, 480);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(370, 27);
            inputTextBox.TabIndex = 2;
            inputTextBox.BorderStyle = BorderStyle.FixedSingle;
            inputTextBox.PlaceholderText = "Type your message here...";

            // sendButton
            sendButton.BackColor = Color.FromArgb(0, 150, 200);
            sendButton.ForeColor = Color.White;
            sendButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            sendButton.Location = new Point(395, 478);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(90, 32);
            sendButton.TabIndex = 3;
            sendButton.Text = "SEND";
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.FlatAppearance.BorderSize = 0;
            sendButton.Cursor = Cursors.Hand;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 20, 30);
            ClientSize = new Size(500, 530);
            Controls.Add(sendButton);
            Controls.Add(inputTextBox);
            Controls.Add(chatRichTextBox);
            Controls.Add(topPanel);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BotManta";
            topPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel topPanel;
        private Label asciiLabel;
        private RichTextBox chatRichTextBox;
        private TextBox inputTextBox;
        private Button sendButton;
    }
}