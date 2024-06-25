using ExcursaoApp.Domain.Entities.Base;
using ExcursaoApp.Domain.Entities.User;

namespace ExcursaoApp.Domain.Entities.Tour;

public class TourSubscription : Entity
{
    public bool Active { get; private set; } = true;
    public bool Paid { get; private set; }
    public int SubscriptionNumber { get; private set; }
    public TourEntity Tour { get; private set; }
    public Guid TourId { get; private set; }
    public UserEntity Traveler { get; private set; }
    public Guid TravelerId { get; private set; }

    internal TourSubscription Activate()
    {
        Active = true;
        return this;
    }

    internal TourSubscription Cancel()
    {
        Active = false;
        return this;
    }

    internal TourSubscription ItsPaid()
    {
        Paid = true;
        return this;
    }

    internal TourSubscription SetSubscriptionNumber(int subscriptionNumber)
    {
        SubscriptionNumber = subscriptionNumber;
        return this;
    }

    internal TourSubscription SetTour(TourEntity tour)
    {
        Tour = tour;
        return this;
    }

    internal TourSubscription SetTraveler(UserEntity traveler)
    {
        Traveler = traveler;
        return this;
    }
}