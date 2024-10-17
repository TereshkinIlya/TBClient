using Core.Interfaces;
using DatabaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public partial class DemoContext : DbContext, IDataContext<DemoContext>
{
    public DemoContext DataBase => this;
    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aircraft> Aircrafts { get; set; }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<BoardingPass> BoardingPasses { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FlightsV> FlightsVs { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketFlight> TicketFlights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aircraft>(entity =>
        {
            entity.HasKey(e => e.AircraftCode).HasName("aircrafts_pkey");

            entity.ToTable("aircrafts", "bookings", tb => tb.HasComment("Самолеты"));

            entity.Property(e => e.AircraftCode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Код самолета, IATA")
                .HasColumnName("aircraft_code");
            entity.Property(e => e.Model)
                .HasComment("Модель самолета")
                .HasColumnName("model");
            entity.Property(e => e.Range)
                .HasComment("Максимальная дальность полета, км")
                .HasColumnName("range");
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.AirportCode).HasName("airports_pkey");

            entity.ToTable("airports", "bookings", tb => tb.HasComment("Аэропорты"));

            entity.Property(e => e.AirportCode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Код аэропорта")
                .HasColumnName("airport_code");
            entity.Property(e => e.AirportName)
                .HasComment("Название аэропорта")
                .HasColumnName("airport_name");
            entity.Property(e => e.City)
                .HasComment("Город")
                .HasColumnName("city");
            entity.Property(e => e.Latitude)
                .HasComment("Координаты аэропорта: широта")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasComment("Координаты аэропорта: долгота")
                .HasColumnName("longitude");
            entity.Property(e => e.Timezone)
                .HasComment("Временная зона аэропорта")
                .HasColumnName("timezone");
        });

        modelBuilder.Entity<BoardingPass>(entity =>
        {
            entity.HasKey(e => new { e.TicketNo, e.FlightId }).HasName("boarding_passes_pkey");

            entity.ToTable("boarding_passes", "bookings", tb => tb.HasComment("Посадочные талоны"));

            entity.HasIndex(e => new { e.FlightId, e.BoardingNo }, "boarding_passes_flight_id_boarding_no_key").IsUnique();

            entity.HasIndex(e => new { e.FlightId, e.SeatNo }, "boarding_passes_flight_id_seat_no_key").IsUnique();

            entity.Property(e => e.TicketNo)
                .HasMaxLength(13)
                .IsFixedLength()
                .HasComment("Номер билета")
                .HasColumnName("ticket_no");
            entity.Property(e => e.FlightId)
                .HasComment("Идентификатор рейса")
                .HasColumnName("flight_id");
            entity.Property(e => e.BoardingNo)
                .HasComment("Номер посадочного талона")
                .HasColumnName("boarding_no");
            entity.Property(e => e.SeatNo)
                .HasMaxLength(4)
                .HasComment("Номер места")
                .HasColumnName("seat_no");

            entity.HasOne(d => d.TicketFlight).WithOne(p => p.BoardingPass)
                .HasForeignKey<BoardingPass>(d => new { d.TicketNo, d.FlightId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("boarding_passes_ticket_no_fkey");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookRef).HasName("bookings_pkey");

            entity.ToTable("bookings", "bookings", tb => tb.HasComment("Бронирования"));

            entity.Property(e => e.BookRef)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("Номер бронирования")
                .HasColumnName("book_ref");
            entity.Property(e => e.BookDate)
                .HasComment("Дата бронирования")
                .HasColumnName("book_date");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(10, 2)
                .HasComment("Полная сумма бронирования")
                .HasColumnName("total_amount");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("flights_pkey");

            entity.ToTable("flights", "bookings", tb => tb.HasComment("Рейсы"));

            entity.HasIndex(e => new { e.FlightNo, e.ScheduledDeparture }, "flights_flight_no_scheduled_departure_key").IsUnique();

            entity.Property(e => e.FlightId)
                .HasComment("Идентификатор рейса")
                .HasColumnName("flight_id");
            entity.Property(e => e.ActualArrival)
                .HasComment("Фактическое время прилёта")
                .HasColumnName("actual_arrival");
            entity.Property(e => e.ActualDeparture)
                .HasComment("Фактическое время вылета")
                .HasColumnName("actual_departure");
            entity.Property(e => e.AircraftCode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Код самолета, IATA")
                .HasColumnName("aircraft_code");
            entity.Property(e => e.ArrivalAirport)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Аэропорт прибытия")
                .HasColumnName("arrival_airport");
            entity.Property(e => e.DepartureAirport)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Аэропорт отправления")
                .HasColumnName("departure_airport");
            entity.Property(e => e.FlightNo)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("Номер рейса")
                .HasColumnName("flight_no");
            entity.Property(e => e.ScheduledArrival)
                .HasComment("Время прилёта по расписанию")
                .HasColumnName("scheduled_arrival");
            entity.Property(e => e.ScheduledDeparture)
                .HasComment("Время вылета по расписанию")
                .HasColumnName("scheduled_departure");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasComment("Статус рейса")
                .HasColumnName("status");

            entity.HasOne(d => d.AircraftCodeNavigation).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AircraftCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flights_aircraft_code_fkey");

            entity.HasOne(d => d.ArrivalAirportNavigation).WithMany(p => p.FlightArrivalAirportNavigations)
                .HasForeignKey(d => d.ArrivalAirport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flights_arrival_airport_fkey");

            entity.HasOne(d => d.DepartureAirportNavigation).WithMany(p => p.FlightDepartureAirportNavigations)
                .HasForeignKey(d => d.DepartureAirport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("flights_departure_airport_fkey");
        });

        modelBuilder.Entity<FlightsV>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("flights_v", "bookings");

            entity.Property(e => e.ActualArrival)
                .HasComment("Фактическое время прилёта")
                .HasColumnName("actual_arrival");
            entity.Property(e => e.ActualArrivalLocal)
                .HasComment("Фактическое время прилёта, местное время в пункте прибытия")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("actual_arrival_local");
            entity.Property(e => e.ActualDeparture)
                .HasComment("Фактическое время вылета")
                .HasColumnName("actual_departure");
            entity.Property(e => e.ActualDepartureLocal)
                .HasComment("Фактическое время вылета, местное время в пункте отправления")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("actual_departure_local");
            entity.Property(e => e.ActualDuration)
                .HasComment("Фактическая продолжительность полета")
                .HasColumnName("actual_duration");
            entity.Property(e => e.AircraftCode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Код самолета, IATA")
                .HasColumnName("aircraft_code");
            entity.Property(e => e.ArrivalAirport)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Код аэропорта прибытия")
                .HasColumnName("arrival_airport");
            entity.Property(e => e.ArrivalAirportName)
                .HasComment("Название аэропорта прибытия")
                .HasColumnName("arrival_airport_name");
            entity.Property(e => e.ArrivalCity)
                .HasComment("Город прибытия")
                .HasColumnName("arrival_city");
            entity.Property(e => e.DepartureAirport)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Код аэропорта отправления")
                .HasColumnName("departure_airport");
            entity.Property(e => e.DepartureAirportName)
                .HasComment("Название аэропорта отправления")
                .HasColumnName("departure_airport_name");
            entity.Property(e => e.DepartureCity)
                .HasComment("Город отправления")
                .HasColumnName("departure_city");
            entity.Property(e => e.FlightId)
                .HasComment("Идентификатор рейса")
                .HasColumnName("flight_id");
            entity.Property(e => e.FlightNo)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("Номер рейса")
                .HasColumnName("flight_no");
            entity.Property(e => e.ScheduledArrival)
                .HasComment("Время прилёта по расписанию")
                .HasColumnName("scheduled_arrival");
            entity.Property(e => e.ScheduledArrivalLocal)
                .HasComment("Время прилёта по расписанию, местное время в пункте прибытия")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduled_arrival_local");
            entity.Property(e => e.ScheduledDeparture)
                .HasComment("Время вылета по расписанию")
                .HasColumnName("scheduled_departure");
            entity.Property(e => e.ScheduledDepartureLocal)
                .HasComment("Время вылета по расписанию, местное время в пункте отправления")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduled_departure_local");
            entity.Property(e => e.ScheduledDuration)
                .HasComment("Планируемая продолжительность полета")
                .HasColumnName("scheduled_duration");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasComment("Статус рейса")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("routes", "bookings");

            entity.Property(e => e.AircraftCode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Код самолета, IATA")
                .HasColumnName("aircraft_code");
            entity.Property(e => e.ArrivalAirport)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Код аэропорта прибытия")
                .HasColumnName("arrival_airport");
            entity.Property(e => e.ArrivalAirportName)
                .HasComment("Название аэропорта прибытия")
                .HasColumnName("arrival_airport_name");
            entity.Property(e => e.ArrivalCity)
                .HasComment("Город прибытия")
                .HasColumnName("arrival_city");
            entity.Property(e => e.DaysOfWeek)
                .HasComment("Дни недели, когда выполняются рейсы")
                .HasColumnName("days_of_week");
            entity.Property(e => e.DepartureAirport)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Код аэропорта отправления")
                .HasColumnName("departure_airport");
            entity.Property(e => e.DepartureAirportName)
                .HasComment("Название аэропорта отправления")
                .HasColumnName("departure_airport_name");
            entity.Property(e => e.DepartureCity)
                .HasComment("Город отправления")
                .HasColumnName("departure_city");
            entity.Property(e => e.Duration)
                .HasComment("Продолжительность полета")
                .HasColumnName("duration");
            entity.Property(e => e.FlightNo)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("Номер рейса")
                .HasColumnName("flight_no");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => new { e.AircraftCode, e.SeatNo }).HasName("seats_pkey");

            entity.ToTable("seats", "bookings", tb => tb.HasComment("Места"));

            entity.Property(e => e.AircraftCode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Код самолета, IATA")
                .HasColumnName("aircraft_code");
            entity.Property(e => e.SeatNo)
                .HasMaxLength(4)
                .HasComment("Номер места")
                .HasColumnName("seat_no");
            entity.Property(e => e.FareConditions)
                .HasMaxLength(10)
                .HasComment("Класс обслуживания")
                .HasColumnName("fare_conditions");

            entity.HasOne(d => d.AircraftCodeNavigation).WithMany(p => p.Seats)
                .HasForeignKey(d => d.AircraftCode)
                .HasConstraintName("seats_aircraft_code_fkey");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketNo).HasName("tickets_pkey");

            entity.ToTable("tickets", "bookings", tb => tb.HasComment("Билеты"));

            entity.Property(e => e.TicketNo)
                .HasMaxLength(13)
                .IsFixedLength()
                .HasComment("Номер билета")
                .HasColumnName("ticket_no");
            entity.Property(e => e.BookRef)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("Номер бронирования")
                .HasColumnName("book_ref");
            entity.Property(e => e.ContactData)
                .HasComment("Контактные данные пассажира")
                .HasColumnType("jsonb")
                .HasColumnName("contact_data");
            entity.Property(e => e.PassengerId)
                .HasMaxLength(20)
                .HasComment("Идентификатор пассажира")
                .HasColumnName("passenger_id");
            entity.Property(e => e.PassengerName)
                .HasComment("Имя пассажира")
                .HasColumnName("passenger_name");

            entity.HasOne(d => d.BookRefNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.BookRef)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tickets_book_ref_fkey");
        });

        modelBuilder.Entity<TicketFlight>(entity =>
        {
            entity.HasKey(e => new { e.TicketNo, e.FlightId }).HasName("ticket_flights_pkey");

            entity.ToTable("ticket_flights", "bookings", tb => tb.HasComment("Перелеты"));

            entity.Property(e => e.TicketNo)
                .HasMaxLength(13)
                .IsFixedLength()
                .HasComment("Номер билета")
                .HasColumnName("ticket_no");
            entity.Property(e => e.FlightId)
                .HasComment("Идентификатор рейса")
                .HasColumnName("flight_id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasComment("Стоимость перелета")
                .HasColumnName("amount");
            entity.Property(e => e.FareConditions)
                .HasMaxLength(10)
                .HasComment("Класс обслуживания")
                .HasColumnName("fare_conditions");

            entity.HasOne(d => d.Flight).WithMany(p => p.TicketFlights)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_flights_flight_id_fkey");

            entity.HasOne(d => d.TicketNoNavigation).WithMany(p => p.TicketFlights)
                .HasForeignKey(d => d.TicketNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_flights_ticket_no_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
