import React from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

const sources = ["BBC News", "Associated Press", "Reuters", "Bloomberg", "New York Times", "CBS News", "Wall Street Journal", "Washington Post", "Politico"];

const Filter = () => (
  <Form>
    <div className = "checkbox-container mt-3">
      <h6>Sources: </h6>
      {sources.map(source => <Form.Check key={source} type="checkbox" label={source} defaultChecked={true} inline />)}
    </div>
    <Form.Group controlId="topic" className="mt-3">
      <Form.Label>Search By Topic</Form.Label>
      <Form.Control type='search' placeholder='Search' />
    </Form.Group>
    <Button variant='accent-orange' className="mt-3" type='submit' block>Search</Button>
  </Form>
)

export default Filter;