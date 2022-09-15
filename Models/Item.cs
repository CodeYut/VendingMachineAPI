using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachineAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }
    }
}
