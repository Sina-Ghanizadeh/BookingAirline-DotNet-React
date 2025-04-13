using BookingAirline.Application.Interfaces;
using BookingAirline.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookingAirline.Infrastructure;

public static class DependencyContainer
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBookingService, BookingService>();
    }
}
