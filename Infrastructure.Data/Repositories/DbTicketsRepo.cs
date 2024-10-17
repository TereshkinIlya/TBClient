using Core.Interfaces;
using Database;
using DatabaseEntities;
using Elastic.Clients.Elasticsearch.MachineLearning;
using Entities.Elastic;
using Infrastrucrure.Dto;
using Infrastrucrure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastrucrure.Repositories
{
    internal class DbTicketsRepo : IDbRepository<IEntity>
    {
        IDataContext<DemoContext> Airflights { get; set; }
        public DbTicketsRepo([FromKeyedServices("AirflightsDB")] IDataContext<DbContext> dbContext)
        {
            Airflights = (IDataContext<DemoContext>)dbContext;
        }

        public async Task<IEnumerable<IEntity>> GetByDocumentsAsync(IEnumerable<IEntity> elasticDocs)
        {
            List<IEntity> trips = new(); 

            foreach (var doc in elasticDocs)
            {
                var airFlight = await (from ticket in Airflights.DataBase.Tickets
                                 where ticket.TicketNo == (doc as Tickets)!.ticket_no
                                 join ticketFlight in Airflights.DataBase.TicketFlights on ticket.TicketNo equals ticketFlight.TicketNo
                                 join flight in Airflights.DataBase.Flights on ticketFlight.FlightId equals flight.FlightId
                                 join depAirport in Airflights.DataBase.Airports on flight.DepartureAirport equals depAirport.AirportCode
                                 join Arrairport in Airflights.DataBase.Airports on flight.DepartureAirport equals Arrairport.AirportCode
                                 select new Trip
                                 {
                                     Name = ticket.PassengerName,
                                     DepAirport = depAirport.AirportName,
                                     ArrAirport = Arrairport.AirportName,
                                     DepTime = flight.ActualDeparture,
                                     ArrTime = flight.ActualArrival
                                 }).ToListAsync();
                
                trips.AddRange(airFlight);
            }
            return trips;
        }
    }
}
