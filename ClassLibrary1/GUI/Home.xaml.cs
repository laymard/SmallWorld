using System;
using System.IO;
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
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void loadGame(object sender, RoutedEventArgs e)
        {
            string file = @"savedgame.xml";
            if(File.Exists(file)){
                MapPage mp = new MapPage(new SavedGameBuilder(file));
                this.NavigationService.Navigate(mp);
            }
        }

        private void newGame(object sender, RoutedEventArgs e)
        {
            var page = new Config();
            this.NavigationService.Navigate(page);
        }

        private void quit(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
