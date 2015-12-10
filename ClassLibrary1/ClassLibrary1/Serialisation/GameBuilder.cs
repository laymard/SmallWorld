using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public abstract class GameBuilder
    {
        public GameBuilder()
        {
            Game = new Game();
        }
        public Game Game
        {
            get;
            set;
        }

        public abstract void buildGame();
    }
}
