using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komputerowy_SHOP.Models
{
    public class Adres
    {
        public int Id { get; set; }
        public string Ulica { get; set; }
        public string Nr { get; set; }
        public string Miasto { get; set; }
        public string Kod_Pocztowy { get; set; }
        public int Kto { get; set; }
    }
}
