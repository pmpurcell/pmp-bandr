import React, {useState, useEffect} from 'react'
import { useParams, Link } from 'react-router-dom';
import PropTypes from "prop-types";
import { createMessage, getMessagesByMatch } from '../data/messagesData';

const initialState = {
  body: "",
};

export default function DirectMessageView({ user }) {
  const [messages, setMessages] = useState([])
  const [formInput, setFormInput] = useState(initialState);

  const { convoId } = useParams();

  useEffect(() => {
    let isMounted = true;

    getMessagesByMatch(convoId).then((response) => {
      if (isMounted) {
        setMessages(response);
      }
    })
    return () => {
      isMounted = false;
    };
  }, [convoId, messages]);

  
  const handleChange = (e) => {
    setFormInput((prevState) => ({
      ...prevState,
      [e.target.id]: e.target.value,
    }));
  };

  const handleSubmit = (e) => {

    e.preventDefault();
    const messageObj = {
      participantId: user.id,
      matchId: convoId,
      body: formInput.body,
      participant: {
        id: user.id,
        firebaseUid: user.firebaseUid,
        userName: user.userName,
        userAge: user.userAge,
        photo: user.photo,
        skillLevel: user.skillLevel
      }
    }
    console.warn(messageObj);

    createMessage(messageObj).then(getMessagesByMatch(convoId).then(setMessages));
  };

  return (
    <div>
      <div id="conversationDiv">
        <h3>DirectMessageView</h3>
        {messages.map((message) => (
          <div className= {(message.participant.id = user.id) ? "user-message" : "match-message"}>
          <h6>{message.participant.userName}</h6>
          <p>{message.body}</p>
          </div>
        ))}
      </div>
        <form onSubmit={handleSubmit}>
        <label htmlFor="body" className="form-label">
            <input
              type="text"
              className="form-control"
              onChange={handleChange}
              value={formInput.body || ""}
              id="body"
            />
          </label>
        </form>
        <Link to={`/matches/${user.id}`}>Go Back</Link>
    </div>
  )
}

DirectMessageView.propTypes = {
  user: PropTypes.shape({}),
};

DirectMessageView.defaultProps = {
  user: {},
};
