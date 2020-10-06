import React from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

const sources = ["BBC News", "Associated Press", "Reuters", "Bloomberg", "New York Times", "CBS News", "Wall Street Journal", "Washington Post", "Politico"];

const Filter = () => (
  <Form>
    <Form.Group controlId="topic">
      <Form.Label>Search By Topic</Form.Label>
      <Form.Control type='search' placeholder='Search' />
    </Form.Group>
    <div className = "checkbox-container">
      <h6>Sources: </h6>
      {sources.map(source => <Form.Check key={source} type="checkbox" label={source} defaultChecked={true} inline />)}
    </div>
    <Form.Group controlId="date-range">
      <Form.Label>Filter By Oldest Date</Form.Label>
      <Form.Control type='date' defaultValue={Date.now()} />
    </Form.Group>
    <Button variant='accent-orange' type='submit' block>Search</Button>
  </Form>
)

export default Filter;