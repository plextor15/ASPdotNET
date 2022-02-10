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
        public int Id { get; set; }
        public int Id_Product { get; set; }
        [Display(Name = "Pojemność (Gb)")]
        public int Gb { get; set; }
        [Display(Name = "RPM")]
        public int Rpm { get; set; }
    }
}
