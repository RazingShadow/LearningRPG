using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Creatures
    {
        public int currentHP { get; set; }

        public int maxHP { get; set; }

        public Creatures(int currentHP, int maxHP)
        {
            this.currentHP = currentHP;
            this.maxHP = maxHP;
        }

        /*public int TakingDMG()
        {

        }*/
    }
}
