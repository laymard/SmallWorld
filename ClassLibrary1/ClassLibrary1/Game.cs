using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Game
    {
        /// <summary>
        /// Number of turns left before the end of the game.
        /// </summary>
        private int nbTurnsLeft;
        /// <summary>
        /// Currently playing player.
        /// </summary>
        private Player currentPlayer;

        public Map Map
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ClassLibrary1.Player[] Player
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void initialiseMap()
        {
            throw new System.NotImplementedException();
        }

        public void initialisePlayer()
        {
            throw new System.NotImplementedException();
        }

        public void changePlayer()
        {
            throw new System.NotImplementedException();
        }

        public void end()
        {
            throw new System.NotImplementedException();
        }
    }
}
