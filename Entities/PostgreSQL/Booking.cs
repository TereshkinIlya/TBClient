using Core.Interfaces;

namespace DatabaseEntities;

/// <summary>
/// Бронирования
/// </summary>
public partial class Booking : IEntity
{
    /// <summary>
    /// Номер бронирования
    /// </summary>
    public string BookRef { get; set; } = null!;

    /// <summary>
    /// Дата бронирования
    /// </summary>
    public DateTime BookDate { get; set; }

    /// <summary>
    /// Полная сумма бронирования
    /// </summary>
    public decimal TotalAmount { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
