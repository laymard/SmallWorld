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
        public MapPage()
        {
            InitializeComponent();

            // Création du jeu
            NewGameBuilder gb = new NewGameBuilder(new StandardMap());
            gb.buildGame();
            this.Game = gb.Game;


            this.NbTiles = Game.Map.MapSize.NbTiles;

            // calcul du côté de la case
            this.TileSize = mapGrid.Height / this.NbTiles;
            this.displayGrid();
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
        public Button createButton(TileType type)
        {
            Button bouton = new Button();
            SolidColorBrush color = new SolidColorBrush();
            var appDir = System.IO.Path.GetDirectoryName(typeof(MapPage).Assembly.Location);
            var filePath = System.IO.Path.Combine(appDir, "/images/test.png");
            Uri uri = new Uri(filePath,UriKind.RelativeOrAbsolute);
            switch(type){
                case TileType.MOUNTAIN :
                    color = new SolidColorBrush(Colors.Brown);
                    break;

                case TileType.WATER :
                    color = new SolidColorBrush(Colors.Blue);
                    break;

                case TileType.PLAIN :
                    color = new SolidColorBrush(Colors.GreenYellow);
                    break;

                case TileType.FOREST :
                    color = new SolidColorBrush(Colors.Green);
                    break;
            }

            addImage(bouton,uri);
            bouton.SetValue(Button.BackgroundProperty, color);

            bouton.SetValue(Button.WidthProperty, this.TileSize);
            bouton.SetValue(Button.HeightProperty, this.TileSize);

            return bouton;
        }


        // Enlève tous les éléments présents dans la grid de la page xaml
        public void nettoieGrille()
        {
            mapGrid.Children.Clear();
        }


        /** Affiche la grille **/
        public void displayGrid()
        {
            for (int j = 0; j < this.NbTiles; j++)
            {
                // Création de la grille
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition());
                mapGrid.RowDefinitions.Add(new RowDefinition());

                for (int i = 0; i < this.NbTiles; i++)
            {
                    // placement du bouton dans la grille 
                    Button button = this.createButton(this.Game.Map.getTile(i,j));
                    button.SetValue(Grid.ColumnProperty, j);
                    button.SetValue(Grid.RowProperty, i);
                    mapGrid.Children.Add(button);
                }
                
            }
            
        }
        

        /**A partir de l'uri, crée l'image adapté à la taille du Bouton**/
        public void addImage(Button button, Uri uri)
        {

            // creation de l'image 
            Image image = new Image();
            BitmapImage SourceBi = new BitmapImage();
            SourceBi.UriSource = uri;
            image.Source = SourceBi;

            // empeche l'icone de depasser du contour du bouton
            image.SetValue(Image.HeightProperty, this.TileSize);
            image.SetValue(Image.WidthProperty, this.TileSize);
            image.SetValue(Image.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            image.SetValue(Image.VerticalAlignmentProperty, VerticalAlignment.Center);

            // ajout de l'image au bouton
            Grid box = new Grid();
            box.RowDefinitions.Add(new RowDefinition());
            image.SetValue(Grid.RowProperty, 0);
            
            box.Children.Add(image);

            button.Content = box;
        }
       
    }
}


