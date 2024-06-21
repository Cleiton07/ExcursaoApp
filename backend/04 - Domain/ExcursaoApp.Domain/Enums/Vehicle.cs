using System.ComponentModel;

namespace ExcursaoApp.Domain.Enums;

public enum Vehicle
{
    [Description("Carro")] Car,
    [Description("Ônibus")] Bus,
    [Description("Van")] Van
}