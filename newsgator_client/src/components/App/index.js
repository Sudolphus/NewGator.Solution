import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import { StoryContext } from './../StoryList';
import Container from 'react-bootstrap/Container';
import Navigation from './../Navigation';
import Home from './../Home';
import Account from './../Account';
import Archive from './../Archive';
import * as ROUTES from '../../constants/routes';
// import stories from '../../constants/stories';


const App = () => {
  const [storyList, setStoryList] = React.useState(null);
  const [search, setSearch] = React.useState(null);
  const [error, setError] = React.useState(null);

  React.useEffect(() => {
    async function getStoryList() {
      try {
        const today = new Date();
        const todayString = today.getMonth()+1 + "/" + today.getDate() + "/" + today.getFullYear();
        const response = await fetch(`http://localhost:5000/api/Info?date=${todayString}`);
        const jsonResponse = await response.json();
        setStoryList(jsonResponse);
        setError(null);
      } catch(err) {
        setError(err.message);
      }
    }
    getStoryList();
  }, []);

  return (
    <StoryContext.Provider value={storyList} >
      <Container fluid>
        <Router>
          <Navigation changeSearch={setSearch} />
          <Route exact path={ROUTES.HOME} render={() => <Home search={search} error={error} />} />
          <Route path={ROUTES.ARCHIVE} component={Archive} />
          <Route path={ROUTES.ACCOUNT} component={Account} />
        </Router>
      </Container>
    </StoryContext.Provider>
  )
}

export default App;