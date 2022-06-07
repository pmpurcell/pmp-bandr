import React from 'react'
import { signInUser } from '../data/userData'
import { Button } from 'reactstrap';

export default function LoginView() {

  return (
    <div>
        <h3>Welcome to Bandr!</h3>
        <Button onClick={signInUser}>Sign In</Button>
    </div>
  )
}