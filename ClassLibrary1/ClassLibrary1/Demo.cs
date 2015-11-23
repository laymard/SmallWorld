using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class DemoMap : MapSize
    {
        public DemoMap()
        {
            this.NbPlayers = 2;
            this.NbTiles = 10;
            this.NbTurns = 20;
            this.NbUnits = 6;
        }
    }
}
