using BookingAirline.Api.Dtos;
using BookingAirline.Application.Interfaces;
using BookingAirline.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingAirline.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly ILogger<BookingController> _logger;
    private readonly IBookingService _bookingService;

    public BookingController(ILogger<BookingController> logger, IBookingService bookingService)
    {
        _logger = logger;
        _bookingService = bookingService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetFlights(string departureAirport, string destinationAirport, DateTime date)
    {
        var flights = await _bookingService.SearchFlights(departureAirport, destinationAirport, date);
        return Ok(flights);
    }
    [HttpPost("book")]
    [Authorize]
    public async Task<IActionResult> BookFlight([FromBody] BookFlightRequestDto requestDto)
    {
        var passenger = new Passenger(requestDto.PassengerName, requestDto.PassengerPhoneNumber, requestDto.PassengerEmail);
        var flight = await _bookingService.GetFlightBy(requestDto.FlightNumber);
        if (flight == null)
        {
            return NotFound("Flight not found");
        }
        await _bookingService.BookFlight(flight, passenger, requestDto.SeatNumber);
        return Ok("Booking successful");
    }
    [HttpDelete("cancel/{ticketNumber}")]
    public async Task<IActionResult> CancelBooking(string ticketNumber)
    {
        await _bookingService.CancelBooking(ticketNumber);
        return Ok("Booking cancelled");
    }
}
