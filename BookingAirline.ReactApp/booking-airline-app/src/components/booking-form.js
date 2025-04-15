import React,{ useState} from "react";
import '../styles/style.css';
import { bookFlight } from "../services/booking-api";
import { useAuth0 } from "@auth0/auth0-react";

const randomSeatNumber = () => {
    //TODO: Read From Server
    const rows = 30; 
    const columns = ['A', 'B', 'C', 'D', 'E', 'F']; 
    const randomRow = Math.floor(Math.random() * rows) + 1; 
    const randomColumn = columns[Math.floor(Math.random() * columns.length)]; 
    return `${randomRow}${randomColumn}`; 
};

const BookingForm = ({ flight }) => {
const [passengerName, setPassengerName] = useState('');
const [passengerEmail, setPassengerEmail] = useState('');
const [passengerPhoneNumber, setPassengerPhone] = useState('');
const { getAccessTokenSilently } = useAuth0();

const handleBooking = async (e) => {
    e.preventDefault();
    const bookingRequest = {
        flightNumber: flight.flightNumber,
        passengerName,
        passengerEmail,
        passengerPhoneNumber,
        seatNumber : randomSeatNumber(),
    };
    const accessToken = await getAccessTokenSilently({
        audience: "https://booking-airline-api.example.com",
    });
    try {
        const response = await bookFlight(bookingRequest,accessToken);
        console.log('Booking successful:', response.data);
    } catch (error) {
        console.error('Error during booking:', error);
    }
};
return (
    <div className="container booking-form">
        <h2>Book Flight: {flight.flightNumber}</h2>
        <form onSubmit={handleBooking}>
            <label>Passenger Name</label>
            <input
                type="text"
                placeholder="Passenger Name"
                value={passengerName}
                onChange={(e) => setPassengerName(e.target.value)}
                required
            />
            <label>Passenger Email</label>
            <input
                type="email"
                placeholder="Passenger Email"
                value={passengerEmail}
                onChange={(e) => setPassengerEmail(e.target.value)}
                required
            />
            <label>Passenger Phone</label>
            <input
                type="tel"
                placeholder="Passenger Phone"
                value={passengerPhoneNumber}
                onChange={(e) => setPassengerPhone(e.target.value)}
                required
            />
            <button type="submit">Confirm Booking</button>
        </form>
    </div>
);
    
};

export default BookingForm;