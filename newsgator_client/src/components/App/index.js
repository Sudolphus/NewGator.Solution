import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import { StoryContext } from './../StoryList';
import Container from 'react-bootstrap/Container';
import Navigation from './../Navigation';
import Results from './../Results';
import Filter from './../Filter';
import Account from './../Account';
import * as ROUTES from '../../constants/routes';
import stories from '../../constants/stories';


const App = () => (
  <StoryContext.Provider value={stories} >
    <Container fluid>
      <Router>
        <Navigation />
        <Route exact path={ROUTES.HOME} component={Results} />
        <Route path={ROUTES.FILTER} component={Filter} />
        <Route path={ROUTES.ACCOUNT} component={Account} />
      </Router>
    </Container>
  </StoryContext.Provider>
)

export default App;