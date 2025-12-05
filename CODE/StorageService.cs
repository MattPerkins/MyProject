// Matthew Perkins
// SDC320 - Game Mod Manager
// Week 3: Class implementation
// Date: 11/29/2025

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GameModManager.Core
{
    public class StorageService
    {
        public string StorageFilePath { get; }

        public StorageService(string storageFilePath)
        {
            StorageFilePath = storageFilePath;
        }

        public GameLibrary LoadLibrary()
        {
            if (!File.Exists(StorageFilePath))
            {
                return new GameLibrary();
            }

            string json = File.ReadAllText(StorageFilePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new GameLibrary();
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            GameLibraryDto? dto = JsonSerializer.Deserialize<GameLibraryDto>(json, options);

            return dto?.ToDomain() ?? new GameLibrary();
        }

        public void SaveLibrary(GameLibrary library)
        {
            var dto = GameLibraryDto.FromDomain(library);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(dto, options);

            string? directory = Path.GetDirectoryName(StorageFilePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(StorageFilePath, json);
        }

        // DTO classes used only for JSON serialization

        private class GameLibraryDto
        {
            public List<GameDto> Games { get; set; } = new List<GameDto>();

            public static GameLibraryDto FromDomain(GameLibrary library)
            {
                var dto = new GameLibraryDto();

                foreach (var game in library.Games)
                {
                    dto.Games.Add(GameDto.FromDomain(game));
                }

                return dto;
            }

            public GameLibrary ToDomain()
            {
                var library = new GameLibrary();

                foreach (var gameDto in Games)
                {
                    library.AddGame(gameDto.ToDomain());
                }

                return library;
            }
        }

        private class GameDto
        {
            public int GameId { get; set; }
            public string Title { get; set; } = string.Empty;
            public string InstallPath { get; set; } = string.Empty;
            public string Notes { get; set; } = string.Empty;
            public List<ModDto> Mods { get; set; } = new List<ModDto>();

            public static GameDto FromDomain(Game game)
            {
                return new GameDto
                {
                    GameId = game.GameId,
                    Title = game.Title,
                    InstallPath = game.InstallPath,
                    Notes = game.Notes,
                    Mods = game.Mods.Select(ModDto.FromDomain).ToList()
                };
            }

            public Game ToDomain()
            {
                var game = new Game(GameId, Title, InstallPath)
                {
                    Notes = Notes
                };

                foreach (var modDto in Mods)
                {
                    game.AddMod(modDto.ToDomain());
                }

                return game;
            }
        }

        private class ModDto
        {
            public int ModId { get; set; }
            public int GameId { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Version { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string InstallLocation { get; set; } = string.Empty;
            public bool IsEnabled { get; set; }

            public static ModDto FromDomain(Mod mod)
            {
                return new ModDto
                {
                    ModId = mod.ModId,
                    GameId = mod.GameId,
                    Name = mod.Name,
                    Version = mod.Version,
                    Description = mod.Description,
                    InstallLocation = mod.InstallLocation,
                    IsEnabled = mod.IsEnabled
                };
            }

            public Mod ToDomain()
            {
                var mod = new Mod(ModId, GameId, Name, InstallLocation)
                {
                    Version = Version,
                    Description = Description
                };

                if (IsEnabled)
                {
                    mod.Enable();
                }

                return mod;
            }
        }
    }
}
