using Core.Interfaces;

namespace DatabaseEntities;

/// <summary>
/// Билеты
/// </summary>
public partial class Ticket : IEntity
{
    /// <summary>
    /// Номер билета
    /// </summary>
    public string TicketNo { get; set; } = null!;

    /// <summary>
    /// Номер бронирования
    /// </summary>
    public string BookRef { get; set; } = null!;

    /// <summary>
    /// Идентификатор пассажира
    /// </summary>
    public string PassengerId { get; set; } = null!;

    /// <summary>
    /// Имя пассажира
    /// </summary>
    public string PassengerName { get; set; } = null!;

    /// <summary>
    /// Контактные данные пассажира
    /// </summary>
    public string? ContactData { get; set; }

    public virtual Booking BookRefNavigation { get; set; } = null!;

    public virtual ICollection<TicketFlight> TicketFlights { get; set; } = new List<TicketFlight>();
}
