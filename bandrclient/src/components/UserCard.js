import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import PropTypes from "prop-types";
import {
  AiFillDislike,
  AiFillQuestionCircle,
  AiFillLike,
} from "react-icons/ai";
import { Modal, Button } from "reactstrap";
import { createMatch, checkRelationship } from "../data/matchData";

export default function UserCard({ user, match }) {
  const [show, setShow] = useState(false);
  const [matchRel, setMatchRel] = useState({});

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const navigate = useNavigate();

  const viewUserProfile = (id) => {
    navigate(`/user/${id}`);
  };

  const swipeRight = () => {
    console.warn(`User: ${user.id}
                    Recipient: ${match.id}`);
    checkRelationship(user.id, match.id, true).then((response) => {
      console.warn(response);
      if (response.recMatch && response.swiperMatch) {
        console.warn("It's a match!");
        setMatchRel(response);
        handleShow();
      } else {
        console.warn(response);
        console.warn("Nope!");
      }
    });
  };

  const swipeLeft = () => {
    const matchObj = {
      swiperId: user.id,
      swiperMatch: false,
      recId: match.id,
      recMatch: false,
    };
    console.warn(matchObj);
    createMatch(matchObj);
  };

  const toMessages = (matchId) => {
    navigate(`/messages/${matchId}`);
  };

  return (
    <div id="userCard">
      <img
        id="userImage"
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
      <div>
        <Modal id="matchModal" animation={false} isOpen={show}>
          <div className="modal-details">
            <div className="col-auto"></div>
            <h1 className="card-title">It's a match!!!</h1>
            <div id="matchUsers">
              <div className="match-user-card">
                <img
                  src={
                    user.photo ||
                    "https://i.pinimg.com/originals/e4/03/de/e403de788507db2505774f48f70a8eab.png"
                  }
                  alt={user.userName}
                />
                <p className="card-text">{user.userName}</p>
              </div>
              <div className="match-user-card">
              <img
                src={
                  match.photo ||
                  "https://i.pinimg.com/originals/e4/03/de/e403de788507db2505774f48f70a8eab.png"
                }
                alt={match.userName}
              />
              <p className="card-text">{match.userName}</p>
              </div>
            </div>
            <div className="match-buttons-div">
              <Button onClick={handleClose}> Keep Swiping </Button>
              <Button onClick={() => toMessages(matchRel.id)}>
                {" "}
                Start Talking!{" "}
              </Button>
            </div>
          </div>
        </Modal>
      </div>
      <div className="button-div">
        <AiFillDislike
          style={{ fontSize: "50px", color: "#DC143C" }}
          onClick={() => swipeLeft()}
        />
        <AiFillQuestionCircle
          style={{ fontSize: "50px", color: "#08c" }}
          className="button-icon"
          onClick={() => {
            viewUserProfile(match.id);
          }}
        />
        <AiFillLike
          style={{ fontSize: "50px", color: "#50C878" }}
          onClick={() => swipeRight()}
        />
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
