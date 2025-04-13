namespace BookingAirline.Domain.Models;

public class Passenger
{
    public Guid PassengerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Ticket> Tickets { get; set; }
    public Passenger(string name, string email,string phoneNumber)
    {
        PassengerId = Guid.NewGuid();
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Tickets = new List<Ticket>();
    }
    public void GetPassengerDetails()
    {
        Console.WriteLine($"Passenger ID: {PassengerId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Phone Number: {PhoneNumber}");
    }
}