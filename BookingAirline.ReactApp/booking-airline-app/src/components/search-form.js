import React, { useState } from 'react';
import '../styles/style.css';
import { searchFlights } from '../services/booking-api';

const SearchForm = ({ onSearch }) => {

    const [departureAirport, setDepartureAirport] = useState('');
    const [destinationAirport, setDestinationAirport] = useState('');
    const [date, setDate] = useState('');

    const handleSearch = async (e) => {
        e.preventDefault();
        try {
            const response = await searchFlights(departureAirport, destinationAirport, date);
            onSearch(response.data);
        } catch (error) {
            console.error('Error during search:', error);
        }
    };
    return (
        <form className='search-form' onSubmit={handleSearch}>
            <input type='text' placeholder='Departure Airport' value={departureAirport} onChange={(e) => setDepartureAirport(e.target.value)} />
            <input type='text' placeholder='Destination Airport' value={destinationAirport} onChange={(e) => setDestinationAirport(e.target.value)} />
            <input type='date' value={date} onChange={(e) => setDate(e.target.value)}></input>
            <button type="submit">Search</button>
        </form>
    )
};

export default SearchForm;