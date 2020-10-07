import React from 'react';
import PropTypes from 'prop-types';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import sources from '../../constants/sources';
import { filterReducer } from './../../reducers';
import * as c from './../../actions/index';


const Filter = ({ archiveFilter, changeSources, changeTopic, changeAuthor }) => {
  const initial_state = {
    sources,
    topic: '',
    author: ''
  };

  const [state, dispatch] = React.useReducer(filterReducer, initial_state);
  const [dropdown, setDropdown] = React.useState(null);
  const [showFilters, setShowFilters] = React.useState(archiveFilter);

  const show = showFilters ? null : "d-none";
  const onHideShow = () => {setShowFilters(!showFilters)};

  const handleCheckbox = (source) => {
    const sourceCheck = state.sources.filter(elem => elem === source);
    if (sourceCheck.length > 0) {
      dispatch(c.removeSource(source));
    } else {
      dispatch(c.addSource(source));
    }
  }

  const handleDropdown = event => {
    setDropdown(event.target.value);
  }

  const handleTopic = event => {
    const topic = event.target.value;
    dispatch(c.changeTopic(topic));
  }

  const handleAuthor = event => {
    const author = event.target.value;
    dispatch(c.changeAuthor(author))
  }

  const onSubmit = event => {
    event.preventDefault();
    if (archiveFilter) {
      changeSources(dropdown);
    } else {
      changeSources(state.sources);
    }
    changeTopic(state.topic);
    changeAuthor(state.author);
  }

  return (
    <React.Fragment>
      <Button type='button' variant='accent-orange' className="mb-2" onClick={onHideShow}>Show Filters</Button>
      <div className={show}>
        <Form onSubmit={onSubmit} >
          {!archiveFilter && <div className = "checkbox-container mt-3">
            <h6>Sources: </h6>
            {sources.map(source => <Form.Check key={source} type="checkbox" label={source} defaultChecked={true} inline onClick={() => handleCheckbox(source)} />)}
          </div>}
          {archiveFilter && <Form.Group controlId="sourceName" className="mt-3">
              <Form.Label>Select A Source:</Form.Label>
              <Form.Control as="select" defaultValue="Any" onChange={handleDropdown}>
                <option value={null}>Any</option>
                {sources.map(source => <option key={source} value={source}>{source}</option>)}
              </Form.Control>
            </Form.Group>}
          <Form.Group controlId="author" className="mt-3">
            <Form.Label>Search By Author</Form.Label>
            <Form.Control type='search' placeholder='Author Name' value={state.author} onChange={handleAuthor} />
          </Form.Group>
          <Form.Group controlId="topic" className="mt-3">
            <Form.Label>Search By Topic</Form.Label>
            <Form.Control type='search' placeholder='Topic' value={state.topic} onChange={handleTopic} />
          </Form.Group>
          <Button variant='accent-orange' className="mt-3 mb-3" type='submit' block>Search</Button>
        </Form>
      </div>
    </React.Fragment>
  )
}

Filter.propTypes = {
  archiveFilter: PropTypes.bool,
  changeSources: PropTypes.func,
  changeTopic: PropTypes.func,
  changeAuthor: PropTypes.func
}

export default Filter;