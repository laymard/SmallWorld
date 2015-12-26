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
        public MapPage(Map map)
        {
            this.map = map;
            this.nbTiles = map.MapSize.nbTiles;
            InitializeComponent();
            // calcul du côté de la case
            this.sizeTile = mapGrid.Height / this.map.MapSize.nbTiles;
        }


        //champs
        public Map map{
            get;
            set;
        }

        public int nbTiles
        {
            get;
            set;
        }

        public double sizeTile
        {
            get;
            set;
        }


        // constructeur de bouton correspondant au format de la grille (taille)
        public Button formatBouton(TileType type)
        {
            Button bouton = new Button();
            SolidColorBrush couleur;
            Uri uri = new Uri("images/test.png");
            switch(type){
                case TileType.MOUNTAIN :
                    couleur = new SolidColorBrush(Colors.Brown);
                    
                    break;
                case TileType.WATER :
                    couleur = new SolidColorBrush(Colors.AliceBlue);
                    break;
                case TileType.PLAIN :
                    couleur = new SolidColorBrush(Colors.GreenYellow);
                    break;
                case TileType.FOREST :
                    couleur = new SolidColorBrush(Colors.Green);
                    break;
            }

            bouton.SetValue(Button.BackgroundProperty, couleur);
            addImage(bouton, uri); 

            bouton.SetValue(Button.WidthProperty, sizeTile);
            bouton.SetValue(Button.HeightProperty, sizeTile);

            return bouton;
        }



        // création de la grid dans la page xaml
        public void creerGrille()
        {
            // création de la grid
            for (int j = 0; j < map.MapSize.nbTiles; j++)
            {
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < map.MapSize.nbTiles; i++)
            {
                mapGrid.RowDefinitions.Add(new RowDefinition());
            }

        }

        // Enlève tous les éléments présents dans la grid de la page xaml
        public void nettoieGrille()
        {
            mapGrid.Children.Clear();
        }


        /** Affiche la grille avec le bon format et les icones correspondant au numéro de Page de la grille numGrille et retourne la liste des boutons créer
         * Grid cadre : grid de la page xaml concernée par l'affichage
         * **/
        public void afficheGrille()
        {

            // ajout des boutons et de leurs icones dans la grille
            for (int j = 0; j < this.nbTiles; j++)
            {
                for (int i = 0; i < this.nbTiles; i++)
                {
                    // placement du bouton dans la grille 
                    Button bouton = this.formatBouton(map.getTile(i,j));
                    bouton.SetValue(Grid.ColumnProperty, j);
                    bouton.SetValue(Grid.RowProperty, i);
                    mapGrid.Children.Add(bouton);
                }
                
            }
            
        }
        

        /**A partir de l'uri, crée l'image adapté à la taille du Bouton**/
        public void addImage(Button bouton, Uri uri)
        {
            // creation de l'image 
            Image image = new Image();
            BitmapImage SourceBi = new BitmapImage();
            SourceBi.UriSource = uri;
            image.Source = SourceBi;

            // empeche l'icone de depasser du contour du bouton
            image.SetValue(Image.HeightProperty, this.sizeTile);
            image.SetValue(Image.WidthProperty, this.sizeTile);

            // ajout de l'image au bouton
            Grid grilleBouton = new Grid();
            grilleBouton.Children.Add(image);

            bouton.Content = grilleBouton;
        }
       
    }
}


