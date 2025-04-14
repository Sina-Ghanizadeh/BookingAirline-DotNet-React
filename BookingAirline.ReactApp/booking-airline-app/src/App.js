import React  from 'react';
import SearchForm from './components/search-form';

const App = () => {
  const handleSearch= (data)=>{
    console.log('Search results:', data);
  }
  return (
    <div className='App'>
      <h1>Flight Booking App</h1>
      <SearchForm onSearch={handleSearch} />
    </div>
  );
}

export default App;
