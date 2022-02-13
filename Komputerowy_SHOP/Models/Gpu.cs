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
        [Required]
        public int Id { get; set; }
        [Required]
        public int Id_Product { get; set; }
        [Required]
        [Range(1, 100000)]
        public int VramGB { get; set; }
        [Range(1, 10)]
        [Required]
        public int Gddr { get; set; }
        [Display(Name = "Szybkość (Mhz)")]
        [Range(1, 100000)]
        [Required]
        public int Mhz { get; set; }
    }
}
