import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import { StoryContext } from './../StoryList';
import Container from 'react-bootstrap/Container';
import Navigation from './../Navigation';
import Results from './../Results';
import Account from './../Account';
import * as ROUTES from '../../constants/routes';
import stories from '../../constants/stories';


const App = () => {
  const [storyList, setStoryList] = React.useState(null);
  const [search, setSearch] = React.useState(null);

  React.useEffect(() => { 
    setStoryList(stories);
  }, [storyList])

  return (
    <StoryContext.Provider value={storyList} >
      <Container fluid>
        <Router>
          <Navigation changeSearch={setSearch} />
          <Route exact path={ROUTES.HOME} render={() => <Results search={search} />} />
          <Route path={ROUTES.ACCOUNT} component={Account} />
        </Router>
      </Container>
    </StoryContext.Provider>
  )
}

export default App;