using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServingyouApi.Models;

namespace ServingyouApi.Data
{
    public class ServingyouApiContext : DbContext
    {
        public ServingyouApiContext(DbContextOptions<ServingyouApiContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderMenu> OrderMenus { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}
