using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Observer
    {
        public static Observer INSTANCE = new Observer();
        public String AttackName { get; set; }
        public String DefenseName { get; set; }
        public String LooserName { get; set; }

        public bool hasChanged;
        public int NbPoints { get; set; }
        

        private Observer()
        {
            AttackName = "";
            DefenseName = "";
            LooserName = "";
            NbPoints = 0;
            hasChanged = false;
        }

        public void update(String attackName, String defenseName, String looserName, int nbPoints)
        {
            AttackName = attackName;
            DefenseName = defenseName;
            LooserName = looserName;
            NbPoints = nbPoints;
            hasChanged = true;
        }
      
    }
}
