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

        public Race getRaceJ1()
        {
            if (orc1.IsChecked.Value) { return Race.Orc; }
            if (human1.IsChecked.Value) { return Race.Human; }
            else { return Race.Elf; }
        }

        public Race getRaceJ2()
        {
            if ((bool)orc2.IsChecked) { return Race.Orc; }
            if (human2.IsChecked.Value) { return Race.Human; }
            else { return Race.Elf; }
        }

        public MapSize getMap()
        {
            if ((bool)demo.IsChecked) { return new DemoMap(); }
            if ((bool)standard.IsChecked) { return new StandardMap(); }
            else { return new SmallMap(); }
        }

        private void startNewGame(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.Content = "Patientez svp";
            MapPage mp = new MapPage(new NewGameBuilder(this.getMap(), name1.Text, this.getRaceJ1(), name2.Text, this.getRaceJ2()));
            this.NavigationService.Navigate(mp);
        }

        private void size_plus(object sender, MouseEventArgs e)
        {
            Image img = ((Image)sender);
            img.Height = img.ActualHeight * 1.1;
            e.Handled = true;
        }

        private void size_less(object sender, MouseEventArgs e)
        {
            Image img = ((Image)sender);
            img.Height /= 1.1;
            e.Handled = true;
        }

    

        private void DisplayPlayer(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;

            if (button.Equals(orc1))
            {
                Image1.Source = ImageFactory.INSTANCE.getImage(Race.Orc).Source;
            }

            if (button.Equals(elf1))
            {
                Image1.Source = ImageFactory.INSTANCE.getImage(Race.Elf).Source;
            }

            if (button.Equals(human1))
            {
                Image1.Source = ImageFactory.INSTANCE.getImage(Race.Human).Source;
            }


            if (button.Equals(orc2))
            {
                Image2.Source = ImageFactory.INSTANCE.getImage(Race.Orc).Source;
            }

            if (button.Equals(elf2))
            {
                Image2.Source = ImageFactory.INSTANCE.getImage(Race.Elf).Source;
            }

            if (button.Equals(human2))
            {
                Image2.Source = ImageFactory.INSTANCE.getImage(Race.Human).Source;
            }
        }

    }


}
