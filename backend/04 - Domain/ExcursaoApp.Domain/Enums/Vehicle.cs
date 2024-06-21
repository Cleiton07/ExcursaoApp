using System.ComponentModel;

namespace ExcursaoApp.Domain.Enums;

public enum Vehicle
{
    [Description("Carro")] Car = 1,
    [Description("Ônibus")] Bus = 2,
    [Description("Van")] Van = 3
}