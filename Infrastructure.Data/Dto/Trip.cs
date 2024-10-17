using Core.Interfaces;

namespace Infrastrucrure.Dto
{
    internal class Trip : IEntity
    {
        public string? Name { get; set; }
        public string? DepAirport { get; set; }
        public string? ArrAirport { get; set; }
        public DateTime? DepTime { get; set; }
        public DateTime? ArrTime { get; set; }
    }
}
