using BookingAirline.Domain.Models;

namespace BookingAirline.Application.Interfaces;

public interface IBookingService
{
    Task AddFlight(Flight flight);
    Task<List<Flight>> SearchFlights(string departureAirport, string destinationAirport, DateTime date);
    Task<Flight?> GetFlightBy(string flightNumber);
    Task BookFlight(Flight flight, Passenger passenger,string seatNumber);
    Task CancelBooking(string ticketNumber);
    Task InitializeFlights();
}
