using System.ComponentModel;

namespace ExcursaoApp.Domain.Enums;

public enum UserProfile
{
    [Description("Viajante")] Traveler,
    [Description("Organizador")] Organizer
}