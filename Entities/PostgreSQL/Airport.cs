using Core.Interfaces;

namespace DatabaseEntities;

/// <summary>
/// Аэропорты
/// </summary>
public partial class Airport : IEntity
{
    /// <summary>
    /// Код аэропорта
    /// </summary>
    public string AirportCode { get; set; } = null!;

    /// <summary>
    /// Название аэропорта
    /// </summary>
    public string AirportName { get; set; } = null!;

    /// <summary>
    /// Город
    /// </summary>
    public string City { get; set; } = null!;

    /// <summary>
    /// Координаты аэропорта: долгота
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Координаты аэропорта: широта
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Временная зона аэропорта
    /// </summary>
    public string Timezone { get; set; } = null!;

    public virtual ICollection<Flight> FlightArrivalAirportNavigations { get; set; } = new List<Flight>();

    public virtual ICollection<Flight> FlightDepartureAirportNavigations { get; set; } = new List<Flight>();
}
