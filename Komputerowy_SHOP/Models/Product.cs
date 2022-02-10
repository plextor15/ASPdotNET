using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komputerowy_SHOP.Models
{
    /*public enum RodzajProduct
    {
        INNE = 0,
        CPU = 1,
        RAM = 2,
        GPU = 3,
        HDD = 4
    }*/

    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Cena")]
        [Column(TypeName = "decimal(18, 2)")]
        public float Price { get; set; }
        [Display(Name = "Ilość")]
        public int Amount { get; set; }
        [Display(Name = "Typ")]
        public int Type { get; set; }

        public string NazwaTypu(int nr)
        {
            string wynik = "lklklkl";

            switch (nr)
            {
                case 0:
                    wynik = "Inne";
                    break;

                case 1:
                    wynik = "CPU";
                    break;

                case 2:
                    wynik = "RAM";
                    break;

                case 3:
                    wynik = "GPU";
                    break;

                case 4:
                    wynik = "HDD";
                    break;
            }

            return wynik;
        }
    }
}
