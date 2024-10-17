using Core.Interfaces;

namespace DatabaseEntities;

public partial class FlightsV : IEntity
{
    /// <summary>
    /// Идентификатор рейса
    /// </summary>
    public int? FlightId { get; set; }

    /// <summary>
    /// Номер рейса
    /// </summary>
    public string? FlightNo { get; set; }

    /// <summary>
    /// Время вылета по расписанию
    /// </summary>
    public DateTime? ScheduledDeparture { get; set; }

    /// <summary>
    /// Время вылета по расписанию, местное время в пункте отправления
    /// </summary>
    public DateTime? ScheduledDepartureLocal { get; set; }

    /// <summary>
    /// Время прилёта по расписанию
    /// </summary>
    public DateTime? ScheduledArrival { get; set; }

    /// <summary>
    /// Время прилёта по расписанию, местное время в пункте прибытия
    /// </summary>
    public DateTime? ScheduledArrivalLocal { get; set; }

    /// <summary>
    /// Планируемая продолжительность полета
    /// </summary>
    public TimeSpan? ScheduledDuration { get; set; }

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
    /// Статус рейса
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Код самолета, IATA
    /// </summary>
    public string? AircraftCode { get; set; }

    /// <summary>
    /// Фактическое время вылета
    /// </summary>
    public DateTime? ActualDeparture { get; set; }

    /// <summary>
    /// Фактическое время вылета, местное время в пункте отправления
    /// </summary>
    public DateTime? ActualDepartureLocal { get; set; }

    /// <summary>
    /// Фактическое время прилёта
    /// </summary>
    public DateTime? ActualArrival { get; set; }

    /// <summary>
    /// Фактическое время прилёта, местное время в пункте прибытия
    /// </summary>
    public DateTime? ActualArrivalLocal { get; set; }

    /// <summary>
    /// Фактическая продолжительность полета
    /// </summary>
    public TimeSpan? ActualDuration { get; set; }
}
