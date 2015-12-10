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
            map.initialiseTiles();
            Coordinate coord = map.getCoord(0, 0);
            Assert.AreEqual(coord.X, 0);
            Assert.AreEqual(coord.Y, 0);
            Assert.IsTrue(map.matrix.ContainsKey(coord));
        }

        [TestMethod]
        public void TestGetTile()
        {
            Map map = new Map(new StandardMap());

            Coordinate coord1 = new Coordinate(10,10);
            Coordinate coord2 = new Coordinate(0, 0);

            map.matrix.Add(coord1, TileType.WATER);
          
            // Si la case coord existe getTile doit retourner le type de case
            TileType tile1 = map.getTile(coord1);
            Assert.AreEqual(TileType.WATER,tile1);

            // sinon getTile retourne le type DEFAULT
            TileType tile2 = map.getTile(coord2);
            Assert.AreEqual(TileType.DEFAULT, tile2);
        }

        /// <summary>
        /// [R23_2_MAP_TILES]
        /// [R23_3_MAP_INITIALISATION]
        /// </summary>
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

            // Il doit y avoir autant de cases de chaque type
            Assert.AreEqual(plain, water);
            Assert.AreEqual(plain, mountain);
            Assert.AreEqual(plain, forest);
            Assert.AreEqual(water, mountain);
            Assert.AreEqual(water, forest);
            Assert.AreEqual(mountain, forest);
        }

        
    }
}
