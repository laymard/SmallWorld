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
            Coordinate coord1 = new Coordinate(0, 1);
            Coordinate coord2 = new Coordinate(0, 2);

            Unit orc = new Orc(new Coordinate(0, 0), TileType.DEFAULT);

            Assert.IsTrue(orc.canMove(coord1, TileType.FOREST));
            Assert.IsFalse(orc.canMove(coord1, TileType.FOREST));
            Assert.IsTrue(orc.canMove(coord1, TileType.PLAIN));
            Assert.IsFalse(orc.canMove(coord2, TileType.FOREST));
        }

        [TestMethod]
        public void TestCanMoveHuman()
        {
            Coordinate coord1 = new Coordinate(0, 1);
            Coordinate coord2 = new Coordinate(4, 4);

            Unit human = new Human(new Coordinate(0, 0), TileType.DEFAULT);

            Assert.IsTrue(human.canMove(coord1, TileType.WATER));
            Assert.IsTrue(human.canMove(coord1, TileType.MOUNTAIN));
            Assert.IsFalse(human.canMove(coord2, TileType.FOREST));
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
            Coordinate coord1 = new Coordinate(0, 1);
            Coordinate coord2 = new Coordinate(3, 3);

            Unit elf = new Elf(coord0, TileType.DEFAULT);
            
            elf.move(coord1, TileType.FOREST);

            Assert.AreEqual(elf.coord, coord1);
            Assert.AreEqual(3, elf.Points.victoryPoints);
        }

        [TestMethod]
        public void TestCanAttackElf()
        {
            Coordinate coord0 = new Coordinate(0, 0);
            Coordinate coord1 = new Coordinate(0, 1);
            Coordinate coord2 = new Coordinate(0, 2);
            Coordinate coord3 = new Coordinate(0, 3);

            Unit elf = new Elf(coord0,TileType.DEFAULT);
            Assert.IsTrue(elf.canAttack(coord1, TileType.DEFAULT));
            Assert.IsTrue(elf.canAttack(coord2, TileType.DEFAULT));
            Assert.IsFalse(elf.canAttack(coord3, TileType.DEFAULT));
        }

        [TestMethod]
        public void TestCanAttackHuman()
        {
            Coordinate coord0 = new Coordinate(0, 0);
            Coordinate coord1 = new Coordinate(0, 1);
            Coordinate coord2 = new Coordinate(0, 2);
            

            Unit human = new Human(coord0, TileType.DEFAULT);
            Assert.IsTrue(human.canAttack(coord1, TileType.DEFAULT));
            Assert.IsFalse(human.canAttack(coord2, TileType.DEFAULT));
        }


        [TestMethod]
        public void TestCanAttackOrc()
        {
            Coordinate coord0 = new Coordinate(0, 0);
            Coordinate coord1 = new Coordinate(0, 1);
            Coordinate coord2 = new Coordinate(0, 2);
            Coordinate coord3 = new Coordinate(0, 3);


            Unit orc1 = new Orc(coord0, TileType.DEFAULT);
            Assert.IsTrue(orc1.canAttack(coord1, TileType.DEFAULT));
            Assert.IsFalse(orc1.canAttack(coord2, TileType.DEFAULT));

            Unit orc2 = new Orc(coord0, TileType.MOUNTAIN);
            Assert.IsTrue(orc2.canAttack(coord1, TileType.DEFAULT));
            Assert.IsTrue(orc2.canAttack(coord2, TileType.DEFAULT));
            Assert.IsFalse(orc2.canAttack(coord3, TileType.DEFAULT));
        }
    }
}
