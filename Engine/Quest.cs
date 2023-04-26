using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        public List<QuestCompletionItem> QuestCompletionItems { get; set; }
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int rewardXP { get; set; }

        public int rewardGold { get; set; }

        public Item rewardItemOfQuest { get; set; }

        public Quest(int id, string name, string description, int rewardXP, int rewardGold, Item rewardItemOfQuest = null)
        {
            ID = id;
            Name = name;
            Description = description;
            this.rewardXP = rewardXP;
            this.rewardGold = rewardGold;
            this.rewardItemOfQuest = rewardItemOfQuest;
            QuestCompletionItems = new List<QuestCompletionItem>();
        }
    }
}
