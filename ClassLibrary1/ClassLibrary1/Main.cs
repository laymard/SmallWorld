using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class MainTest
    {
        static void Main(string[] args)
        {
            // Joueurs
            Player p1 = new Player(Race.Human, "Robert", 4);
            Player p3 = new Player(Race.Elf, "Gaston", 4);
            Player p2 = new Player(Race.Orc, "Marie", 4);
            List<Player> players = new List<Player> { p1, p2, p3 };

            //Test Algo
            MapSize size = new DemoMap();
            Map map = new Map(size);
            Coordinate coord = new Coordinate(0, 0);
            Coordinate coord2 = new Coordinate(0, 0);
            Console.WriteLine("test égalité : " + coord.Equals(coord2));
            TileType type = map.matrix[coord];
            Console.WriteLine(type);
            Console.ReadKey();

            Game game = new Game(new StandardMap(), players);

           /* game.saveGame("lejeu1.xml");

            SavedGameBuilder gameBuilder = new SavedGameBuilder("lejeu1.xml");
            gameBuilder.buildGame();
            gameBuilder.Game.saveGame("lejeu2.xml");*/
        }
    }
}
