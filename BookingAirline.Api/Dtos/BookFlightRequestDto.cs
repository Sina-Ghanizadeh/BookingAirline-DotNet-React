namespace BookingAirline.Api.Dtos;

public record BookFlightRequestDto(string FlightNumber, string PassengerName, string PassengerEmail, string SeatNumber, string PassengerPhoneNumber);
