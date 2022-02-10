using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komputerowy_SHOP.Models
{
    public class Gpu
    {
        public int Id { get; set; }
        public int Id_Product { get; set; }
        public int VramGB { get; set; }
        public int Gddr { get; set; }
        [Display(Name = "Szybkość (Mhz)")]
        public int Mhz { get; set; }
    }
}
