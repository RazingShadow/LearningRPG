using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class DropItem
    {
        public Item Details { get; set; }
        public int dropPercentage { get; set; }
        public bool isDefaultItem { get; set; }
        public DropItem(Item details, int dropPercentage, bool isDefaultItem)
        {
            Details = details;
            this.dropPercentage = dropPercentage;
            this.isDefaultItem = isDefaultItem;
        }
    }
}
