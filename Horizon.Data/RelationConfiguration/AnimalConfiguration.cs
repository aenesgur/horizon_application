using Horizon.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horizon.Data.RelationConfiguration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasOne(relation => relation.FeedVisit)
                 .WithOne(relation => relation.Animal)
                 .HasForeignKey<FeedVisit>(relation => relation.AnimalId);
        }
    }
}
