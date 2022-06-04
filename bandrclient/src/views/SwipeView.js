import { useState, useEffect } from 'react';
import PropTypes from "prop-types";
import { Button } from 'reactstrap';
import { getAllUsers, getSingleUser, signInUser, signOutUser } from '../data/userData';
import UserCard from '../components/UserCard';

export default function SwipeView({ user }) {
    const [userList, setUserList] = useState([]);
    const [match, setMatch] = useState({});

    useEffect(() => {
        let isMounted = true;
      
          getAllUsers().then((response) => {
            if (isMounted){
              setUserList(response)
            }},);
          return () => {
            isMounted = false
          }
        }, [userList]);

        const findMatch = () => {
            let random = Math.floor(Math.random() * userList.length + 1);
            console.warn(random);
            getSingleUser(random).then(response => setMatch(response))
            };

  return (
    <div>
      <p>Welcome to Bandr!</p>
      <UserCard user={match}/>
      <p>{user.name}</p>
      <Button onClick={signInUser}>Sign In</Button>
      <Button onClick={signOutUser}>Sign Out</Button>
      <Button onClick={findMatch}>Find A Match</Button>
    </div>
  )
}


SwipeView.propTypes = {
  user: PropTypes.shape({
  }),
};

SwipeView.defaultProps = {
  user: {},
};