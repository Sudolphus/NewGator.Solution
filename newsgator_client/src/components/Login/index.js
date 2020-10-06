import React from 'react';
import Card from 'react-bootstrap/Card';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

const Login = () => (
  <Card>
    <Card.Header>
      <Card.Title>Log In</Card.Title>
    </Card.Header>
    <Card.Body>
      <Form>
        <Form.Group controlId="loginName">
          <Form.Label>User Name</Form.Label>
          <Form.Control type='text' placeholder='User Name' />
        </Form.Group>
        <Form.Group controlId='loginPassword'>
          <Form.Label>Password</Form.Label>
          <Form.Control type='password' placeholder='Password' />
        </Form.Group>
        <Button variant="deep-blue" type='submit' block>Log In</Button>
      </Form>
    </Card.Body>
  </Card>
)

export default Login;