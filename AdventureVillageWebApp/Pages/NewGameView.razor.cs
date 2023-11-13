using AdventureVillageLibrary.Game;
using AdventureVillageLibrary.GameObjects;
using Microsoft.AspNetCore.Components;

namespace AdventureVillageWebApp.Pages
{
    public partial class NewGameView
    {
        [Inject]
        public GameManager MyGameManager { get; set; } = null!;

        [Parameter]
        public string Player { get; set; } = null!;

        private string playerName = "Player";

        public string gameName = "MyGame";


        public void HandleNewGameSubmission()
        {
            if (!string.IsNullOrWhiteSpace(gameName))
            {
                MyGameManager.NewGame(gameName, Player, playerName, "123");
                StateHasChanged();
            }
        }
    }
}
