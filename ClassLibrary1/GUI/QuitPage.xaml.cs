using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary1;

namespace GUI
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class QuitPage : Page
    {
        public GameSaver GameSaver { get; set; }
        public QuitPage(Game game)
        {
            InitializeComponent();
            this.GameSaver = new GameSaver(game);
        }

        private void saveGame(object sender, RoutedEventArgs e)
        {
            this.GameSaver.SaveGame(@"savedGame.xml");

            // TO DO : retour page principale
        }


    }
}
