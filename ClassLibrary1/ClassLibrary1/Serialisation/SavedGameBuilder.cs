using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class SavedGameBuilder : GameBuilder
    {
        public String path;
        public SavedGameBuilder(String path)
            : base()
        {
            this.path = path;
        }

        public override void buildGame()
        {
            GameSaver gs = GameSaver.ChargeGame(path);
            this.Game = new Game(gs);
        }
    }
}
