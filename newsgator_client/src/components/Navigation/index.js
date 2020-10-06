import React from 'react';
// import { Link } from 'react-router-dom';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import * as ROUTES from '../../constants/routes';

const Navigation = () => (
  <Navbar bg="light" expand="lg">
    <Navbar.Toggle aria-controls='basic-navbar-nav' />
    <Navbar.Collapse id='basic-navbar-nav' />
      <Nav className="mr-auto">
        <Nav.Link href={ROUTES.HOME}>Home</Nav.Link>
        <Nav.Link href={ROUTES.RESULTS}>Results</Nav.Link>
        <Nav.Link href={ROUTES.FILTER}>Filter</Nav.Link>
        <Nav.Link href={ROUTES.ACCOUNT}>Account</Nav.Link>
      </Nav>
  </Navbar>
)

export default Navigation;