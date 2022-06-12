import { useState, useEffect } from "react";
import PropTypes from "prop-types";
import { Button } from "reactstrap";
import {
  getAllUsers,
  getSingleUser,
  getSingleUserByFID,
  signInUser,
  signOutUser,
} from "../data/userData";
import UserCard from "../components/UserCard";
import { useNavigate } from "react-router-dom";

export default function SwipeView({ user }) {
  const [loggedInUser, setLoggedInUser] = useState({});
  const [userList, setUserList] = useState([]);
  const [match, setMatch] = useState({});

  const navigate = useNavigate();

  useEffect(() => {
    let isMounted = true;
    getAllUsers(user.id).then((response) => {
      if (isMounted) {
        setUserList(response);
      }
    });
    return () => {
      isMounted = false;
    };
  }, [userList, loggedInUser.id, user.firebaseUid]);

  const findMatch = () => {
    let random = Math.floor(Math.random() * userList.length);
    console.warn(random);
    setMatch(userList[random]);
  };

  const myProfile = (id) => {
      navigate(`/user/${id}`)
  };

  const editProfile = (id) => {
      navigate(`/user/edit/${id}`)
  };

  const viewMatches = (id) => {
      navigate(`/matches/${id}`)
  };


  return (
    <div>
      <p>Welcome to Bandr, {user.name}!</p>
      <UserCard user={user} match={match} />
      <Button onClick={signInUser}>Sign In</Button>
      <Button onClick={signOutUser}>Sign Out</Button>
      <Button onClick={findMatch}>Find A Match</Button>
      <Button onClick={() => {viewMatches(user.id)}}>Messages</Button>
      <Button onClick={() => {editProfile(user.id)}}>Edit Profile</Button>
      <Button
        onClick={() => {
          myProfile(user.id);
        }}
      >
        My Profile
      </Button>
    </div>
  );
}

SwipeView.propTypes = {
  user: PropTypes.shape({}),
};

SwipeView.defaultProps = {
  user: {},
};
