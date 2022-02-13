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
        [Required]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Cena")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(1, 100000)]
        [Required]
        public float Price { get; set; }
        [Display(Name = "Ilość")]
        [Range(1, 1000)]
        [Required]
        public int Amount { get; set; }
        [Display(Name = "Typ")]
        [Range(1, 4)]
        [Required]
        public int Type { get; set; }

        public string NazwaTypu()
        {
            string wynik = "lklklkl";

            switch (Type)
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

        public void kupiony() {
            Amount = Amount - 1;
            return;
        }
        public void zwrot()
        {
            Amount = Amount + 1;
            return;
        }
    }
}
