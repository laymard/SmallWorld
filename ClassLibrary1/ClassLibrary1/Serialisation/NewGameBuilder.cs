using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class NewGameBuilder : GameBuilder
    {
        public NewGameBuilder(MapSize ms, String name1, Race race1, String name2, Race race2)
            : base()
        {
            this.Ms = ms;
            this.Game.Players = new List<Player>(this.Ms.NbPlayers);
            this.Game.AddPlayer(race1, name1, ms.NbUnits);
            this.Game.AddPlayer(race2, name2, ms.NbUnits);
        }
        public MapSize Ms
        {
            get;
            set;
        }
        public override void buildGame()
        {
            this.initializeMap();
            this.Game.StartGame();
        }

        /// <summary>
        /// Initialisation de la carte à partir des caractéristiques du mode de jeu contenues dans la MapSize ms.
        /// </summary>
        public void initializeMap()
        {
            this.Game.Map = new Map(this.Ms);
            this.Game.Map.initialiseTiles();
            this.Game.TurnsLeft = this.Ms.NbTurns;
        }
    }
}
