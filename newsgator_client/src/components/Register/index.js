import React from 'react';
import Card from 'react-bootstrap/Card';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

const Register = () => (
  <Card>
    <Card.Header>
      <Card.Title>Register An Account</Card.Title>
    </Card.Header>
    <Card.Body>
      <Form>
        <Form.Group controlId="registerName">
          <Form.Label>User Name</Form.Label>
          <Form.Control type='text' placeholder='User Name' />
        </Form.Group>
        <Form.Group controlId="registerPassword">
          <Form.Label>Password</Form.Label>
          <Form.Control type='password' placeholder='Password' />
        </Form.Group>
        <Form.Group controlId='registerPasswordConfirm'>
          <Form.Label>Confirm Password</Form.Label>
          <Form.Control type='password' placeholder='Password' />
        </Form.Group>
        <Button variant="deep-blue" type="submit" block>Register</Button>
      </Form>
    </Card.Body>
  </Card>
)

export default Register;