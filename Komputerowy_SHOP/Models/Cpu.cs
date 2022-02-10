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
        public int Id { get; set; }
        public int Id_Product { get; set; }
        [Display(Name = "Szybkość (GHz)")]
        //[Column(TypeName = "decimal(5, 1)")]
        public float Ghz { get; set; }
        [Display(Name = "Ilość rdzeni")]
        public int Core { get; set; }
    }
}
