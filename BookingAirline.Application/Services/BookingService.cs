using BookingAirline.Application.Interfaces;
using BookingAirline.Domain.Models;

namespace BookingAirline.Application.Services;

public class BookingService : IBookingService
{
    private List<Flight> _flights;
    public BookingService()
    {
        _flights = new List<Flight>();
        InitializeFlights();
    }
    public async Task AddFlight(Flight flight)
    {
        _flights.Add(flight);
    }

    public async Task BookFlight(Flight flight, Passenger passenger, string seatNumber)
    {
        var ticket = new Ticket(
            passenger,
            flight,
            seatNumber
            );
        flight.BookTicket(ticket);
        Console.WriteLine($"Ticket booked successfully for {passenger.Name} on flight {flight.FlightNumber}.");
    }

    public async Task CancelBooking(string ticketNumber)
    {
        foreach (var flight in _flights)
        {
            var ticket = flight.Tickets.FirstOrDefault(t => t.TicketNumber.ToString() == ticketNumber);
            if (ticket != null)
            {
                flight.CancelTicket(ticket);
                Console.WriteLine($"Booking cancelled for ticket number {ticketNumber}.");
                break;
            }
        }
    }

    public async Task<Flight?> GetFlightBy(string flightNumber)
    {
        return _flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
    }

    public async Task InitializeFlights()
    {
        var flights = new List<Flight>() {
        new Flight("IR101", "THR", "MHD", DateTime.Now.AddHours(2), DateTime.Now.AddHours(4), 120, 750_000),
        new Flight("IR202", "THR", "ISF", DateTime.Now.AddHours(3), DateTime.Now.AddHours(4.5), 100, 620_000),
        new Flight("IR303", "MHD", "BND", new DateTime(2024,03,20), DateTime.Now.AddDays(1).AddHours(3), 85, 890_000),
        new Flight("IR404", "ISF", "SYZ", DateTime.Now.AddDays(2).AddHours(5), DateTime.Now.AddDays(2).AddHours(7), 150, 950_000)
        };
        _flights.AddRange(flights);
    }

    public async Task<List<Flight>> SearchFlights(string departureAirport, string destinationAirport, DateTime date)
    {
        return _flights
            .FindAll(
            f => f.DepartureAirport == departureAirport &&
                                f.DestinationAirport == destinationAirport
                                && f.DepartureTime.Date == date.Date
                                )
            .ToList();
    }
}
