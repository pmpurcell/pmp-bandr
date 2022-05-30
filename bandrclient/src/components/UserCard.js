import React from 'react'
import { AiFillDislike, AiFillQuestionCircle, AiFillLike } from "react-icons/ai";

export default function UserCard({user}) {
  return (
    <div>
        <img src={user.photo} alt={user.userName} width='250px' height='300px' />
        <div className='user-info'>
            <h3>{user.userName}</h3>
            <h3>{user.userAge}</h3>
        </div>
        <div className='button-div'>
            <AiFillDislike onClick={() => console.warn("Disliked!")} />
            <AiFillQuestionCircle onClick={() => console.warn("Info")}/>
            <AiFillLike onClick={() => console.warn('Liked!')} />
        </div>
    </div>
  ) 
}
