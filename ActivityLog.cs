using System;
using System.Collections.Generic;

namespace PROG6221POE_PART_2_ST10496962
{
    public class ActivityLog
    {
        private List<LogEntry> logEntries = new List<LogEntry>();
        private int maxEntries = 10;

        public ActivityLog()
        {
            LogAction("Chatbot started", "System initialized");
        }

        public void LogAction(string action, string details = "")
        {
            logEntries.Add(new LogEntry
            {
                Timestamp = DateTime.Now,
                Action = action,
                Details = details
            });

            // Keep only last 10 entries
            if (logEntries.Count > maxEntries)
            {
                logEntries.RemoveAt(0);
            }
        }

        public string DisplayLog()
        {
            if (logEntries.Count == 0)
                return "No activities logged yet.";

            string result = "📋 Recent Activities:\n\n";
            for (int i = 0; i < logEntries.Count; i++)
            {
                var entry = logEntries[i];
                result += $"{i + 1}. [{entry.Timestamp:yyyy-MM-dd HH:mm}] {entry.Action}\n";
                if (!string.IsNullOrEmpty(entry.Details))
                {
                    result += $"   → {entry.Details}\n";
                }
            }
            return result;
        }

        public List<LogEntry> GetRecentEntries(int count = 10)
        {
            int take = Math.Min(count, logEntries.Count);
            return logEntries.GetRange(logEntries.Count - take, take);
        }
    }

    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
    }
}