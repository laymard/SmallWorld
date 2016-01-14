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
                    tile.AddHandler(Rectangle.MouseLeftButtonDownEvent,(RoutedEventHandler)selectedTile);
                    
                }
                
            }
            
        }

        private void selectedTile(object sender, RoutedEventArgs e)
        {
            Rectangle rect = sender as Rectangle;

            var x = rect.GetValue(Grid.ColumnProperty);
            var y = rect.GetValue(Grid.RowProperty);

            MessageBox.Show("Case cliquée : x = "+x+" y : "+y);
        }

        private void selectedUnit(object sender, RoutedEventArgs e)
        {
            Image rect = sender as Image;

            // Case cliquée
            var x = (int)rect.GetValue(Grid.ColumnProperty);
            var y = (int)rect.GetValue(Grid.RowProperty);
            Coordinate c = new Coordinate(x,y);
            MessageBox.Show("Unité cliquée : x = " + x + " y : " + y);

            // nettoie liste
            this.Units.Items.Clear();

            // affichage des unités dans la liste
            var units = Game.CurrentPlayer.getUnitsOnTile(c);
            foreach(Unit u in units){
                Button button = new Button();
                DockPanel unitDisplay = addUnitToList(u);
                button.Content = unitDisplay;
                this.Units.Items.Add(button);

                //button.Click += selectUnitInList;
            }
            
            
        }

        public DockPanel addUnitToList(Unit u)
        {
            DockPanel res = new DockPanel();

            // image à gauche
            Image image = ImageFactory.INSTANCE.getImage(Game.CurrentPlayer.Race);
            DockPanel.SetDock(image, Dock.Left);
            res.Children.Add(image);

            // points à droite
            TextBlock attaque = new TextBlock();
            attaque.Text = "Attaque : " + u.Points.attackPoints;
            TextBlock defence = new TextBlock();
            defence.Text = "Défense : " + u.Points.defencePoints;
            TextBlock depl = new TextBlock();
            depl.Text = "Déplacement : " + u.Points.MovePoints;
            TextBlock vie = new TextBlock();
            vie.Text = "Vie : " + u.Points.lifePoints;

            StackPanel stack = new StackPanel();
            stack.Children.Add(attaque);
            stack.Children.Add(defence);
            stack.Children.Add(vie);
            stack.Children.Add(depl);
            
            DockPanel.SetDock(stack, Dock.Right);
            res.Children.Add(stack);

            var width = (double)res.GetValue(Grid.WidthProperty);
            res.Width = width;

            return res;
        }
        public void displayUnitsOnMap()
        {
            foreach (Player p in Game.Players)
            {
                foreach (Unit u in p.Units)
                {
                    Image unit = this.createUnit(p.Race);
                    unit.SetValue(Grid.ColumnProperty, u.coord.X);
                    unit.SetValue(Grid.RowProperty, u.coord.Y);
                    mapGrid.Children.Add(unit);
                    unit.AddHandler(Image.MouseLeftButtonDownEvent, (RoutedEventHandler)selectedUnit);
                }
            }
        }

        private void backToMenu(object sender, RoutedEventArgs e)
        {
            QuitPage qp = new QuitPage(this.Game);
            NavigationService.Navigate(qp);
        }

        private void NextPlayer(object sender, RoutedEventArgs e)
        {
            Game.EndTurn();
            DisplayPlayer();
        }

        private void selectUnitInList(object sender, RoutedEventArgs e)
        {
            Game.EndTurn();
            DisplayPlayer();
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

    }
}


