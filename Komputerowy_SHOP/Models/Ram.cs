using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komputerowy_SHOP.Models
{
    public class Ram
    {
        public int Id { get; set; }
        public int Id_Product { get; set; }
        [Display(Name = "Pojemność")]
        public int Gb { get; set; }
        public int Ddr { get; set; }
        [Display(Name = "Szybkość (MHz)")]
        public int Mhz { get; set; }
    }
}
