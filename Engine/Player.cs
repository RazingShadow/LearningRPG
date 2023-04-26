using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : Creatures
    {
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> QuestList { get; set; }

        public int Gold { get; set; }

        public int XP { get; set; }

        public int Lvl { get; set; }

        public Location currentLocation { get; set; }

        public Player(int gold, int xp, int lvl, int currentHP, int maxHP) : base(currentHP, maxHP)
        {
            Gold = gold;
            XP = xp;
            Lvl = lvl;
            Inventory = new List<InventoryItem>();
            QuestList = new List<PlayerQuest>();
        }

        public bool reqToEnterLocInInventory(Location location) // item requirement check
        {
            if (location.reqToEnterLoc == null) // no item requirement
            {
                return true;
            }

            foreach (InventoryItem ii in Inventory) // required item in inventory
            {
                if (ii.Details.ID == location.reqToEnterLoc.ID)
                {
                    return true;
                }
            }
            return false; // required item not found
        }
        public bool receivedQuest(Quest quest) // has player already received quest?
        {
            foreach (PlayerQuest playerQuest in QuestList)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return true;
                }
            }
            return false;
        }
        public bool completedQuest(Quest quest) // has player already completed quest?
        {
            foreach (PlayerQuest playerQuest in QuestList)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.isCompleted;
                }
            }
            return false;
        }
        public bool QuestCompletionItemsInInventory(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;

                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID) // item found in inventory
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Quantity < qci.Quantity) // not enough items in inventory
                        {
                            return false;
                        }
                    }
                }

                if (!foundItemInPlayersInventory) // item not found in inventory
                {
                    return false;
                }
            }
            return true; // requirements met
        }
        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }
        public void AddItemToInventory(Item rewardItemToAdd)
        {
            foreach (InventoryItem ii in Inventory) // player already has one item of kind
            {
                if (ii.Details.ID == rewardItemToAdd.ID) 
                {
                    ii.Quantity++;
                    return; 
                }
            }
            Inventory.Add(new InventoryItem(rewardItemToAdd, 1)); // new item
        }
        public void SetQuestCompletionStatus(Quest quest)
        {
            foreach (PlayerQuest pq in QuestList)
            {
                if (pq.Details.ID == quest.ID)
                {
                    pq.isCompleted = true;
                    return;
                }
            }
        }
        public Player PlayerHeal(HealingPotion potion, Player player)
        {
            player.currentHP = (player.currentHP + potion.amountToHeal);

            if (player.currentHP > player.maxHP)
            {
                player.currentHP = player.maxHP;
            }
            

            foreach (InventoryItem ii in player.Inventory) // remove potion from inventory
            {
                if (ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    return player;
                }
            }
            return player;
        }

    }
}
