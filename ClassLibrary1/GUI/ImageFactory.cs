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
using System.Windows.Shapes;
using ClassLibrary1;

namespace GUI
{
    class ImageFactory
    {
        public static ImageFactory INSTANCE = new ImageFactory();
        public Dictionary<TileType, BitmapImage> Tiles { get; set; }
        public Dictionary<Race, BitmapImage> Races { get; set; }

        private ImageFactory()
        {
            Tiles = new Dictionary<TileType, BitmapImage>();
            Races = new Dictionary<Race, BitmapImage>();
        }

        public Image getImage(Race race)
        {
            Image image = new Image();

            if (Races.ContainsKey(race))
            {
                image.Source = Races[race];
            }
            else
            {
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
               
                image.Source = SourceBi;

                Races.Add(race, SourceBi);
            }

            return image;

        }
        public ImageBrush getImage(TileType tile)
        {
            ImageBrush image = new ImageBrush();
            if (Tiles.ContainsKey(tile))
            {
                image.ImageSource = Tiles[tile];
                return image;
            }
            else
            {
                String path = "";
                switch (tile)
                {
                    case TileType.MOUNTAIN:
                        path = @"images/mountain.png";
                        break;

                    case TileType.WATER:
                        path = @"images/water.png";
                        break;

                    case TileType.PLAIN:
                        path = @"images/plain.png";
                        break;

                    case TileType.FOREST:
                        path = @"images/forest.png";
                        break;
                }

                Uri uri = new Uri(path, UriKind.Relative);
                BitmapImage SourceBi = new BitmapImage(uri);
                SourceBi.UriSource = uri;
               
                Tiles.Add(tile, SourceBi);
                image.ImageSource = SourceBi;

                return image;
            }
        }
    }
}

