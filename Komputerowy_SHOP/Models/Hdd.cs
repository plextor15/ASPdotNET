using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komputerowy_SHOP.Models
{
    public class Hdd
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Id_Product { get; set; }
        [Display(Name = "Pojemność (Gb)")]
        [Range(1, 100000)]
        [Required]
        public int Gb { get; set; }
        [Display(Name = "RPM")]
        [Range(1, 100000)]
        [Required]
        public int Rpm { get; set; }
    }
}
