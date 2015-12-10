using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ClassLibrary1
{
    /// <summary>
    /// Description résumée pour GameTest
    /// </summary>
    [TestClass]
    public class GameTest
    {
        public GameTest()
        {
 
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestStartGame()
        {
            // Création de la map
            StandardMap ms = new StandardMap();
            // Création du jeu
            NewGameBuilder gb = NewGameBuilder(ms);
            gb.buildGame();
            Game game = gb.Game;
            // Création des joueurs
            game.AddPlayer(Race.Human, "Robert", 4);
            game.AddPlayer(Race.Orc, "Marie", 4);
            game.AddPlayer(Race.Elf, "Gaston", 4);

            Player p1 = game.Players[0];
            Player p2 = game.Players[1];
            Player p3 = game.Players[2];

            game.StartGame();

            // Liste des coordonnées occupées
            List<Coordinate> listCoord = new List<Coordinate>();

            // Les unités sont positionnées sur la carte
            foreach (Player p in game.Players)
            {
                foreach (Unit u in p.Units)
                {
                    Assert.IsTrue(u.coord.X < ms.NbTiles);
                    Assert.IsTrue(u.coord.Y < ms.NbTiles);
                    Assert.IsTrue(u.coord.X >= 0);
                    Assert.IsTrue(u.coord.Y >= 0);
                    
                    listCoord.Add(u.coord);
                }
            }

            foreach (Coordinate coord in listCoord)
            {
                // Seule un des trois joueur peut être positionné sur la case (une seule race par case)
                Assert.IsTrue(
                    p1.getUnitsOnTile(coord).Count == 0 && p2.getUnitsOnTile(coord).Count == 0
                 || p1.getUnitsOnTile(coord).Count == 0 && p3.getUnitsOnTile(coord).Count == 0
                 || p2.getUnitsOnTile(coord).Count == 0 && p3.getUnitsOnTile(coord).Count == 0);
            }

            // test setFirstPlayer
            Assert.IsTrue(game.Players.Contains(game.CurrentPlayer));
        }

        private NewGameBuilder NewGameBuilder(StandardMap ms)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void testChangePlayer()
        {
            // Création de la map
            StandardMap ms = new StandardMap();
            // Création du jeu
            NewGameBuilder gb = NewGameBuilder(ms);
            gb.buildGame();
            Game game = gb.Game;
            // Création des joueurs
            game.AddPlayer(Race.Human, "Robert", 4);
            game.AddPlayer(Race.Orc, "Marie", 4);
            game.AddPlayer(Race.Elf, "Gaston", 4);

            // Test
            Player first = game.CurrentPlayer;
            game.changePlayer();
            Player second = game.CurrentPlayer;
            game.changePlayer();
            Player third = game.CurrentPlayer;
            game.changePlayer();

            Assert.AreNotEqual(first,second);
            Assert.AreNotEqual(second, third);
            Assert.AreNotEqual(third, game.CurrentPlayer);
            Assert.AreEqual(first, game.CurrentPlayer);

        }

        [TestMethod]
        public void TestAddPlayer()
        {
            // Création de la map
            StandardMap ms = new StandardMap();
            // Création du jeu
            NewGameBuilder gb = NewGameBuilder(ms);
            gb.buildGame();
            Game game = gb.Game;
            // Création des joueurs
            game.AddPlayer(Race.Human, "Robert", 4);
            game.AddPlayer(Race.Orc, "Marie", 4);
            game.AddPlayer(Race.Elf, "Gaston", 4);
            game.AddPlayer(Race.Elf, "Gaston", 4);

            Assert.AreEqual(3,game.Players.Count);
        }

        [TestMethod]
        public void TestSaveGame()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }


        [TestMethod]
        public void TestAttack()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        [TestMethod]
        public void TestChooseWinner()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        [TestMethod]
        public void TestselectBestDefender()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

    }
}
