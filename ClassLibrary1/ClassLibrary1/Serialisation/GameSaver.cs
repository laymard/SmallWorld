using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    [Serializable()]
    public class GameSaver
    {
        public GameSaver(){}

        public GameSaver(Game game)
        {
            this.Game = game;
            this.Matrix = new MatrixSaver(game.Map.matrix);
        }

        [XmlElement()]
        public Game Game { get; set; }

        [XmlElement()]
        public MatrixSaver Matrix { get; set; }



        public void SaveGame(string path)
        {
            XmlSerializer gameSerializer = new XmlSerializer(typeof(GameSaver));
            StreamWriter writer = new StreamWriter(path);
            gameSerializer.Serialize(writer, this);

            writer.Close();
        }

        public static GameSaver ChargeGame(string chemin)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(GameSaver));
            StreamReader reader = new StreamReader(chemin);
            GameSaver gs = (GameSaver)deserializer.Deserialize(reader);
            reader.Close();

            return gs;
        }
    }
}
