using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Enemy : Creatures
    {
        public List<DropItem> LootTable { get; set; }
        public int ID { get; set; }

        public string Name { get; set; }

        public int maxDMG { get; set; }

        public int rewardXP { get; set; }

        public int rewardGold { get; set; }

        public Enemy(int id, string name, int maxDMG, int rewardXP, int rewardGold, int currentHP, int maxHP) : base(currentHP, maxHP)
        {
            ID = id;
            Name = name;
            this.maxDMG = maxDMG;
            this.rewardXP = rewardXP;
            this.rewardGold = rewardGold;
            LootTable = new List<DropItem>();
        }

        public List<InventoryItem> ItemDropOnDeath(Enemy enemy)
        {
            List<InventoryItem> droppedItems = new List<InventoryItem>();

            foreach (DropItem dropItem in enemy.LootTable)
            {
                if (RNG.numberBetween(1, 100) <= dropItem.dropPercentage) // comparting rdm number to drop percentage
                {
                    droppedItems.Add(new InventoryItem(dropItem.Details, 1)); // add dropped Item to droppedItems list
                    return droppedItems;
                }
            }

            if (droppedItems.Count == 0) // no rdm drop = default drop
            {
                foreach (DropItem dropItem in enemy.LootTable)
                {
                    if (dropItem.isDefaultItem)
                    {
                        droppedItems.Add(new InventoryItem(dropItem.Details, 1));
                        return droppedItems;
                    }
                }
            }
            return droppedItems; // null possible??
        }

        /*public int EnemyTurn(int maxDMG, int dealtDMG)
        {
            int dmgToPlayer = RNG.numberBetween(0, maxDMG);

            _player.currentHP -= dmgToPlayer; // subtract dmg amount from player health
        }*/
    }
}
