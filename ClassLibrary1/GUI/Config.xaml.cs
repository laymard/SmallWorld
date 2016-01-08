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
    /// Logique d'interaction pour Config.xaml
    /// </summary>
    public partial class Config : Page
    {
        public Config()
        {
            InitializeComponent();
        }

        private void startNewGame(object sender, RoutedEventArgs e)
        {
            MapPage mp = new MapPage(new NewGameBuilder(new StandardMap(),name1.Text, Race.Human, name2.Text, Race.Elf));
            this.NavigationService.Navigate(mp);
        }
    }
}
