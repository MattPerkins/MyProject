// Matthew Perkins
// SDC320 - Game Mod Manager
// Week 3: Demo program
// Date: 11/29/2025

using System;
using GameModManager.Core;

namespace GameModManager.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            var library = new GameLibrary();

            // Create a sample game
            var game = new Game(1, "Example Game", @"C:\Games\ExampleGame")
            {
                Notes = "Demo game for testing."
            };

            // Create a sample mod
            var mod1 = new Mod(1, game.GameId, "High Resolution Textures",
                @"C:\Games\ExampleGame\Mods\HiRes")
            {
                Version = "1.0",
                Description = "Improves texture quality."
            };

            mod1.Enable();
            game.AddMod(mod1);
            library.AddGame(game);

            logger.AddInfo($"Added game {game.Title}", "Game");
            logger.AddInfo($"Added mod {mod1.Name}", "Mod");

            // Build a report
            var reportService = new ReportService();
            string report = reportService.BuildModReport(game);

            Console.WriteLine("Games in library:");
            foreach (var g in library.GetAllGames())
            {
                Console.WriteLine(g);
            }

            Console.WriteLine();
            Console.WriteLine("Report:");
            Console.WriteLine(report);

            Console.WriteLine("Log entries:");
            foreach (var entry in logger.GetEntries())
            {
                Console.WriteLine(entry);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
