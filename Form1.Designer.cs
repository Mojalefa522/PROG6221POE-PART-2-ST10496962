namespace PROG6221POE_PART_2_ST10496962
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            topPanel = new Panel();
            titleLabel = new Label();
            chatListBox = new ListBox();
            inputTextBox = new TextBox();
            sendButton = new Button();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.Controls.Add(titleLabel);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(432, 50);
            topPanel.TabIndex = 0;
            topPanel.Paint += toPanel_Paint;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.Green;
            titleLabel.Location = new Point(128, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(121, 31);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "BotManta";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chatListBox
            // 
            chatListBox.FormattingEnabled = true;
            chatListBox.Location = new Point(10, 60);
            chatListBox.Name = "chatListBox";
            chatListBox.Size = new Size(415, 384);
            chatListBox.TabIndex = 1;
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(10, 470);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(320, 27);
            inputTextBox.TabIndex = 2;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(340, 468);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(85, 32);
            sendButton.TabIndex = 3;
            sendButton.Text = "SEND";
            sendButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 553);
            Controls.Add(sendButton);
            Controls.Add(inputTextBox);
            Controls.Add(chatListBox);
            Controls.Add(topPanel);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BotManta";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel topPanel;
        private Label titleLabel;
        private ListBox chatListBox;
        private TextBox inputTextBox;
        private Button sendButton;
    }
}
