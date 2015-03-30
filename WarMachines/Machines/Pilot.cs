namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        /* Each pilot has name and machines he engages. 
         * Pilots make status reports on all machines they engage. 
         * One machine can be engaged by one pilot at a time.  
         */
        private string name;
        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} - ",this.Name ));
            if (this.machines.Count <=0)
            {
                sb.Append("no machines");
            }
            else if (this.machines.Count == 1)
            {
                sb.AppendLine("1 machine");
                foreach (var mach in machines)
                {
                    sb.Append(mach.ToString());
                }
            }
            else
            {
                sb.AppendLine(string.Format("{0} machines",this.machines.Count));
                int index = 0;
                machines.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name);
                foreach (var mach in machines)
                {
                    if (index < machines.Count() - 1)
                    {
                        sb.AppendLine(mach.ToString());
                    }
                    else
                    {
                        sb.Append(mach.ToString());
                    }

                    index++;
                }
            }

            return sb.ToString();
            /*(pilot name) – (number of machines/”no”) (“machine”/”machines”)
            - (machine name)
             *Type: (“Tank”/”Fighter”)
             *Health: (machine health points)
             *Attack: (machine attack points)
             *Defense: (machine defense points)
             *Targets: (machine target names/”None” – comma separated)
             *Defense: (“ON”/”OFF” – when applicable)
            - (machine name)
             *Type: (machine type)
             *Health: (machine health points)
             *Attack: (machine attack points)
             *Defense: (machine defense points)
             *Targets: (machine target names/”None” – comma separated)
             *Stealth: (“ON”/”OFF” – when applicable)

             */
        }
    }
}
