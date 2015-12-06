using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace TestUnitairesCore
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void TestGetCoord()
        {
            Map map = new Map(new StandardMap());
            Coordinate coord = map.getCoord(0, 0);
            Assert.AreEqual(coord.X, 0);
            Assert.AreEqual(coord.Y, 0);
            Assert.IsTrue(map.matrix.ContainsKey(coord));
        }

        [TestMethod]
        public void TestGetTile()
        {
            Map map = new Map(new StandardMap());
            Coordinate coord = new Coordinate(10, 10);
            map.matrix.Add(coord, TileType.WATER);
          
            TileType tile = map.getTile(coord);
            Assert.AreEqual(tile, TileType.WATER);
        
        }

        [TestMethod]
        public void TestInitialiseTiles()
        {
            Map map = new Map(new StandardMap());
            map.initialiseTiles();
            int water = 0, plain=0, forest=0, mountain=0;
            foreach (Coordinate c in map.matrix.Keys)
            {
                switch(map.matrix[c])
                {
                    case TileType.WATER :
                        water++;
                        break;
                    case TileType.PLAIN:
                        plain++;
                        break;
                    case TileType.FOREST:
                        forest++;
                        break;
                    case TileType.MOUNTAIN:
                        mountain++;
                        break;
                }
            }
            Assert.AreEqual(plain, water);
            Assert.AreEqual(plain, mountain);
            Assert.AreEqual(plain, forest);
            Assert.AreEqual(water, mountain);
            Assert.AreEqual(water, forest);
            Assert.AreEqual(mountain, forest);
        }

    }
}
