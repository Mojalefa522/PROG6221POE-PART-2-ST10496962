using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROG6221POE_PART_2_ST10496962
{
    public class QuizGame
    {
        private List<QuizQuestion> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;
        private Form quizForm;
        private Label questionLabel;
        private RadioButton[] optionRadios;
        private Button submitButton;
        private Label feedbackLabel;
        private Label scoreLabel;

        public QuizGame()
        {
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "1. What is phishing?",
                    Options = new string[] {
                        "A type of computer virus",
                        "A technique where attackers impersonate legitimate organizations",
                        "A method of encrypting files",
                        "A type of firewall"
                    },
                    CorrectIndex = 1,
                    Explanation = "Phishing is a social engineering attack where criminals impersonate trusted entities."
                },
                new QuizQuestion
                {
                    Question = "2. Which of the following is a strong password?",
                    Options = new string[] {
                        "password123",
                        "qwerty",
                        "P@ssw0rd!2024#Secure",
                        "123456"
                    },
                    CorrectIndex = 2,
                    Explanation = "Strong passwords should be 12+ characters with uppercase, lowercase, numbers, and special characters."
                },
                new QuizQuestion
                {
                    Question = "3. True or False: Using public Wi-Fi for banking is completely safe.",
                    Options = new string[] { "True", "False" },
                    CorrectIndex = 1,
                    Explanation = "False! Public Wi-Fi is often unsecured. Use a VPN or avoid sensitive activities."
                },
                new QuizQuestion
                {
                    Question = "4. What does HTTPS stand for?",
                    Options = new string[] {
                        "HyperText Transfer Protocol Secure",
                        "HyperText Transfer Protocol System",
                        "High-Tech Transfer Protocol Secure",
                        "Hyper Transfer Text Protocol System"
                    },
                    CorrectIndex = 0,
                    Explanation = "HTTPS means the website uses encryption to protect your data."
                },
                new QuizQuestion
                {
                    Question = "5. True or False: You should use the same password for all accounts.",
                    Options = new string[] { "True", "False" },
                    CorrectIndex = 1,
                    Explanation = "False! Use unique passwords for each account to prevent widespread breaches."
                },
                new QuizQuestion
                {
                    Question = "6. What should you do with an email from an unknown sender with an attachment?",
                    Options = new string[] {
                        "Open the attachment",
                        "Forward it to friends",
                        "Delete or report as spam",
                        "Reply and ask who they are"
                    },
                    CorrectIndex = 2,
                    Explanation = "Never open attachments from unknown senders. They could contain malware."
                },
                new QuizQuestion
                {
                    Question = "7. True or False: Two-Factor Authentication (2FA) adds extra security.",
                    Options = new string[] { "True", "False" },
                    CorrectIndex = 0,
                    Explanation = "True! 2FA requires two forms of verification, making accounts much harder to compromise."
                },
                new QuizQuestion
                {
                    Question = "8. What is ransomware?",
                    Options = new string[] {
                        "A type of antivirus",
                        "Malware that encrypts files and demands payment",
                        "A secure file transfer method",
                        "A firewall protection type"
                    },
                    CorrectIndex = 1,
                    Explanation = "Ransomware encrypts your files and demands ransom payment for the decryption key."
                },
                new QuizQuestion
                {
                    Question = "9. True or False: It's safe to share passwords with trusted friends.",
                    Options = new string[] { "True", "False" },
                    CorrectIndex = 1,
                    Explanation = "False! Never share passwords. You can't control how others handle your information."
                },
                new QuizQuestion
                {
                    Question = "10. What is social engineering?",
                    Options = new string[] {
                        "Brute force hacking",
                        "Fake emails from your bank asking for login details",
                        "Virus spreading via email",
                        "Firewall blocking access"
                    },
                    CorrectIndex = 1,
                    Explanation = "Social engineering manipulates people into revealing confidential information."
                },
                new QuizQuestion
                {
                    Question = "11. True or False: It's okay to click 'Remember password' on public computers.",
                    Options = new string[] { "True", "False" },
                    CorrectIndex = 1,
                    Explanation = "False! Others could access your accounts. Always use private browsing on shared computers."
                },
                new QuizQuestion
                {
                    Question = "12. What is the purpose of a firewall?",
                    Options = new string[] {
                        "Monitor and control network traffic",
                        "Create strong passwords",
                        "Encrypt emails",
                        "Backup files"
                    },
                    CorrectIndex = 0,
                    Explanation = "A firewall monitors network traffic and blocks unauthorized access."
                }
            };
        }

        public void StartQuiz()
        {
            currentQuestionIndex = 0;
            score = 0;
            ShowQuizWindow();
        }

        private void ShowQuizWindow()
        {
            quizForm = new Form();
            quizForm.Text = "🛡️ Cybersecurity Quiz";
            quizForm.Size = new System.Drawing.Size(650, 520);
            quizForm.StartPosition = FormStartPosition.CenterParent;
            quizForm.BackColor = System.Drawing.Color.FromArgb(15, 20, 30);
            quizForm.ForeColor = System.Drawing.Color.White;

            Label titleLabel = new Label();
            titleLabel.Text = "🔐 Cybersecurity Knowledge Quiz";
            titleLabel.Location = new System.Drawing.Point(20, 10);
            titleLabel.Size = new System.Drawing.Size(600, 30);
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            titleLabel.ForeColor = System.Drawing.Color.FromArgb(0, 255, 200);
            titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            questionLabel = new Label();
            questionLabel.Location = new System.Drawing.Point(20, 50);
            questionLabel.Size = new System.Drawing.Size(590, 60);
            questionLabel.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            questionLabel.ForeColor = System.Drawing.Color.White;
            questionLabel.Text = questions[currentQuestionIndex].Question;

            optionRadios = new RadioButton[4];
            int yPos = 120;
            for (int i = 0; i < questions[currentQuestionIndex].Options.Length; i++)
            {
                optionRadios[i] = new RadioButton();
                optionRadios[i].Location = new System.Drawing.Point(30, yPos);
                optionRadios[i].Size = new System.Drawing.Size(550, 30);
                optionRadios[i].Text = questions[currentQuestionIndex].Options[i];
                optionRadios[i].Font = new System.Drawing.Font("Segoe UI", 10);
                optionRadios[i].ForeColor = System.Drawing.Color.White;
                optionRadios[i].BackColor = System.Drawing.Color.Transparent;
                yPos += 35;
            }

            submitButton = new Button();
            submitButton.Location = new System.Drawing.Point(220, 330);
            submitButton.Size = new System.Drawing.Size(180, 40);
            submitButton.Text = "Submit Answer";
            submitButton.BackColor = System.Drawing.Color.FromArgb(0, 150, 200);
            submitButton.ForeColor = System.Drawing.Color.White;
            submitButton.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.Cursor = Cursors.Hand;
            submitButton.Click += SubmitAnswer;

            feedbackLabel = new Label();
            feedbackLabel.Location = new System.Drawing.Point(20, 380);
            feedbackLabel.Size = new System.Drawing.Size(590, 80);
            feedbackLabel.Font = new System.Drawing.Font("Segoe UI", 10);
            feedbackLabel.ForeColor = System.Drawing.Color.White;

            scoreLabel = new Label();
            scoreLabel.Location = new System.Drawing.Point(20, 460);
            scoreLabel.Size = new System.Drawing.Size(200, 30);
            scoreLabel.Text = $"Score: {score}/{questions.Count}";
            scoreLabel.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            scoreLabel.ForeColor = System.Drawing.Color.FromArgb(0, 255, 200);

            quizForm.Controls.Add(titleLabel);
            quizForm.Controls.Add(questionLabel);
            foreach (RadioButton rb in optionRadios)
            {
                if (rb != null) quizForm.Controls.Add(rb);
            }
            quizForm.Controls.Add(submitButton);
            quizForm.Controls.Add(feedbackLabel);
            quizForm.Controls.Add(scoreLabel);

            quizForm.ShowDialog();
        }

        private void SubmitAnswer(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < optionRadios.Length; i++)
            {
                if (optionRadios[i] != null && optionRadios[i].Checked)
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex == -1)
            {
                MessageBox.Show("Please select an answer!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuizQuestion currentQuestion = questions[currentQuestionIndex];
            bool isCorrect = selectedIndex == currentQuestion.CorrectIndex;

            if (isCorrect)
            {
                score++;
                feedbackLabel.Text = $"✅ Correct! {currentQuestion.Explanation}";
                feedbackLabel.ForeColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                feedbackLabel.Text = $"❌ Incorrect. {currentQuestion.Explanation}";
                feedbackLabel.ForeColor = System.Drawing.Color.OrangeRed;
            }

            scoreLabel.Text = $"Score: {score}/{questions.Count}";
            submitButton.Enabled = false;

            currentQuestionIndex++;
            if (currentQuestionIndex < questions.Count)
            {
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 3000;
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    ShowNextQuestion();
                };
                timer.Start();
            }
            else
            {
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 3000;
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    ShowFinalScore();
                };
                timer.Start();
            }
        }

        private void ShowNextQuestion()
        {
            submitButton.Enabled = true;
            feedbackLabel.Text = "";

            QuizQuestion currentQuestion = questions[currentQuestionIndex];
            questionLabel.Text = currentQuestion.Question;

            for (int i = 0; i < 4; i++)
            {
                if (optionRadios[i] != null)
                {
                    if (i < currentQuestion.Options.Length)
                    {
                        optionRadios[i].Text = currentQuestion.Options[i];
                        optionRadios[i].Visible = true;
                        optionRadios[i].Checked = false;
                    }
                    else
                    {
                        optionRadios[i].Visible = false;
                    }
                }
            }
        }

        private void ShowFinalScore()
        {
            string feedback;
            if (score == questions.Count)
                feedback = "🌟 PERFECT! You're a cybersecurity expert!";
            else if (score >= questions.Count * 0.7)
                feedback = "👏 Great job! You know your cybersecurity well!";
            else if (score >= questions.Count * 0.5)
                feedback = "📚 Good effort! Keep learning to stay safe online!";
            else
                feedback = "🔒 Keep learning! Cybersecurity is important for everyone!";

            MessageBox.Show($"🎯 Quiz Complete!\n\nScore: {score}/{questions.Count}\n\n{feedback}",
                          "Quiz Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            quizForm.Close();
        }
    }

    public class QuizQuestion
    {
        public string Question { get; set; }
        public string[] Options { get; set; }
        public int CorrectIndex { get; set; }
        public string Explanation { get; set; }
    }
}