using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Komputerowy_SHOP.Models
{
    /*public enum RodzajUser 
    { 
        GUEST = 0,
        ADMIN = 1,
        USER = 2
    }*/

    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        public string Username { get; set; }
        [Display(Name = "Haslo")]
        public string Password { get; set; }
        public int Type { get; set; }
    }
}
