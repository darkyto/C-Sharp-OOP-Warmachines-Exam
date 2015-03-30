namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public class Tank : Machine , ITank
    {
        /* Tank’s initial health points are always 100 and fighter’s initial health points are always 200. 
         * Tank’s defense mode adds 30 defense points to the initial ones and removes 40 attack points from the initial ones. 
         * By default tanks’ defense mode is turned on. Fighters in stealth mode can be attacked only by other fighters.
         */
        private bool defenseMode;

        public Tank(string name, double aPoint, double dPoint)
            :base(name, 100, aPoint, dPoint)
        {
            this.ToggleDefenseMode(); // remember this toggle trick
        }

        public bool DefenseMode
        {
            get { return this.defenseMode; }
            set { this.defenseMode = value; }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            this.DefenseMode = !this.DefenseMode;
        }

        public override string ToString()
        {
            return string.Format("{0} *Defense: {1}", 
                base.ToString() + Environment.NewLine,
                this.DefenseMode ? "ON" : "OFF"
                );
        }
    }
}
