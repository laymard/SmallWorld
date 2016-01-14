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
            this.displayUnitsOnMap();
            this.DisplayPlayer();
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
            
            ImageBrush image = ImageFactory.INSTANCE.getImage(type);

            tile.Fill = image;

            tile.Width= 0.8*this.TileSize;
            tile.Height = 0.8*this.TileSize;
            return tile;
        }


        private Image createUnit(Race race)
        {
            Image image = ImageFactory.INSTANCE.getImage(race);
            image.Height = 0.5 * this.TileSize;
            image.Width = 0.5 * this.TileSize;
            return image;
        }


        /** Construit la grille **/
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
                    tile.SetValue(Grid.ColumnProperty, i);
                    tile.SetValue(Grid.RowProperty, j);
                    mapGrid.Children.Add(tile);
                    tile.AddHandler(Rectangle.MouseLeftButtonDownEvent,(RoutedEventHandler)selectTile);
                    
                }
                
            }
            
        }

        private void selectTile(object sender, RoutedEventArgs e)
        {
            Rectangle rect = sender as Rectangle;

            var x = (int)rect.GetValue(Grid.ColumnProperty);
            var y = (int)rect.GetValue(Grid.RowProperty);
            if (Game.CurrentPlayer.CurrentUnit != null)
            {
                Coordinate c = Game.CurrentPlayer.CurrentUnit.coord;
                // Si click sur une case : move
                Game.selectTile(Game.Map.getCoord(x, y));
                if (Game.CurrentPlayer.CurrentUnit.coord != c)
                {
                    displayAction(GUI.Action.Move);
                }
            }
            else
            {
                Game.selectTile(Game.Map.getCoord(x, y));
            }

            actualiseDisplay();
        }

        private void displayAction(GUI.Action action)
        {
            ImageAction.Source = ImageFactory.INSTANCE.getImage(action).Source;

            String text = "";
            switch (action)
            {
                case GUI.Action.Move :
                    text = Game.CurrentPlayer.Name + " se déplace\n sur une case " + Game.CurrentPlayer.CurrentUnit.currentTile+".";
                    break;

                case GUI.Action.Fight :
                    text = Observer.INSTANCE.AttackName + " attaque " + Observer.INSTANCE.DefenseName+
                        " !\n" + Observer.INSTANCE.LooserName + " perd " + Observer.INSTANCE.NbPoints+" points de vie.";
                    break;
            }

            this.Action.Text = text;
        }

        private void selectUnitOnTile(object sender, RoutedEventArgs e)
        {
            Image rect = sender as Image;

            // Case cliquée
            var x = (int)rect.GetValue(Grid.ColumnProperty);
            var y = (int)rect.GetValue(Grid.RowProperty);


            // Si click sur une unité adverse : attaque
            Game.selectTile(Game.Map.getCoord(x, y));
            if (Observer.INSTANCE.hasChanged)
            {
                displayAction(GUI.Action.Fight);
            }

            actualiseDisplay();
        }

        private void displayUnitList()
        {
            // nettoie liste
            this.Units.Items.Clear();

            if (Game.SelectedTile != null)
            {
                // affichage des unités dans la liste
                var units = Game.CurrentPlayer.getUnitsOnTile(Game.SelectedTile);
                foreach (Unit u in units)
                {
                    DockPanel unitDisplay = UnitList.INSTANCE.getDockPanel(u, Game.CurrentPlayer.Race);
                    this.Units.Items.Add(unitDisplay);
                }
            }

        }

        public void displayUnitsOnMap()
        {
            unitGrid.Children.Clear();
            foreach (Player p in Game.Players)
            {
                foreach (Unit u in p.Units)
                {
                    Image unit = this.createUnit(p.Race);
                    unit.SetValue(Grid.ColumnProperty, u.coord.X);
                    unit.SetValue(Grid.RowProperty, u.coord.Y);
                    unitGrid.Children.Add(unit);
                    unit.AddHandler(Image.MouseLeftButtonDownEvent, (RoutedEventHandler)selectUnitOnTile);
                }
            }
        }  

        private void DisplayPlayer()
        {
            name1.Text = Game.Players[0].Name;
            nbPoints1.Text = "Points de victoire : " + Game.Players[0].VictoryPoints;
            race1.Text = Game.Players[0].Race.ToString();
            nbUnits1.Text = "Nombre unités : " + Game.Players[0].NbUnits;
            name2.Text = Game.Players[1].Name;
            nbPoints2.Text = "Points de victoire : " + Game.Players[1].VictoryPoints;
            race2.Text = Game.Players[1].Race.ToString();
            nbUnits2.Text = "Nombre unités : " + Game.Players[1].NbUnits;


            Image1.Source = ImageFactory.INSTANCE.getImage(Game.Players[0].Race).Source;
            Image2.Source = ImageFactory.INSTANCE.getImage(Game.Players[1].Race).Source;


            if (Game.CurrentPlayer.Equals(Game.Players[0]))
            {
                Joueur2.SetValue(DockPanel.OpacityProperty, 0.50);
                Joueur1.SetValue(DockPanel.OpacityProperty, 0.85);
            }

            if (Game.CurrentPlayer.Equals(Game.Players[1]))
            {
                Joueur1.SetValue(DockPanel.OpacityProperty, 0.50);
                Joueur2.SetValue(DockPanel.OpacityProperty, 0.85);
            }
        } 

        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DockPanel dp = (DockPanel)Units.SelectedItem;
            Unit unit = UnitList.INSTANCE.getUnit(dp);
            Game.CurrentPlayer.selectUnit(unit);
        }


        private void backToMenu(object sender, MouseButtonEventArgs e)
        {
            QuitPage qp = new QuitPage(this.Game);
            NavigationService.Navigate(qp);
        }

        private void NextPlayer(object sender, RoutedEventArgs e)
        {
            Game.EndTurn();
            TourRestants.Content = Game.TurnsLeft.ToString();
            nbPoints1.Text = "Nb points " + Game.Players[0].VictoryPoints;
            nbPoints2.Text = "Nb points " + Game.Players[1].VictoryPoints;
            DisplayPlayer();
        }

        public void actualiseDisplay()
        {
            DisplayPlayer();
            displayUnitsOnMap();
            displayUnitList();
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


