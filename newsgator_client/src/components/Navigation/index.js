import React from 'react';
// import { Link } from 'react-router-dom';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import * as ROUTES from '../../constants/routes';

const Navigation = () => (
  <Navbar expand="lg">
    <Nav>
      <Nav.Link href={ROUTES.HOME}>Home</Nav.Link>
      <Nav.Link href={ROUTES.FILTER}>Filter</Nav.Link>
      <Nav.Link href={ROUTES.ACCOUNT}>Account</Nav.Link>
    </Nav>
    <Form className="ml-auto" inline>
      <Form.Control type='search' placeholder='Search' className='mr-sm-2' />
      <Button variant='accent-orange' type='submit'>Search</Button>
    </Form>
  </Navbar>
)

export default Navigation;