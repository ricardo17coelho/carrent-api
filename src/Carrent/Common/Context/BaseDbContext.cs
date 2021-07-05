using Carrent.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.Common.Context
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext()
        {
        }

        protected BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TO"></typeparam>
        /// <typeparam name="TI"></typeparam>
        /// <param name="modelBuilder"></param>
        protected static void ConfigureModelBinding<TO, TI>(ModelBuilder modelBuilder) where TO : class
        {
            SetPrimaryKeys<TO, TI>(modelBuilder);
        }

        /// <summary>
        /// Automatically Bind the primary keys for the dataset
        /// </summary>
        /// <typeparam name="TO"></typeparam>
        /// <typeparam name="TI"></typeparam>
        /// <param name="modelBuilder"></param>
        private static void SetPrimaryKeys<TO, TI>(ModelBuilder modelBuilder) where TO : class
        {
            //Check the Interfaces and choose the correct binder
            if (typeof(IEntity<TI>).IsAssignableFrom(typeof(TO)))
            {
                modelBuilder.Entity<TO>().HasKey(c => ((IEntity<TI>)c).Id);
            }
        }
    }
}
