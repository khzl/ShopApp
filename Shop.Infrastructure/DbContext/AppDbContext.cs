// Pseudocode / Plan:
// 1. Identify root cause: the namespace `Shop.Infrastructure.DbContext` conflicts with the type name `DbContext`.
//    In C#, an unqualified identifier resolves to a namespace in the current namespace scope before types,
//    causing the compiler error CS0118: "'DbContext' is a namespace but is used like a type".
// 2. Fix strategy: explicitly reference the EF Core DbContext type to avoid the name collision.
//    - Option A (minimal change): qualify the base class as Microsoft.EntityFrameworkCore.DbContext.
//    - Option B (alternative): rename the current namespace to avoid the suffix "DbContext" (not applied here).
// 3. Apply minimal change: change the base class declaration to use the fully qualified type name.
// 4. Keep all other existing code and using directives unchanged.
//
// Implementation below applies Option A.

using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define DbSet properties for each entity to be mapped to database tables 
        public DbSet<Entity_Customer> Customers { get; set; }
        public DbSet<Entity_RefreshToken> RefreshTokens { get; set; } 
        public DbSet<Entity_Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            /*
             * ApplyConfigurationsFromAssembly
             * هذا يقرأ كل ملفات 
             * Configuration تلقائيا 
             */

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}