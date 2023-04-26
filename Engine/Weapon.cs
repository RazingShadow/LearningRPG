using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item
    {
        public int minDMG { get; set; }

        public int maxDMG { get; set; }

        public Weapon(int id, string name, string namePlural, int minDMG, int maxDMG) : base(id, name, namePlural)
        {
            this.minDMG = minDMG;
            this.maxDMG = maxDMG;
        }
    }
}
