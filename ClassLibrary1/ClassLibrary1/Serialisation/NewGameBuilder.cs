using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class NewGameBuilder : GameBuilder
    {
        public NewGameBuilder(MapSize ms)
            : base()
        {
            this.Ms = ms;
        }
        public MapSize Ms
        {
            get;
            set;
        }
        public override void buildGame()
        {
            this.initializeMap(this.Ms);
        }

        /// <summary>
        /// Initialisation de la carte à partir des caractéristiques du mode de jeu contenues dans la MapSize ms.
        /// </summary>
        public void initializeMap(MapSize ms)
        {
            this.Game.Map = new Map(ms);
            this.Game.Map.initialiseTiles();
            this.Game.Players = new List<Player>(ms.NbPlayers);
            this.Game.TurnsLeft = ms.NbTurns;
        }
    }
}
