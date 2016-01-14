using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable()]
    public class SmallMap : MapSize
    {
            public SmallMap()
            {
                this.NbPlayers = 2;
                this.NbTiles = 10;
                this.NbTurns = 20;
                this.NbUnits = 6;
            }
    }
}
