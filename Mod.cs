// Matthew Perkins
// SDC320 - Game Mod Manager
// Week 3: Class implementation
// Date: 11/29/2025

namespace GameModManager.Core
{
    public class Mod
    {
        public int ModId { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string InstallLocation { get; set; } = string.Empty;
        public bool IsEnabled { get; private set; }

        public Mod()
        {
        }

        public Mod(int modId, int gameId, string name, string installLocation)
        {
            ModId = modId;
            GameId = gameId;
            Name = name;
            InstallLocation = installLocation;
        }

        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }

        public override string ToString()
        {
            string status = IsEnabled ? "Enabled" : "Disabled";
            string versionText = string.IsNullOrWhiteSpace(Version) ? string.Empty : $" v{Version}";
            return $"{Name}{versionText} - {status}";
        }
    }
}
