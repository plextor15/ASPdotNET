using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komputerowy_SHOP.Models;

//Do przechowywania zmiennych globalnych
namespace Komputerowy_SHOP.Models
{
    public static class GlobalVar
    {
        public static string GlobalUserName { get; set; }
        public static string GlobalUserAdres { get; set; }
        public static int GlobalUserId { get; set; }
        public static int GlobalUserType = 0;
        public static string GlobalProductName { get; set; }
        public static List<Product> GlobalListaZakupow = new List<Product>();
        //public static List<Product> GlobalListaZakupow { get; set; }
        public static int NrDozwrotu = -1; //numer produktu na liscie do zwrotu
        public static float SumaDoZaplaty = 0.0F;
    }
}
