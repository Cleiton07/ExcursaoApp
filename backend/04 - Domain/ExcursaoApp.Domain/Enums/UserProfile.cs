using System.ComponentModel;

namespace ExcursaoApp.Domain.Enums;

public enum UserProfile
{
    [Description("Viajante")] Traveler = 1,
    [Description("Organizador")] Organizer = 2
}