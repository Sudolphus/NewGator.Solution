import React from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import sources from '../../constants/sources';
import { filterReducer } from './../../reducers';
import * as c from './../../actions/index';


const Filter = () => {
  const initial_state = {
    sources,
    topic: ''
  };

  const [state, dispatch] = React.useReducer(filterReducer, initial_state);

  React.useEffect(() => console.log(state), [state]);

  const handleCheckbox = (source) => {
    const sourceCheck = state.sources.filter(elem => elem === source);
    if (sourceCheck.length > 0) {
      dispatch(c.removeSource(source));
    } else {
      dispatch(c.addSource(source));
    }
  }

  const handleTopic = (topic) => {
    dispatch(c.changeTopic(topic))
  }

  return (
    <Form>
      <div className = "checkbox-container mt-3">
        <h6>Sources: </h6>
        {sources.map(source => <Form.Check key={source} type="checkbox" label={source} defaultChecked={true} inline onClick={() => handleCheckbox(source)} />)}
      </div>
      <Form.Group controlId="topic" className="mt-3">
        <Form.Label>Search By Topic</Form.Label>
        <Form.Control type='search' placeholder='Search' value={state.topic} onChange={topic => handleTopic(topic)} />
      </Form.Group>
      <Button variant='accent-orange' className="mt-3" type='submit' block>Search</Button>
    </Form>
  )
}

export default Filter;