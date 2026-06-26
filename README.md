# PROG6221POE ST10496962
# BotManta - Cybersecurity Awareness Chatbot

A comprehensive cybersecurity awareness chatbot built with C# and WinForms, featuring task management, interactive quiz, activity logging, and NLP simulation.

---

## Features

### Part 2 Features (Original)
- GUI with dark theme and ASCII art banner
- Voice greeting on startup
- Keyword recognition
- Random responses for passwords, phishing, and safe browsing
- Conversation flow when user types "another tip" or "tell me more"
- Memory - remembers your name and interests throughout the program
- Sentiment detection - responds to "worried", "curious", or "frustrated"
- Error handling for unknown inputs

### Part 3 Features (New)
- **Task Manager with MySQL Database**
  - Add tasks with descriptions
  - Set 7-day reminders
  - View all tasks with status ([PENDING] / [COMPLETED])
  - Delete tasks
  - Mark tasks as completed
  - Persistent storage using MySQL

- **Cybersecurity Quiz Game**
  - 12 cybersecurity questions
  - Mixed question types (Multiple Choice & True/False)
  - Immediate feedback with explanations
  - Score tracking
  - Final score with personalized feedback

- **Activity Log**
  - Tracks all user actions with timestamps
  - Stores last 10 activities
  - Displays recent actions on request

- **NLP Simulation**
  - Keyword detection for all commands
  - Understands variations:
    - "add task", "new task", "create task"
    - "delete task", "remove task"
    - "complete task", "finish task"
    - "show tasks", "view tasks"
    - "play quiz", "start quiz"
    - "show log", "activity log", "history"

---

## How to Run

### Prerequisites
- Visual Studio 2019 or higher
- MySQL Server (XAMPP recommended)
- MySql.Data NuGet package

### Setup Instructions

1. Clone or download the repository
2. Open the solution in Visual Studio
3. Install MySQL Connector:
   - Tools → NuGet Package Manager → Manage NuGet Packages for Solution
   - Search for MySql.Data and install
4. Start MySQL (using XAMPP Control Panel or your preferred method)
5. Update Database Connection (if needed):
   - Open DatabaseHelper.cs
   - Update the connection string with your MySQL password
6. Press F5 to run the application
7. Enter your name when asked
8. Type a number or command from the menu

---

## Commands

### Menu Options
| Command | Description |
|---------|-------------|
| 1 or password | Password safety tips |
| 2 or phishing | Phishing protection tips |
| 3 or safe browsing | Safe browsing tips |
| 4 or how are you | Bot response |
| 5 or tasks | View all tasks |
| 6 or quiz | Start cybersecurity quiz |
| 7 or show log | View activity log |
| 0 or exit | Exit the chat |

### Task Management Commands
| Command | Description |
|---------|-------------|
| add task [description] | Add a new task |
| new task [description] | Add a new task (NLP variation) |
| delete task X | Delete task with ID X |
| remove task X | Delete task with ID X (NLP variation) |
| complete task X | Mark task X as completed |
| finish task X | Mark task X as completed (NLP variation) |

### Other Commands
| Command | Description |
|---------|-------------|
| another tip | Get another tip on the same topic |
| tell me more | Get more information |
| I'm interested in passwords | Bot remembers your interest |
| I'm worried / curious / frustrated | Sentiment response |
| show tasks | View all tasks (NLP variation) |
| play quiz | Start quiz (NLP variation) |
| history | View activity log (NLP variation) |

---

## Project Structure

| File | Purpose |
|------|---------|
| Form1.cs | GUI - chat display, input box, send button, voice greeting |
| Form1.Designer.cs | GUI design and layout |
| ChatBot.cs | Core logic - keyword recognition, responses, memory, sentiment |
| DatabaseHelper.cs | MySQL database connection and CRUD operations |
| ActivityLog.cs | Activity tracking and display |
| QuizGame.cs | Cybersecurity quiz with 12 questions and scoring |
| NLPProcessor.cs | Keyword detection and intent recognition |
| Program.cs | Application entry point |

---

## Database Schema

### Tasks Table
| Column | Type | Description |
|--------|------|-------------|
| id | INT (AUTO_INCREMENT) | Unique task ID (Primary Key) |
| title | VARCHAR(255) | Task title |
| description | TEXT | Task description |
| reminder_date | DATETIME | Optional reminder date (7 days from creation) |
| status | VARCHAR(20) | Task status: 'pending' or 'completed' |
| created_at | TIMESTAMP | Task creation timestamp |

---

## Technologies Used

- Language: C#
- Framework: Windows Forms (.NET Framework)
- Database: MySQL
- Version Control: Git / GitHub
- IDE: Visual Studio 2022

---

## Author

Mojalefa Kabelo
Student Number: ST10496962
Date: June 2026

---

## Version History

| Version | Date | Description |
|---------|------|-------------|
| v1.0.0 | June 2026 | Part 2 - Basic chatbot with sentiment detection |
| v2.0.0 | June 2026 | Added quiz and activity log |
| v3.0.0 | June 2026 | Added task management with MySQL and NLP simulation |
