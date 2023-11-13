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
        public Owner? Player { get; private set; }

        public void NewGame(string gameName, string playerID, string playerName, string playerSecret)
        {
            Game = new Game(gameName);
            Guid playerGuid = new Guid(playerID);
            Game.NewPlayer(playerGuid, playerName, playerSecret);
        }

        public void LoadGame(string gameData, string playerID)
        {
            Game? game = JsonSerializer.Deserialize<Game>(gameData);
            if (game != null)
            {
                Guid playerGuid = new Guid(playerID);
                Player = game.RetrieveGameObject<Owner>(playerGuid);
                Game = game;
                game.SetPlayer(playerGuid);
            }
        }

        public string GetGameData()
        {
            return JsonSerializer.Serialize(Game);
        }
    }
}
