import React from 'react'
import { signInUser } from '../data/userData'
import { Button } from 'reactstrap';
import { useNavigate } from 'react-router-dom';

export default function LoginView() {

  const navigate = useNavigate();

  return (
    <div>
        <h3>Welcome to Bandr!</h3>
        <Button onClick={() => {signInUser();
          navigate("/swipe")}}>Sign In</Button>
    </div>
  )
}