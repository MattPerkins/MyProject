// Matthew Perkins
// SDC320 - Game Mod Manager
// Week 3: Class implementation
// Date: 11/29/2025

using System;
using System.Collections.Generic;
using System.Linq;

namespace GameModManager.Core
{
    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string InstallPath { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public List<Mod> Mods { get; } = new List<Mod>();

        public Game()
        {
        }

        public Game(int id, string title, string installPath)
        {
            GameId = id;
            Title = title;
            InstallPath = installPath;
        }

        public void AddMod(Mod mod)
        {
            if (mod == null) throw new ArgumentNullException(nameof(mod));

            if (mod.GameId == 0)
            {
                mod.GameId = GameId;
            }

            Mods.Add(mod);
        }

        public bool RemoveMod(int modId)
        {
            var mod = Mods.FirstOrDefault(m => m.ModId == modId);
            if (mod == null)
            {
                return false;
            }

            Mods.Remove(mod);
            return true;
        }

        public Mod? FindModById(int modId)
        {
            return Mods.FirstOrDefault(m => m.ModId == modId);
        }

        public void EnableAllMods()
        {
            foreach (var mod in Mods)
            {
                mod.Enable();
            }
        }

        public void DisableAllMods()
        {
            foreach (var mod in Mods)
            {
                mod.Disable();
            }
        }

        public override string ToString()
        {
            return $"{Title} (Mods: {Mods.Count})";
        }
    }
}
