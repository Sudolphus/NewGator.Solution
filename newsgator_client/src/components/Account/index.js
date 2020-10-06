import React from 'react';
import Login from './../Login';
import Register from './../Register';


const Account = () => (
  <React.Fragment>
    <h2>Account Control</h2>
    <div className='account-card-wrapper'>
      <Login />
      <Register />
    </div>
  </React.Fragment>
)

export default Account;