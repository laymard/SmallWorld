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


            this.nbTiles = Game.Map.MapSize.NbTiles;

            // calcul du côté de la case
            this.sizeTile = mapGrid.Height / this.nbTiles;
            this.creerGrille();
            this.afficheGrille();
        }


        //champs
        public Game Game{
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
            SolidColorBrush color = new SolidColorBrush();
            Uri uri = new Uri("/images/test.png", UriKind.Relative);
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

            bouton.SetValue(Button.BackgroundProperty, color);
            addImage(bouton, uri); 

            bouton.SetValue(Button.WidthProperty, sizeTile);
            bouton.SetValue(Button.HeightProperty, sizeTile);

            return bouton;
        }



        // création de la grid dans la page xaml
        public void creerGrille()
        {
            // création de la grid
            for (int j = 0; j < this.nbTiles; j++)
            {
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < this.nbTiles; i++)
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
                    Button bouton = this.formatBouton(this.Game.Map.getTile(i,j));
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


