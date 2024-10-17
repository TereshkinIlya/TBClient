using Core.Interfaces;

namespace DatabaseEntities;

/// <summary>
/// Посадочные талоны
/// </summary>
public partial class BoardingPass : IEntity
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
    /// Номер посадочного талона
    /// </summary>
    public int BoardingNo { get; set; }

    /// <summary>
    /// Номер места
    /// </summary>
    public string SeatNo { get; set; } = null!;

    public virtual TicketFlight TicketFlight { get; set; } = null!;
}
