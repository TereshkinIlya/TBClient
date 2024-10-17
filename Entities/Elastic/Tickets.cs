using Core.Interfaces;

namespace Entities.Elastic
{
    public class Tickets : IEntity
    {
        public string ticket_no { get; set; } = null!;
        public string book_ref { get; set; } = null!;
        public string passenger_id { get; set; } = null!;
        public string passenger_name { get; set; } = null!;

    }
}
