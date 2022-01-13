using Horizon.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horizon.Data.RelationConfiguration
{
    public class FeedVisitConfiguration : IEntityTypeConfiguration<FeedVisit>
    {
        public void Configure(EntityTypeBuilder<FeedVisit> builder)
        {
            builder.HasOne(relation => relation.Animal)
                   .WithOne(relation => relation.FeedVisit)
                   .HasForeignKey<FeedVisit>(relation => relation.AnimalId);
        }
    }
}
