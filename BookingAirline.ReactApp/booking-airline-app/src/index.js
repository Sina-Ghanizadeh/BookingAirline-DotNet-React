import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { Auth0Provider } from '@auth0/auth0-react';
import App from './App';
import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <Auth0Provider
      domain="dev-ht2q3y0t06uj5efk.us.auth0.com"
      clientId="Gh7YATuLoc5spDGtfTgK5fn1ZAw26FXj"
      authorizationParams={{
        redirect_uri: window.location.origin
      }}
      audience="https://booking-airline-api.example.com"
    >
      <App />
    </Auth0Provider>,
  );
// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
