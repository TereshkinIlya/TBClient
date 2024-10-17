using Core.Interfaces;

namespace DatabaseEntities;

/// <summary>
/// Перелеты
/// </summary>
public partial class TicketFlight : IEntity
{
    /// <summary>
    /// Номер билета
    /// </summary>
    public string TicketNo { get; set; } = null!;

    /// <summary>
    /// Идентификатор рейса
    /// </summary>
    public int FlightId { get; set; }

    /// <summary>
    /// Класс обслуживания
    /// </summary>
    public string FareConditions { get; set; } = null!;

    /// <summary>
    /// Стоимость перелета
    /// </summary>
    public decimal Amount { get; set; }

    public virtual BoardingPass? BoardingPass { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual Ticket TicketNoNavigation { get; set; } = null!;
}
