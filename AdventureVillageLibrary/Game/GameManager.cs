using AdventureVillageLibrary.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdventureVillageLibrary.Game
{
    public class GameManager
    {
        public Game? Game { get; private set; }
        public Owner Player { get; init; }

        public void NewGame(string gameName, Owner player)
        {
            Game = new Game(gameName);
        }

        public string GetGameState()
        {
            string json = JsonSerializer.Serialize(Game);
            return json;
        }

        public void SetGameState(string json, Owner player)
        {
            Game = JsonSerializer.Deserialize<Game>(json);
        }
    }
}
