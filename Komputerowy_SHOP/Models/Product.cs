using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komputerowy_SHOP.Models
{
    /*public enum RodzajProduct
    { 
        INNE = 0,
        CPU = 1,
        RAM = 2,
        GPU = 3,
        HDD = 4
    }*/

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
        public int Type { get; set; }
    }
}
