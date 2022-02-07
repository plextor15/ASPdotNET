using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komputerowy_SHOP.Models
{
    public class Gpu
    {
        public int Id { get; set; }
        public int Id_Product { get; set; }
        public int VramGB { get; set; }
        public int Gddr { get; set; }
        public int Mhz { get; set; }
    }
}
