using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiAHL.Models;

namespace ApiAHL.Data
{
    public class ApiAHLContext : DbContext
    {
        public ApiAHLContext (DbContextOptions<ApiAHLContext> options)
            : base(options)
        {
        }

        public DbSet<ApiAHL.Models.Hoteles> Hoteles { get; set; }

        public DbSet<ApiAHL.Models.Habitaciones> Habitaciones { get; set; }

        public DbSet<ApiAHL.Models.Usuarios> Usuarios { get; set; }
    }
}
