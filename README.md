# PROG6221POE PART 2 ST10496962
# BotManta - Cybersecurity Chatbot

A cybersecurity awareness chatbot built with C# and WinForms.

Features

- GUI with dark theme and ASCII art banner
- Voice greeting on startup 
- Keyword recognition
- Random responses for passwords, phishing, and safe browsing
- Conversation flow when user types in "another tip" or "tell me more"
- Memory - remembers your name and interests throughout the program.
- Sentiment detection which responds to you saying youre "worried, curious or frustrated"
- Error handling for unknown inputs so it doesn't just keep saying"try again"

How to Run

1. Open the solution in Visual Studio
2. Press F5 to run
3. Enter your name when asked
4. Type a number or topic

Type "1" or "password" for password safety tips
Type "2" or "phishing" for phishing protection tips
Type "3" or "safe browsing" for safe browsing tips
Type "4" or "how are you" for bot response
Type "0" or "exit" to exit the chat

Other Commands

Type "another tip" or "tell me more" to get another tip on the same topic
Type "I'm interested in passwords" to make the bot remember your interest
Type "I'm worried" or "I'm curious" or "I'm frustrated" for sentiment responses

Project Files

Form1.cs handles the GUI - chat display, input box, send button, and voice greeting
ChatBot.cs handles all the logic - keyword recognition, random responses, memory, sentiment, and conversation flow
welcome.wav is the voice greeting file

Author

Mojalefa Kabelo
ST10496962

28 May 2026
