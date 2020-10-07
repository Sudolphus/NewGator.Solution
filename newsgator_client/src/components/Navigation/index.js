import React from 'react';
import PropTypes from 'prop-types';
import { useHistory } from 'react-router-dom';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import * as ROUTES from '../../constants/routes';

const Navigation = ({ changeSearch }) => {
  const [search, setSearch] = React.useState('');
  const history = useHistory();

  const onChange = event => {
    setSearch(event.target.value);
  }

  const onSubmit = event => {
    event.preventDefault();
    changeSearch(search);
    setSearch('');
    history.push(ROUTES.HOME);
  }

  return (
    <Navbar expand="lg">
      <Nav>
        <Nav.Link href={ROUTES.HOME}>Home</Nav.Link>
        <Nav.Link href={ROUTES.ARCHIVE}>Search Archives</Nav.Link>
        <Nav.Link href={ROUTES.ACCOUNT}>Account</Nav.Link>
      </Nav>
      <Form className="ml-auto" inline onSubmit={onSubmit}>
        <Form.Control type='search' placeholder='Search' className='mr-sm-2' value={search} onChange={onChange} />
        <Button variant='accent-orange' type='submit'>Search</Button>
      </Form>
    </Navbar>
  )
}

Navigation.propTypes = {
  changeSearch: PropTypes.func
}

export default Navigation;