import { useState, useEffect } from 'react';
import PropTypes from "prop-types";
import { Button } from 'reactstrap';
import { getAllUsers, getSingleUser, getSingleUserByFID, signInUser, signOutUser } from '../data/userData';
import UserCard from '../components/UserCard';
import { useNavigate } from 'react-router-dom';

export default function SwipeView({ user }) {
    const [userList, setUserList] = useState([]);
    const [match, setMatch] = useState({});

    const navigate = useNavigate();

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

        const myProfile = (firebaseUid) => {
getSingleUserByFID(firebaseUid).then((response) => navigate(`/user/${response.id}`));
        }

  return (
    <div>
      <p>Welcome to Bandr, {user.name}!</p>
      <UserCard user={user} match={match}/>
      <Button onClick={signInUser}>Sign In</Button>
      <Button onClick={signOutUser}>Sign Out</Button>
      <Button onClick={findMatch}>Find A Match</Button>
      <Button onClick={() => {myProfile(user.firebaseId)}}>My Profile</Button>
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