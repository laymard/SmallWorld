using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    [Serializable()]
    public class PlayerSaver
    {
       public PlayerSaver(Player player){
            this.Name = player.Name;
            this.Race = player.Race;
            this.VictoryPoints = player.VictoryPoints;

            this.Units = new List<Unit>();
            foreach (Unit u in player.Units)
            {
                this.Units.Add(u);
            }
        }

        [XmlText()]
        public String Name
        {
            get;
            set;
        }

        [XmlAttribute()]
        public int VictoryPoints
        {
            get;
            set;
        }


      /*public List<UnitSaver> Units
        {
            get;
            set;
        } */

        [XmlArray(ElementName = "Units", Order = 1)]
        [XmlArrayItem("Unit")]
        public List<Unit> Units
        {
            get;
            set;
        }

        [XmlAttribute()]
        public int NbUnits
        {
            get;
            set;
        }

        [XmlAttribute()]
        public Race Race
        {
            get;
            set;
        }

    }
}
