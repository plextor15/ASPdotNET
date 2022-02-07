using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Komputerowy_SHOP.Models;

namespace Komputerowy_SHOP.Data
{
    public class Komputerowy_SHOPContext : DbContext
    {
        public Komputerowy_SHOPContext (DbContextOptions<Komputerowy_SHOPContext> options)
            : base(options)
        {
        }

        public DbSet<Komputerowy_SHOP.Models.User> User { get; set; }

        public DbSet<Komputerowy_SHOP.Models.Adres> Adres { get; set; }

        public DbSet<Komputerowy_SHOP.Models.Cpu> Cpu { get; set; }

        public DbSet<Komputerowy_SHOP.Models.Gpu> Gpu { get; set; }

        public DbSet<Komputerowy_SHOP.Models.Hdd> Hdd { get; set; }

        public DbSet<Komputerowy_SHOP.Models.Ram> Ram { get; set; }

        public DbSet<Komputerowy_SHOP.Models.Product> Product { get; set; }
    }
}
