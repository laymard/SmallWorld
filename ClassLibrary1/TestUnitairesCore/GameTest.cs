using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitairesCore
{
    /// <summary>
    /// Description résumée pour GameTest
    /// </summary>
    [TestClass]
    public class GameTest
    {
        public GameTest()
        {
            Player p1 = new Player();
            Player p2 = new Player();
            Player p3 = new Player();
            
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
        public void TestInitilizeMap()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        [TestMethod]
        public void TestInitilizePlayer()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        [TestMethod]
        public void testChangePlayer()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        [TestMethod]
        public void testEnd()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        [TestMethod]
        public void TestCheckRaces()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        [TestMethod]
        public void TestSetFirstPlayer()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        [TestMethod]
        public void TestSaveGame()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        [TestMethod]
        public void TestSelectTile()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        [TestMethod]
        public void TestSelectUnit()
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
