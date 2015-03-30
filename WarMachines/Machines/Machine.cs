namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        #region Fieldfs
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;
        #endregion

        #region Constructor
        public Machine(string name, double hPoint, double aPoint, double dPoint)
        {
            this.Name = name;
            this.HealthPoints = hPoint;
            this.AttackPoints = aPoint;
            this.DefensePoints = dPoint;
            this.Targets = new List<string>();
        }
        #endregion

        #region Properties
        //  Each machine has name, pilot, health points, attack points, defense points and attack targets
        public string Name
        {
            get { return this.name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name value can not be null or empty string!");
                }
                this.name = value; 
            }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set 
            {
                this.pilot = value; 
            }
        }

        public double HealthPoints
        {
            get { return this.healthPoints; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Health point must be larger than 0");
                }
                this.healthPoints = value; 
            }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            protected set { this.attackPoints = value; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            protected set { this.defensePoints = value; }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
            private set { this.targets = value; }
        }
        #endregion

        #region Methods
        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            return string.Format("- {0} *Type: {1} *Health: {2} *Attack: {3} *Defense: {4} *Targets: {5}", 
                this.Name + Environment.NewLine,
                this.GetType().Name + Environment.NewLine, 
                this.HealthPoints + Environment.NewLine,
                this.AttackPoints + Environment.NewLine, 
                this.DefensePoints + Environment.NewLine, 
                this.Targets.Count == 0 ? "None" : string.Join(", ",this.Targets)
                );
        }
        #endregion
    }
}
