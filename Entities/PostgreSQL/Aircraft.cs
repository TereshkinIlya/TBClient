using Core.Interfaces;

namespace DatabaseEntities;

/// <summary>
/// Самолеты
/// </summary>
public partial class Aircraft : IEntity
{
    /// <summary>
    /// Код самолета, IATA
    /// </summary>
    public string AircraftCode { get; set; } = null!;

    /// <summary>
    /// Модель самолета
    /// </summary>
    public string Model { get; set; } = null!;

    /// <summary>
    /// Максимальная дальность полета, км
    /// </summary>
    public int Range { get; set; }

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
