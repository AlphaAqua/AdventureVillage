using System.Collections;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;
using AdventureVillageLibrary.GameObjects;

namespace AdventureVillageLibrary.Game
{
    [Serializable]
    public class Game
    {
        private bool _running = false;
        private Task? _runningTask;
        private const int _interval = 1000;
        private int _nextIterval = _interval;

        private Owner? defaultOwner;

        public string Name { get; } = string.Empty;
        public long GameTime { get; private set; } = 0;

        public Dictionary<Guid, GameObject> GameObjects { get; private set; } = new Dictionary<Guid, GameObject>();

        public List<Village> Villages { get; } = new List<Village>();
        public List<Territory> Territories { get; } = new List<Territory>();

        ////////////////////////////////////

        internal Game() { }

        internal Game(string name, Owner? player = null)
        {
            // New Game Logic
            Name = name;
            defaultOwner = player;

            // Add random territories
            for (int i = 0; i < 10; i++)
            {
                Territory newTerr = new Territory();
                Territories.Add(newTerr);
                AddGameObject(newTerr);
            }
        }

        public bool IsRunning()
        {
            return _running;
        }

        public bool IsDegraded()
        {
            return _nextIterval > _interval;
        }

        public void StartRunning()
        {
            // Only start a new running loop if one isn't already running
            if (_runningTask == null || _runningTask.IsCompleted)
            {
                _running = true;
                _runningTask = RunLoop();
            }
        }

        public void StopRunning()
        {
            _running = false;
        }

        private async Task RunLoop()
        {
            while (_running)
            {
                var watch = Stopwatch.StartNew();

                int result = await Run(_nextIterval);

                watch.Stop();
                int elapsed = (int)watch.ElapsedMilliseconds;
                int delay = _interval - elapsed;

                if (delay > 0)
                {
                    _nextIterval = _interval + (_nextIterval - _interval) / 2;
                }
                else
                {
                    _nextIterval *= 2;
                }

                await Task.Delay(_nextIterval);
                GameTime += 1;
            }
        }

        public async Task<int> Run(int durationMs)
        {

            return durationMs;
        }


        //////////////////////////////////

        
        private void AddGameObject(GameObject gameObject)
        {
            GameObjects[gameObject.ID] = gameObject;
        }

        public T? RetrieveGameObject<T>(Guid id)
            where T : GameObject
        {
            if (GameObjects.TryGetValue(id, out var gameObj) && gameObj is T tObject)
            {
                return tObject;
            }
            return null;
        }

        public T? RetrieveGameObject<T>(GameObject gameObject)
            where T : GameObject
        {
            if (GameObjects.TryGetValue(gameObject.ID, out var gameObj) && gameObj is T tObject)
            {
                return tObject;
            }
            return null;
        }

        public Village? GetVillage(Owner owner)
        {
            return Villages.Where(v => v.Owner == owner).First();
        }

        //////////////////////////////////

        /// <summary>
        /// Set the default Owner for actions to the player
        /// </summary>
        /// <param name="player"></param>
        /// <returns>
        ///   true if the player already existed in the Game
        ///   false if this is a new player, in which case it will have beed added to the game.
        /// </returns>
        public bool SetPlayer(Owner player)
        {
            Owner? foundPlayer = RetrieveGameObject<Owner>(player);
            if (foundPlayer != null)
            {
                defaultOwner = foundPlayer;
                return true;
            }
            else
            {
                defaultOwner = player;
                AddGameObject(defaultOwner);
                return false;
            }
        }
    }
}