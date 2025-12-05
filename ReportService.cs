// Matthew Perkins
// SDC320 - Game Mod Manager
// Week 3: Class implementation
// Date: 11/29/2025

using System;
using System.Text;

namespace GameModManager.Core
{
    public class ReportService
    {
        public string BuildModReport(Game game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));

            var sb = new StringBuilder();

            sb.AppendLine($"Game: {game.Title}");
            sb.AppendLine($"Install folder: {game.InstallPath}");
            sb.AppendLine($"Total mods: {game.Mods.Count}");
            sb.AppendLine();

            if (game.Mods.Count == 0)
            {
                sb.AppendLine("No mods found.");
            }
            else
            {
                sb.AppendLine("Mods:");

                foreach (var mod in game.Mods)
                {
                    sb.AppendLine($"  Name: {mod.Name}");
                    sb.AppendLine($"  Version: {mod.Version}");
                    sb.AppendLine($"  Enabled: {mod.IsEnabled}");
                    sb.AppendLine($"  Install location: {mod.InstallLocation}");

                    if (!string.IsNullOrWhiteSpace(mod.Description))
                    {
                        sb.AppendLine($"  Description: {mod.Description}");
                    }

                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        public void SaveModReportToFile(Game game, string filePath)
        {
            string report = BuildModReport(game);
            System.IO.File.WriteAllText(filePath, report);
        }
    }
}
