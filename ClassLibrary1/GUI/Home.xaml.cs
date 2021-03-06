﻿using System;
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
            string file = @"savedGame.xml";
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

            App.Current.MainWindow.Close();
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

    }
}
