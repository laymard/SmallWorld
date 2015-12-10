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

        /// <summary>
        /// [R21_9_CHEAT_MODE]
        /// </summary>
        [TestMethod]
        public void TestUndoLastCommand()
        {

            NewGameBuilder builder = new NewGameBuilder(new DemoMap());

            builder.buildGame();

            Game game = builder.Game;

            game.AddPlayer(Race.Human, "Player 1", 4);
            game.AddPlayer(Race.Orc, "Player 2", 4);

            Player p1 = game.Players[0];
            Player p2 = game.Players[1];

            game.StartGame();

            Coordinate coord = new Coordinate(p1.Units[0].coord.X, p1.Units[0].coord.Y);
            Coordinate coordTarget = new Coordinate(coord.X + 1, coord.Y);

            p1.CurrentUnit = p1.Units[0];
            p1.move(coordTarget, game.Map.getTile(coordTarget));

            p1.undoLastCommand();

            Assert.AreEqual(coord, p1.Units[0].coord);
            Assert.AreEqual(p1.Units[0].Points.MovePoints, 2);
            
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
        /// <summary>
        /// [R22_6_MOVE_POINTS_TURN]
        /// </summary>
        [TestMethod]
        public void TestFinishMoves()
        {
            List<Coordinate> map = new List<Coordinate>();
            List<TileType> tt = new List<TileType>() { TileType.MOUNTAIN,TileType.FOREST,TileType.PLAIN,TileType.WATER };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    map.Add(new Coordinate(i, j));

                }
            }

            Player p = new Player(Race.Human, "Gaston", 4);

            for (int i = 0; i < p.Units.Capacity; i++)
            {
                p.createUnit(map[i],tt[i%4]);
                p.selectUnit(p.Units[i]);
                p.move(map[i + 4], tt[i]);
            }
            p.finishMoves();

            foreach (Unit unit in p.Units)
            {
                Assert.AreEqual(unit.Points.MovePoints, 2);
            }

            Assert.AreEqual(p.VictoryPoints, 4);
        }

    }
}
