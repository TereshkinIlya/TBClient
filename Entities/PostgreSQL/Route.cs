using Core.Interfaces;

namespace DatabaseEntities;

public partial class Route : IEntity
{
    /// <summary>
    /// Номер рейса
    /// </summary>
    public string? FlightNo { get; set; }

    /// <summary>
    /// Код аэропорта отправления
    /// </summary>
    public string? DepartureAirport { get; set; }

    /// <summary>
    /// Название аэропорта отправления
    /// </summary>
    public string? DepartureAirportName { get; set; }

    /// <summary>
    /// Город отправления
    /// </summary>
    public string? DepartureCity { get; set; }

    /// <summary>
    /// Код аэропорта прибытия
    /// </summary>
    public string? ArrivalAirport { get; set; }

    /// <summary>
    /// Название аэропорта прибытия
    /// </summary>
    public string? ArrivalAirportName { get; set; }

    /// <summary>
    /// Город прибытия
    /// </summary>
    public string? ArrivalCity { get; set; }

    /// <summary>
    /// Код самолета, IATA
    /// </summary>
    public string? AircraftCode { get; set; }

    /// <summary>
    /// Продолжительность полета
    /// </summary>
    public TimeSpan? Duration { get; set; }

    /// <summary>
    /// Дни недели, когда выполняются рейсы
    /// </summary>
    public List<int>? DaysOfWeek { get; set; }
}
