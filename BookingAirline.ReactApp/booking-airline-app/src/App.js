import React, { useState }  from 'react';
import SearchForm from './components/search-form';
import FlightList from './components/flight-list';

const App = () => {
  const [flights, setFlights] = useState([]);
  const handleSearch= (data)=>{
    console.log('Search results:', data);
    setFlights(data);
  }
  return (
    <div className='App'>
      <h1>Flight Booking App</h1>
      <SearchForm onSearch={handleSearch} />
      {flights.length > 0 ? (
        <FlightList flights={flights} />
      ) : (
        <p>No flights available. Please search for flights.</p>
      )}
    </div>
  );
}

export default App;
