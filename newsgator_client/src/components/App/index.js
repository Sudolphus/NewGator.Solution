import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import Navigation from './../Navigation';
import Results from './../Results';
import Filter from './../Filter';
import Account from './../Account';
import * as ROUTES from '../../constants/routes';

const App = () => (
  <Router>
    <Navigation />
    <Route exact path={ROUTES.HOME} component={Results} />
    <Route path={ROUTES.FITLER} component={Filter} />
    <Route path={ROUTES.ACCOUNT} component={Account} />
  </Router>
)

export default App;