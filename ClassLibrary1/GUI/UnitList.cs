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
    class UnitList
    {
        public static UnitList INSTANCE = new UnitList();
        public Dictionary<Unit, DockPanel> unitsItems;
        private UnitList()
        {
            unitsItems = new Dictionary<Unit,DockPanel>();
        }

        public Unit getUnit(DockPanel dockPanel)
        {
            foreach (Unit u in unitsItems.Keys)
            {
                if (unitsItems[u].Equals(dockPanel)) return u;
            }

            return null;
        }
        public DockPanel getDockPanel(Unit u, Race race)
        {
            DockPanel dp = AddUnit(u, race);
            if (unitsItems.ContainsKey(u))
            {
                this.unitsItems[u] = dp;
            }
            else
            {
                unitsItems.Add(u, dp);
            }

            return unitsItems[u];
        }
        public DockPanel AddUnit(Unit u, Race race)
        {
            DockPanel res = new DockPanel();

            // image à gauche
            Image image = ImageFactory.INSTANCE.getImage(race);
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

            return res;
        }
    }
}
