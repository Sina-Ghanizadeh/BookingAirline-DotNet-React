namespace BookingAirline.Domain.Models;

public class Flight
{
    public string FlightNumber { get; set; }
    public string DepartureAirport { get; set; }
    public string DestinationAirport { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int Capacity { get; set; }
    public int AvailableSeats { get; set; }
    public decimal TicketPrice { get; set; }
    public List<Ticket> Tickets { get; set; }

    public Flight(string flightNumber, string departureAirport, string destinationAirport, DateTime departureTime, DateTime arrivalTime, int capacity, decimal ticketPrice)
    {
        FlightNumber = flightNumber;
        DepartureAirport = departureAirport;
        DestinationAirport = destinationAirport;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
        Capacity = capacity;
        AvailableSeats = capacity;
        TicketPrice = ticketPrice;
        Tickets = new List<Ticket>();
    }

    public void GetFlightDetails()
    {
        Console.WriteLine($"Flight Number: {FlightNumber}");
        Console.WriteLine($"From: {DepartureAirport} To: {DestinationAirport}");
        Console.WriteLine($"Departure Time: {DepartureTime}, Arrival Time: {ArrivalTime}");
        Console.WriteLine($"Available Seats: {AvailableSeats}/{Capacity}");
        Console.WriteLine($"Ticket Price: {TicketPrice:C}");
    }
    public int CheckAvailableSeats()
    {
        return AvailableSeats;
    }
    public void BookTicket(Ticket ticket)
    {
        if (AvailableSeats > 0)
        {
            Tickets.Add(ticket);
            AvailableSeats--;
            ticket.Passenger.Tickets.Add(ticket);
        }
        else
        {
            Console.WriteLine("No available seats.");
        }
    }

    public void CancelTicket(Ticket ticket)
    {
        Tickets.Remove(ticket);
        AvailableSeats++;
        ticket.Passenger.Tickets.Remove(ticket);
    }
}
