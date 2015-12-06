using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace TestUnitairesCore
{
    
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestGetUnitsOnTile()
        {
            Player p1 = new Player(Race.Human, "Robert", 4);
            Player p2 = new Player(Race.Elf, "Gaston", 4);
            List<Player> players = new List<Player>{p1,p2};

            Game game = new Game(new StandardMap(), players);

            Player currentPlayer = game.CurrentPlayer;
            game.move(0,0);

            List<Unit> unitsOnTile = currentPlayer.getUnitsOnTile(game.Map.getCoord(0,0));

            Assert.IsTrue(unitsOnTile.Contains(game.CurrentPlayer.CurrentUnit));
        }
    }
}
