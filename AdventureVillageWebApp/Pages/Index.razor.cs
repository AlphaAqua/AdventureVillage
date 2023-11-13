using Microsoft.AspNetCore.Components;
using AdventureVillageLibrary;
using AdventureVillageLibrary.Game;

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

        private Timer? timer;

        public ViewsName CurrentView = ViewsName.General;

        protected override void OnInitialized()
        {
            timer = new Timer(_ => StateHasChanged(), null, 0, 1000); // Updates every second (1000 ms)
        }

        public void Dispose()
        {
            timer?.Dispose();
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

        public void StartGame()
        {
            MyGameManager.Game?.StartRunning();
        }

        public void StopGame()
        {
            MyGameManager.Game?.StopRunning();
        }

        public void SaveGame()
        {

        }
    }

}
