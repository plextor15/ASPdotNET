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
        [Required]
        public int Id { get; set; }
        [Required]
        public int Id_Product { get; set; }
        [Display(Name = "Pojemność")]
        [Range(1, 1000)]
        [Required]
        public int Gb { get; set; }
        [Range(1, 6)]
        [Required]
        public int Ddr { get; set; }
        [Display(Name = "Szybkość (MHz)")]
        [Range(1, 10000)]
        [Required]
        public int Mhz { get; set; }
    }
}
