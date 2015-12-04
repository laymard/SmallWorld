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

            Game game = new Game(new StandardMap(), players);

            game.SaveGame("lejeu.xml");
        }
    }
}
