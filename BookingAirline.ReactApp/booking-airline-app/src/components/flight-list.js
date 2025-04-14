import React, { useState } from "react";
import '../styles/style.css';
import BookingForm from "./booking-form";

const FlightList = ({flights}) => {
    const [selectedFlight, setSelectedFlight] = useState(null);

    const handleFlightSelect = (flight) => {
        setSelectedFlight(flight);
    }

    return (
        <div className="flight-list">
            <h2>Available Flights</h2>
            {flights.map(flight => (
                <div key={flight.flightNumber} className="flight-card"
                // onClick={() => handleFlightSelect(flight)}
                >
                    <h3>{flight.flightNumber}</h3>
                    <p>{flight.departureAirport} to {flight.destinationAirport}</p>
                    <p> Departure Time: {flight.departureTime}</p>
                    <p> Arrival Time: {flight.arrivalTime}</p>
                    <p> Price: ${flight.ticketPrice}</p>
                    <button className="book-btn" onClick={()=>handleFlightSelect(flight)}>Book Flight</button>
                </div>
            ))}
            {selectedFlight && <BookingForm flight={selectedFlight} />}
        </div>
    );
};

export default FlightList;