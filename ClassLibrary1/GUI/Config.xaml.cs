﻿using System;
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

        private void DisplayPlayer(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;

            if (button.Equals(orc1))
            {
                Image1.Source = new BitmapImage(new Uri(@"/images/orc.png", UriKind.Relative));
            }

            if (button.Equals(elf1))
            {
                Image1.Source = new BitmapImage(new Uri(@"/images/elf_asiat.png", UriKind.Relative));
            }

            if (button.Equals(human1))
            {
                Image1.Source = new BitmapImage(new Uri(@"/images/Human.png", UriKind.Relative));
            }


            if (button.Equals(orc2))
            {
                Image2.Source = new BitmapImage(new Uri(@"/images/orc.png", UriKind.Relative));
            }

            if (button.Equals(elf2))
            {
                Image2.Source = new BitmapImage(new Uri(@"/images/elf_asiat.png", UriKind.Relative));
            }

            if (button.Equals(human2))
            {
                Image2.Source = new BitmapImage(new Uri(@"/images/Human.png", UriKind.Relative));
            }
        }

    }
}
