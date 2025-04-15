import React, { useState }  from 'react';
import SearchForm from './components/search-form';
import FlightList from './components/flight-list';
import LoginButton from './components/buttons/login-button';
import LogoutButton from './components/buttons/logout-button';
import ProfilePage from './pages/profile-page';

const App = () => {
  const [flights, setFlights] = useState([]);
  const handleSearch= (data)=>{
    console.log('Search results:', data);
    setFlights(data);
  }
  return (
    <div className='App'>
      <h1>Flight Booking App</h1>
      <div className='auth-buttons'>
        <LoginButton />
        <LogoutButton />
        <ProfilePage />
      </div>
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
