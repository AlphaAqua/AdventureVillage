using AdventureVillageLibrary.Game;
using Microsoft.AspNetCore.Components;

namespace AdventureVillageWebApp.Pages
{
    public partial class NewGameView
    {
        [Inject]
        public GameManager MyGameManager { get; set; } = null!;

        public string gameName = "MyGame";

        public void HandleNewGameSubmission()
        {
            if (!string.IsNullOrWhiteSpace(gameName))
            {
                MyGameManager.NewGame(gameName);
                StateHasChanged();
            }
        }
    }
}
