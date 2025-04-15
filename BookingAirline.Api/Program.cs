using BookingAirline.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Cors
const string _corsPolicyName = "MyDefaultPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(_corsPolicyName, builder =>
    {
        builder.WithOrigins("http://localhost:3002")
        .WithHeaders(
        [
            HeaderNames.ContentType,
            HeaderNames.Authorization
        ]);
    });
});

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(options =>
    {
        options.Authority = "https://dev-ht2q3y0t06uj5efk.us.auth0.com/";
        options.Audience = "https://booking-airline-api.example.com";
    });

var app = builder.Build();

app.UseCors(_corsPolicyName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
