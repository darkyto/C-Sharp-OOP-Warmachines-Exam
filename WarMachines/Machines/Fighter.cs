

namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public class Fighter : Machine , IFighter
    {
        private bool stealthMode;

        public Fighter(string name, double aPoint, double dPoint, bool stealth)
            :base(name, 200, aPoint, dPoint)
        {
            this.StealthMode = stealth;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
            set { this.stealthMode = value; }
        }

        public void ToggleStealthMode() // this in the constructor ?
        {
            if (this.stealthMode == true)
            {
                this.stealthMode = false;
            }
            else
            {
                this.stealthMode = true;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} *Stealth: {1}",
                base.ToString() + Environment.NewLine,
                this.StealthMode ? "ON" : "OFF"
                );
        }
    }
}
