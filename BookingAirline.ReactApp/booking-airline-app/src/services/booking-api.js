import axios from 'axios';


const API_BASE_URL = 'http://localhost:5073/';

export const searchFlights = async (departureAirport,destinationAirport, date) => {
  try {
    const response = await axios.get(`${API_BASE_URL}Booking/Search`, {
      params: {
        departureAirport,
        destinationAirport,
        date,
      },
    });
    return response;
  } catch (error) {
    console.error('Error searching flights:', error);
    throw error;
  }
}

export const bookFlight = async (bookFlightRequest) => {
    try {
        const response = await axios.post(`${API_BASE_URL}Booking/book`, bookFlightRequest, {
        headers: {
            'Content-Type': 'application/json',
        },
        });
        return response;
    } catch (error) {
        console.error('Error booking flight:', error);
        throw error;
    }
}