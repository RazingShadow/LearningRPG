using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestRewardItem
    {
        public Item Details { get; set; }
        public int Quantity { get; set; }
        public QuestRewardItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
