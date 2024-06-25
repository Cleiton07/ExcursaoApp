using ExcursaoApp.Domain.Entities.Tour;
using ExcursaoApp.Persistence.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExcursaoApp.Persistence.Mappings;

public class TourMap : EntityMap<TourEntity>
{
    protected override string TableName => "Tours";

    public override void MapEntity(EntityTypeBuilder<TourEntity> builder)
    {
        builder.Property(x => x.DeadlineUtc).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.SubscriptionLimit).IsRequired();
        builder.Property(x => x.SubscriptionsAreFinished).IsRequired();
        builder.Property(x => x.TourDateTimeUtc).IsRequired();
        builder.Property(x => x.Vehicle).IsRequired();

        builder.HasOne(x => x.Organizer).WithMany().HasForeignKey(x => x.OrganizerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.Subscriptions).WithOne(x => x.Tour).HasForeignKey(x => x.TourId).OnDelete(DeleteBehavior.Cascade);
    }
}