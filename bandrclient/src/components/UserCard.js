import React from "react";
import { useNavigate } from "react-router-dom";
import PropTypes from "prop-types";
import {
  AiFillDislike,
  AiFillQuestionCircle,
  AiFillLike,
} from "react-icons/ai";
import { createMatch, checkRelationship } from "../data/matchData";
import { getSingleUserByFID } from "../data/userData";

export default function UserCard({ user, match }) {
  const navigate = useNavigate();

  const viewUserProfile = (id) => {
    navigate(`/user/${id}`);
  };

  const swipeRight = () => {
    getSingleUserByFID(user.firebaseId).then((response) => {
      console.warn(response);
      console.warn(`User: ${response.id}
                    Recipient: ${match.id}`);
      checkRelationship(response.id, match.id, true).then((response) => {
        console.warn(response);
        if (response.recMatch && response.swiperMatch) {
          console.warn("It's a match!");
          navigate("/match", user, match);
        } else {
          console.warn(response);
          console.warn("Nope!");
        }
      });
    });
  };

  const swipeLeft = () => {
    getSingleUserByFID(user.firebaseId).then((response) => {
      const matchObj = {
        swiperId: response.id,
        swiperMatch: false,
        recId: match.id,
        recMatch: false,
      };
      console.warn(matchObj);
      createMatch(matchObj);
    });
  };

  return (
    <div>
      <img
        src={
          match.photo ||
          "https://i.pinimg.com/originals/e4/03/de/e403de788507db2505774f48f70a8eab.png"
        }
        alt={match.userName}
        width="250px"
        height="300px"
      />
      <div className="user-info">
        <h3>{match.userName}</h3>
        <h3>{match.userAge}</h3>
      </div>
      <div></div>
      <div className="button-div">
        <AiFillDislike onClick={() => swipeLeft()} />
        <AiFillQuestionCircle
          onClick={() => {
            viewUserProfile(match.id);
          }}
        />
        <AiFillLike onClick={() => swipeRight()} />
      </div>
    </div>
  );
}

UserCard.propTypes = {
  user: PropTypes.shape({}),
  match: PropTypes.shape({}).isRequired,
};

UserCard.defaultProps = {
  user: {},
};
