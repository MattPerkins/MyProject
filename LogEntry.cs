// Matthew Perkins
// SDC320 - Game Mod Manager
// Week 3: Class implementation
// Date: 11/29/2025

using System;

namespace GameModManager.Core
{
    public class LogEntry
    {
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string Message { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Severity { get; set; } = "Info";

        public override string ToString()
        {
            return $"[{TimeStamp:G}] [{Severity}] ({Category}) {Message}";
        }
    }
}
