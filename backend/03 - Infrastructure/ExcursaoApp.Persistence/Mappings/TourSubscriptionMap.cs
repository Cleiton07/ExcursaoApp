using ExcursaoApp.Domain.Entities.Tour;
using ExcursaoApp.Persistence.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExcursaoApp.Persistence.Mappings;

public class TourSubscriptionMap : EntityMap<TourSubscription>
{
    protected override string TableName => "ToursSubscriptions";

    public override void MapEntity(EntityTypeBuilder<TourSubscription> builder)
    {
        builder.Property(x => x.Active).IsRequired();
        builder.Property(x => x.Paid).IsRequired();
        builder.Property(x => x.SubscriptionNumber).IsRequired();
        builder.Property(x => x.TourId).IsRequired();

        builder.HasOne(x => x.Traveler).WithMany().HasForeignKey(x => x.TravelerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
    }
}