using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace TestUnitairesCore
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestBetterDefence()
        {
            Map map = new Map(new StandardMap());
            Unit orc = new Orc(map.getCoord(0, 0),TileType.DEFAULT);
            Unit elf = new Elf(map.getCoord(0, 0),TileType.DEFAULT);
            Assert.IsTrue(elf.betterDefence(orc));
        }

        [TestMethod]
        public void TestCanMoveElf()
        {
            Coordinate coord1 = new Coordinate(0,1);
            Coordinate coord2 = new Coordinate(0,3);
            Coordinate coord3 = new Coordinate(1, 1);

            Unit elf = new Elf(new Coordinate(0,0), TileType.DEFAULT);
            Assert.IsFalse(elf.canMove(coord1, TileType.WATER));
            Assert.IsTrue(elf.canMove(coord1, TileType.MOUNTAIN));
            Assert.IsFalse(elf.canMove(coord2, TileType.PLAIN));
            Assert.IsFalse(elf.canMove(coord3, TileType.FOREST));
        }

        [TestMethod]
        public void TestCanMoveOrc()
        {
            Coordinate coord1 = new Coordinate(0, 2);
            Coordinate coord2 = new Coordinate(0, 4);
            Coordinate coord3 = new Coordinate(1, 1);

            Unit orc = new Orc(new Coordinate(0, 0), TileType.DEFAULT);
            Assert.IsFalse(orc.canMove(coord1, TileType.WATER));
            Assert.IsTrue(orc.canMove(coord1, TileType.MOUNTAIN));
            Assert.IsTrue(orc.canMove(coord2, TileType.PLAIN));
            Assert.IsFalse(orc.canMove(coord2, TileType.FOREST));
            Assert.IsFalse(orc.canMove(coord3, TileType.FOREST));
        }

        [TestMethod]
        public void TestCanMoveHuman()
        {
            Coordinate coord1 = new Coordinate(0, 2);
            Coordinate coord2 = new Coordinate(0, 4);
            Coordinate coord3 = new Coordinate(1, 1);

            Unit human = new Human(new Coordinate(0, 0), TileType.DEFAULT);
            Assert.IsTrue(human.canMove(coord1, TileType.WATER));
            Assert.IsTrue(human.canMove(coord1, TileType.MOUNTAIN));
            Assert.IsFalse(human.canMove(coord2, TileType.FOREST));
            Assert.IsFalse(human.canMove(coord3, TileType.FOREST));
        }

        [TestMethod]
        public void TestRatioLifePoints()
        {
            Unit elf = new Elf(new Coordinate(0, 0), TileType.DEFAULT);
            elf.looseLifePoints(6);
            double truc = elf.getRatioLifePoints();
            Assert.AreEqual(elf.getRatioLifePoints(), 0.5);
        }

        [TestMethod]
        public void TestMove()
        {
            Coordinate coord0 = new Coordinate(0, 0);
            Coordinate coord1 = new Coordinate(0, 2);
            Coordinate coord2 = new Coordinate(0, 4);

            // Possible movement
            Unit orc1 = new Orc(coord0, TileType.DEFAULT);
            orc1.move(coord1, TileType.MOUNTAIN);

            Assert.AreEqual(orc1.coord, coord1);
            Assert.AreEqual(orc1.Points.movePoints,0);

            Assert.AreEqual(2, orc1.Points.victoryPoints);

            // Impossible movement
            Unit orc2 = new Orc(coord0, TileType.DEFAULT);
            orc2.move(coord2, TileType.DEFAULT);
            Assert.AreEqual(orc2.coord, coord0);
            Assert.AreEqual(orc2.Points.movePoints, 2);
            Assert.AreEqual(0, orc2.Points.victoryPoints);
        }

        [TestMethod]
        public void TestCanAttack()
        {
            // TO DO
        }

        [TestMethod]
        public void TestAttack()
        {
            // TO DO
        }
    }
}
