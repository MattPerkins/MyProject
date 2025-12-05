// Matthew Perkins
// SDC320 - Game Mod Manager
// Week 3: Class implementation
// Date: 11/29/2025

using System;
using System.Collections.Generic;

namespace GameModManager.Core
{
    public class Logger
    {
        private readonly List<LogEntry> _entries = new List<LogEntry>();

        public IReadOnlyList<LogEntry> Entries => _entries;

        public void AddInfo(string message, string category = "")
        {
            Add("Info", message, category);
        }

        public void AddWarning(string message, string category = "")
        {
            Add("Warning", message, category);
        }

        public void AddError(string message, string category = "")
        {
            Add("Error", message, category);
        }

        private void Add(string severity, string message, string category)
        {
            var entry = new LogEntry
            {
                Severity = severity,
                Message = message,
                Category = category,
                TimeStamp = DateTime.Now
            };

            _entries.Add(entry);
        }

        public IEnumerable<LogEntry> GetEntries()
        {
            return _entries;
        }

        public void Clear()
        {
            _entries.Clear();
        }
    }
}
