using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using exeInventario.Models;

namespace exeInventario.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<exeInventario.Models.Cad_Clientes> Cad_Clientes { get; set; } = default!;

        public DbSet<exeInventario.Models.Cad_Maquinas> Cad_Maquinas { get; set; } = default!;

        public DbSet<exeInventario.Models.Inventario> Inventario { get; set; } = default!;
    }
}
