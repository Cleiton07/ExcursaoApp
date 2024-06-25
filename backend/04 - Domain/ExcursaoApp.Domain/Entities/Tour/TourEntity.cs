using ExcursaoApp.Domain.Entities.Base;
using ExcursaoApp.Domain.Entities.User;
using ExcursaoApp.Domain.Enums;

namespace ExcursaoApp.Domain.Entities.Tour;

public class TourEntity() : Entity
{
    public DateTime DeadlineUtc { get; private set; }
    public UserEntity Organizer { get; private set; }
    public Guid OrganizerId { get; private set; }
    public decimal Price { get; private set; }
    public int SubscriptionLimit { get; private set; }
    public List<TourSubscription> Subscriptions { get; private set; } = [];
    public bool SubscriptionsAreFinished { get; private set; }
    public DateTime TourDateTimeUtc { get; private set; }
    public Vehicle Vehicle { get; private set; }

    public TourEntity ActiveSubscription(Guid travelerId)
    {
        if (DateTime.UtcNow < DeadlineUtc)
        {
            var subscription = Subscriptions.FirstOrDefault(x => x.TravelerId == travelerId);
            if (subscription != null && !subscription.Active)
            {
                subscription.Activate();
                SetSubscriptionsAreFinished();
            }
        }

        return this;
    }

    public TourEntity CancelSubscription(Guid travelerId)
    {
        if (DateTime.UtcNow < DeadlineUtc)
        {
            var subscription = Subscriptions.FirstOrDefault(x => x.TravelerId == travelerId);
            if (subscription != null && subscription.Active)
            {
                subscription.Cancel();
                SetSubscriptionsAreFinished();
            }
        }

        return this;
    }

    public TourEntity SetDeadlineUtc(DateTime deadlineUtc)
    {
        DeadlineUtc = deadlineUtc;
        return this;
    }

    public TourEntity SetOrganizer(UserEntity organizer)
    {
        Organizer = organizer;
        OrganizerId = organizer.Id;
        return this;
    }

    public TourEntity SetPrice(decimal price)
    {
        Price = price;
        return this;
    }

    public TourEntity SetSubscriptionLimit(int subscriptionLimit)
    {
        SubscriptionLimit = subscriptionLimit;
        return this;
    }

    public TourEntity SetTourDateTimeUtc(DateTime tourDateTimeUtc)
    {
        TourDateTimeUtc = tourDateTimeUtc;
        return this;
    }

    public TourEntity SetVehicle(Vehicle vehicle)
    {
        Vehicle = vehicle;
        return this;
    }

    public TourEntity Subscribe(UserEntity traveler)
    {
        if (DateTime.UtcNow < DeadlineUtc)
        {
            if (!Subscriptions.Any(x => x.Id == traveler.Id) && Subscriptions.Count(x => x.Active) < SubscriptionLimit)
                Subscriptions.Add(
                    new TourSubscription()
                    .SetTour(this)
                    .SetTraveler(traveler)
                    .SetSubscriptionNumber(Subscriptions.Count + 1));

            SetSubscriptionsAreFinished();
        }

        return this;
    }

    public TourEntity SubscriptionIsPaid(Guid travelerId)
    {
        if (DateTime.UtcNow < DeadlineUtc)
        {
            var subscription = Subscriptions.FirstOrDefault(x => x.TravelerId == travelerId && x.Active);
            subscription?.ItsPaid();
        }

        return this;
    }

    private void SetSubscriptionsAreFinished()
    {
        SubscriptionsAreFinished = Subscriptions.Count(x => x.Active) == SubscriptionLimit;
    }
}