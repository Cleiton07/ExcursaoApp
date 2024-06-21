using ExcursaoApp.Domain.Notifications;
using FluentValidation;

namespace ExcursaoApp.Domain.Entities.Base;

public abstract class Entity(IValidator? validator = null) : Notifiable(validator)
{
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public Guid Id { get; private set; } = Guid.NewGuid();
}