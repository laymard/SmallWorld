using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Game
    {
        /// <summary>
        /// Map configurations of the game.
        /// </summary>
        private int map;
        /// <summary>
        /// Table of players.
        /// </summary>
        private Player[] players;
        /// <summary>
        /// Number of turns left before the end of the game.
        /// </summary>
        private int nbTurnsLeft;
        /// <summary>
        /// Currently playing player.
        /// </summary>
        private Player currentPlayer;

        public void initialiseMap()
        {
            throw new System.NotImplementedException();
        }

        public void initialisePlayer()
        {
            throw new System.NotImplementedException();
        }
    }
}
