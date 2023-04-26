using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Item reqToEnterLoc { get; set; }  // Item requirement to enter Location x
        public Quest givenQuestLoc { get; set; } // Quests given in Location x
        public Enemy placedEnemyLoc { get; set; } // Enemy present in Location x
        public Location northOfLoc { get; set; } // Location: to the North
        public Location eastOfLoc { get; set; }  //           to the East
        public Location southOfLoc { get; set; } //           to the South
        public Location westOfLoc { get; set; }  //           to the West

        public Location(int id, string name, string description, Item reqToEnterLoc = null, Quest givenQuestLoc = null, Enemy placedEnemyLoc = null)
        {
            ID = id;
            Name = name;
            Description = description;
        }
    }
}
