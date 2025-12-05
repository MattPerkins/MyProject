// Matthew Perkins
// SDC320 - Game Mod Manager
// Week 3: Class implementation
// Date: 11/29/2025

using System;
using System.Collections.Generic;
using System.Linq;

namespace GameModManager.Core
{
    public class GameLibrary
    {
        public List<Game> Games { get; } = new List<Game>();

        public void AddGame(Game game)
        {
            if (game == null) throw new ArgumentNullException(nameof(game));
            Games.Add(game);
        }

        public bool RemoveGame(int gameId)
        {
            var game = FindGameById(gameId);
            if (game == null)
            {
                return false;
            }

            Games.Remove(game);
            return true;
        }

        public Game? FindGameById(int id)
        {
            return Games.FirstOrDefault(g => g.GameId == id);
        }

        public Game? FindGameByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return null;
            }

            return Games.FirstOrDefault(g =>
                string.Equals(g.Title, title, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Game> GetAllGames()
        {
            return Games;
        }
    }
}
