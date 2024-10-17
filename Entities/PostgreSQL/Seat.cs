using Core.Interfaces;

namespace DatabaseEntities;

/// <summary>
/// Места
/// </summary>
public partial class Seat : IEntity
{
    /// <summary>
    /// Код самолета, IATA
    /// </summary>
    public string AircraftCode { get; set; } = null!;

    /// <summary>
    /// Номер места
    /// </summary>
    public string SeatNo { get; set; } = null!;

    /// <summary>
    /// Класс обслуживания
    /// </summary>
    public string FareConditions { get; set; } = null!;

    public virtual Aircraft AircraftCodeNavigation { get; set; } = null!;
}
