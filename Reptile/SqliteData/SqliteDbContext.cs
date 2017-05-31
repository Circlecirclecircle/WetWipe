using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace SqliteData
{
    public class SqliteDbContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Shop> Shops { get; set; }

        
    }
}
