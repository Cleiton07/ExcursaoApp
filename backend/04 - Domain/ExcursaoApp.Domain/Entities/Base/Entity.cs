using ExcursaoApp.Domain.Notifications;

namespace ExcursaoApp.Domain.Entities.Base;

public abstract class Entity : Notifiable
{
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public Guid Id { get; private set; } = Guid.NewGuid();
}