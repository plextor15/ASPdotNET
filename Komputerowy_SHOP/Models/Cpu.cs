using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komputerowy_SHOP.Models
{
    public class Cpu
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Id_Product { get; set; }
        [Display(Name = "Szybkość (GHz)")]
        [Range(1, 100)]
        [Required]
        public float Ghz { get; set; }
        [Display(Name = "Ilość rdzeni")]
        [Range(1, 64)]
        [Required]
        public int Core { get; set; }
    }
}
