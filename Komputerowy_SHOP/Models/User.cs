using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
        public string Username { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
    }
}
