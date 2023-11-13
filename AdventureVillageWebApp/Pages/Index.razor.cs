using Microsoft.AspNetCore.Components;
using AdventureVillageLibrary.GameObjects;
using AdventureVillageLibrary.Game;
using Blazored.LocalStorage;
using System.Xml.Linq;

namespace AdventureVillageWebApp.Pages
{
    public enum ViewsName
    {
        General,
        Buildings,
        Adventurers
    }

    public partial class Index
    {
        [Inject]
        public GameManager MyGameManager { get; set; } = null!;

        [Inject]
        private ILocalStorageService LocalStorage { get; set; } = null!;


        private Timer? timer;

        private string localStoragePlayerUniqueIdentifierKey = "PlayerUniqueIdentifier";
        private string localStorageGameKey = "Game";
        public string PlayerID= "";

        public ViewsName CurrentView = ViewsName.General;

        protected override async Task OnInitializedAsync()
        {
            await FetchPlayerInfo();
            timer = new Timer(_ => StateHasChanged(), null, 0, 1000); // Updates every second (1000 ms)
        }

        public void Dispose()
        {
            HandleSaveGame();
            timer?.Dispose();
        }

        private async Task FetchPlayerInfo()
        {
            PlayerID = await LocalStorage.GetItemAsync<string>(localStoragePlayerUniqueIdentifierKey) ?? await NewPlayerInfo();
        }

        private async Task<string> NewPlayerInfo()
        {
            PlayerID = Guid.NewGuid().ToString();
            await LocalStorage.SetItemAsync<string>(localStoragePlayerUniqueIdentifierKey, PlayerID);
            return PlayerID;
        }

        private void SelectView(ViewsName view)
        {
            CurrentView = view;
        }

        private string GetItemView(ViewsName viewName)
        {
            return CurrentView == viewName ? "active-view" : "button";
        }

        public bool GameExist()
        {
            return MyGameManager.Game != null;
        }

        public string GameTime()
        {
            TimeSpan timeSpan = TimeSpan.FromMinutes(MyGameManager.Game?.GameTime ?? 0);
            return $"{(int)timeSpan.TotalDays}d {timeSpan.Hours}h {timeSpan.Minutes}m";
        }

        public bool GameIsRunning()
        {
            return MyGameManager.Game?.IsRunning() ?? false;
        }

        public bool GameIsRunningDegraded()
        {
            return MyGameManager.Game?.IsDegraded() == true && MyGameManager.Game?.IsRunning() == true;
        }

        public void HandleStartGame()
        {
            MyGameManager.Game?.StartRunning();
        }

        public void HandleStopGame()
        {
            MyGameManager.Game?.StopRunning();
        }

        public async void HandleSaveGame()
        {
            if (MyGameManager.Game != null)
            {
                bool running = GameIsRunning();
                HandleStopGame();
                string gameData = MyGameManager.GetGameData();
                await LocalStorage.SetItemAsync<string>(localStorageGameKey, gameData);
                if (running) { HandleStartGame(); }
            }
        }

        public async void HandleLoadGame()
        {
            HandleStopGame();
            string gameData = await LocalStorage.GetItemAsync<string>(localStorageGameKey);
            if (!string.IsNullOrEmpty(gameData) && !string.IsNullOrEmpty(PlayerID))
            {
                MyGameManager.LoadGame(gameData, PlayerID);
            }
        }

    }

}
