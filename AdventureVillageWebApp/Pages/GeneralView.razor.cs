using AdventureVillageLibrary.Game;
using Microsoft.AspNetCore.Components;

namespace AdventureVillageWebApp.Pages
{
    public partial class GeneralView
    {
        [Inject]
        public GameManager MyGameManager { get; set; } = null!;

        private Game? MyGame;

        protected override void OnInitialized()
        {
            MyGame = MyGameManager.Game;
        }

        public string MainVillageName()
        {
            return MyGame?.MainVillage?.Name ?? "";
        }

        public int NumberOfTerritories()
        {
            return MyGame?.Territories.Count ?? 0;
        }
    }
}
