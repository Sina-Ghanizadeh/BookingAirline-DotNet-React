namespace BookingAirline.Domain.Models;

public class Ticket
{
    public string TicketNumber { get; set; }
    public Passenger Passenger { get; set; }
    public Flight Flight { get; set; }
    public string SeatNumber { get; set; }

    public Ticket(string ticketNumber, Passenger passenger, Flight flight, string seatNumber)
    {
        TicketNumber = ticketNumber;
        Passenger = passenger;
        Flight = flight;
        SeatNumber = seatNumber;
    }
    public void GetTicketDetails()
    {
        Console.WriteLine($"Ticket Number: {TicketNumber}");
        Console.WriteLine($"Passenger: {Passenger.Name}");
        Console.WriteLine($"Flight: {Flight.FlightNumber}");
        Console.WriteLine($"Seat Number: {SeatNumber}");
    }
}