using Horizon.Core.Model;
using Horizon.Data.RelationConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horizon.Data
{
    public class HorizonDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<FeedVisit> FeedVisits { get; set; }

        public HorizonDbContext(DbContextOptions<HorizonDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new AnimalConfiguration());

            builder
                .ApplyConfiguration(new FeedVisitConfiguration());
        }
    }
}
