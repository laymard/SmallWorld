using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    [Serializable()]
    public class StandardMap : MapSize
    {
        public StandardMap()
        
        {
            this.NbPlayers = 2;
            this.NbTiles = 14;
            this.NbTurns = 30;
            this.NbUnits = 8;
        }
    }
}
