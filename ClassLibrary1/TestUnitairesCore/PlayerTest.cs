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
            Coordinate coord0 = new Coordinate(0,0);

            // initialisation du joueur et ses unités
            Player p = new Player(Race.Human, "Robert", 4);
            for (int i = 0; i < p.NbUnits; i++)
            {
                p.createUnit(coord0, TileType.WATER);
            }

            List<Unit> unitsOnTile = p.getUnitsOnTile(coord0);

            // Tests
            Assert.AreEqual(p.NbUnits,unitsOnTile.Count);

            for (int i = 0 ; i < unitsOnTile.Count ; i++ )
            {
                Assert.IsTrue(unitsOnTile.Contains(p.Units[i]));
            }
        }

        [TestMethod]
        public void TestUndoLastCommand()
        {
        }

        [TestMethod]
        public void TestMoveHuman()
        {
            Coordinate coord0 = new Coordinate(0, 0);
            Coordinate coord1 = new Coordinate(0, 1);
            Coordinate coord2 = new Coordinate(4, 4);

            Player p = new Player(Race.Human, "Gaston", 4);
            p.createUnit(coord0, TileType.FOREST);
            p.selectUnit(p.Units[0]);

            // Mouvement possible
            p.move(coord1, TileType.WATER);

            Assert.AreEqual(coord1, p.CurrentUnit.coord);
            Assert.AreEqual(1, p.CurrentUnit.Points.MovePoints);

            // Mouvement impossible
            p.move(coord1, TileType.WATER);

            Assert.AreEqual(coord1, p.CurrentUnit.coord);
            Assert.AreEqual(1, p.CurrentUnit.Points.MovePoints);
        }

        [TestMethod]
        public void TestIsDead(){
            Player p = new Player(Race.Human, "Gaston", 4);

            for (int i = 0; i < 4; i++)
            {
                p.createUnit(new Coordinate(0, 0), TileType.FOREST);
                p.Units[i].Points.lifePoints = 0;
            }

            Assert.IsTrue(p.IsDead());

            p.Units[0].Points.lifePoints = 1;
            Assert.IsFalse(p.IsDead());

        }

    }
}
