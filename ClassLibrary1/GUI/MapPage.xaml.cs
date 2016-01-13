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
    /// Logique d'interaction pour Map.xaml
    /// </summary>
    public partial class MapPage : Page
    {
        public MapPage(GameBuilder gb)
        {
            InitializeComponent();

            // Création du jeu
            gb.buildGame();
            this.Game = gb.Game;


            this.NbTiles = Game.Map.MapSize.NbTiles;

            // calcul du côté de la case
            this.TileSize = mapGrid.Width / this.NbTiles;
            this.buildGrid();
            this.diplayUnits();
        }


        //champs
        public Game Game{
            get;
            set;
        }

        public int NbTiles
        {
            get;
            set;
        }

        public double TileSize
        {
            get;
            set;
        }


        // constructeur de bouton correspondant au format de la grille
        public Rectangle createTile(TileType type)
        {
            Rectangle tile = new Rectangle();
            String path = "";

            switch(type){
                case TileType.MOUNTAIN :
                    path = @"images/mountain.png";
                    break;

                case TileType.WATER :
                    path = @"images/water.png";
                    break;

                case TileType.PLAIN :
                    path = @"images/plain.png";
                    break;

                case TileType.FOREST :
                    path = @"images/forest.png";
                    break;
            }

            Uri uri = new Uri(path, UriKind.Relative);

            BitmapImage SourceBi = new BitmapImage(uri);
            SourceBi.UriSource = uri;
            ImageBrush image = new ImageBrush(SourceBi);

            tile.Fill = image;



            tile.Width= this.TileSize;
            tile.Height = this.TileSize;
            return tile;
        }


        private Rectangle createUnit(Race race)
        {
            Rectangle tile = new Rectangle();
            String path = "";

            switch (race)
            {
                case Race.Human:
                    path = @"images/Human.png";
                    break;

                case Race.Elf:
                    path = @"images/elf_asiat.png";
                    break;

                case Race.Orc:
                    path = @"images/orc.png";
                    break;
            }

            Uri uri = new Uri(path, UriKind.Relative);

            BitmapImage SourceBi = new BitmapImage(uri);
            SourceBi.UriSource = uri;
            ImageBrush image = new ImageBrush(SourceBi);

            tile.Fill = image;

            tile.Width = 0.75*this.TileSize;
            tile.Height = 0.75 * this.TileSize;
            return tile;
        }


        // Enlève tous les éléments présents dans la grid de la page xaml
        public void nettoieGrille()
        {
            mapGrid.Children.Clear();
        }


        /** Affiche la grille **/
        public void buildGrid()
        {
            for (int j = 0; j < this.NbTiles; j++)
            {
                // Création de la grille map
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition());
                mapGrid.RowDefinitions.Add(new RowDefinition());
                // Création de la grille des unités
                unitGrid.ColumnDefinitions.Add(new ColumnDefinition());
                unitGrid.RowDefinitions.Add(new RowDefinition());

                for (int i = 0; i < this.NbTiles; i++)
            {
                    // placement de la tile dans la grille 
                    Rectangle tile = this.createTile(this.Game.Map.getTile(i,j));
                    tile.SetValue(Grid.ColumnProperty, j);
                    tile.SetValue(Grid.RowProperty, i);
                    mapGrid.Children.Add(tile);
                }
                
            }
            
        }

        public void diplayUnits()
        {
            foreach (Player p in Game.Players)
            {
                foreach (Unit u in p.Units)
                {
                    Rectangle unit = this.createUnit(p.Race);
                    unit.SetValue(Grid.ColumnProperty, u.coord.X);
                    unit.SetValue(Grid.RowProperty, u.coord.Y);
                    mapGrid.Children.Add(unit);
                }
            }
        }

        private void backToMenu(object sender, RoutedEventArgs e)
        {
            QuitPage qp = new QuitPage(this.Game);
            NavigationService.Navigate(qp);
        }
       
    }
}


