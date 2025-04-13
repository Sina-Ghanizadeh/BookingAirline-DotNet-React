namespace BookingAirline.Domain.Models;

public class Ticket
{
    public Guid TicketNumber { get; set; }
    public Passenger Passenger { get; set; }
    public Flight Flight { get; set; }
    public string SeatNumber { get; set; }

    public Ticket(Passenger passenger, Flight flight, string seatNumber)
    {
        TicketNumber = Guid.NewGuid();
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