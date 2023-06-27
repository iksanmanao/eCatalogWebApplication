using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eCatalogWebApplication.Models;

namespace eCatalogWebApplication.Data
{
    public class eCatalogWebApplicationContext : DbContext
    {
        public eCatalogWebApplicationContext (DbContextOptions<eCatalogWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<eCatalogWebApplication.Models.Catalog> Catalog { get; set; } = default!;
    }
}
