﻿using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class EFContext : DbContext, IEFContext
    {
        public EFContext() : base("ConnectionAgency")
        {
            Database.SetInitializer<EFContext>(null);
        }
        public EFContext(string connString)
            : base(connString)
        {
            Database.SetInitializer<EFContext>(new DBInitializer());
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
