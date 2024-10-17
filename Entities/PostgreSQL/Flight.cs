using Core.Interfaces;

namespace DatabaseEntities;

/// <summary>
/// Рейсы
/// </summary>
public partial class Flight : IEntity
{
    /// <summary>
    /// Идентификатор рейса
    /// </summary>
    public int FlightId { get; set; }

    /// <summary>
    /// Номер рейса
    /// </summary>
    public string FlightNo { get; set; } = null!;

    /// <summary>
    /// Время вылета по расписанию
    /// </summary>
    public DateTime ScheduledDeparture { get; set; }

    /// <summary>
    /// Время прилёта по расписанию
    /// </summary>
    public DateTime ScheduledArrival { get; set; }

    /// <summary>
    /// Аэропорт отправления
    /// </summary>
    public string DepartureAirport { get; set; } = null!;

    /// <summary>
    /// Аэропорт прибытия
    /// </summary>
    public string ArrivalAirport { get; set; } = null!;

    /// <summary>
    /// Статус рейса
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// Код самолета, IATA
    /// </summary>
    public string AircraftCode { get; set; } = null!;

    /// <summary>
    /// Фактическое время вылета
    /// </summary>
    public DateTime? ActualDeparture { get; set; }

    /// <summary>
    /// Фактическое время прилёта
    /// </summary>
    public DateTime? ActualArrival { get; set; }

    public virtual Aircraft AircraftCodeNavigation { get; set; } = null!;

    public virtual Airport ArrivalAirportNavigation { get; set; } = null!;

    public virtual Airport DepartureAirportNavigation { get; set; } = null!;

    public virtual ICollection<TicketFlight> TicketFlights { get; set; } = new List<TicketFlight>();
}
