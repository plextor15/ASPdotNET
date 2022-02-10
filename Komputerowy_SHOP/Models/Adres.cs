using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komputerowy_SHOP.Models
{
    public class Adres
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa ulicy")]
        public string Ulica { get; set; }
        public string Nr { get; set; }
        public string Miasto { get; set; }
        [Display(Name = "Kod pocztowy")]
        public string Kod_Pocztowy { get; set; }
        public int Kto { get; set; }
    }
}
