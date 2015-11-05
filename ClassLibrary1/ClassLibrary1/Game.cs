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
        private List<Player> players;

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

        public Stratege Stratege
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void initializeMap()
        {
            throw new System.NotImplementedException();
        }

        public void initializePlayer()
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

        /// <summary>
        /// vérifie que les deux joueurs ont choisi deux races différentes.
        /// </summary>
        public void checkRaces()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// initialise le premier joueur
        /// </summary>
        public void setFirstPlayer()
        {
            throw new System.NotImplementedException();
        }
    }
}
