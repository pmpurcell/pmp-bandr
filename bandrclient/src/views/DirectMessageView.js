import React, {useState, useEffect} from 'react'
import { useParams, Link } from 'react-router-dom';
import PropTypes from "prop-types";
import { createMessage, getMessagesByMatch } from '../data/messagesData';
import { getSingleUserByFID } from '../data/userData';

const initialState = {
  body: "",
};

export default function DirectMessageView({ user }) {
  const [messages, setMessages] = useState([]);
  const [messageUser, setmessageUser] = useState({});
  const [formInput, setFormInput] = useState(initialState);

  const { convoId } = useParams();

  useEffect(() => {
    let isMounted = true;

    getMessagesByMatch(convoId).then((response) => {
      if (isMounted) {
        setMessages(response);
        getSingleUserByFID(user.firebaseId).then((response) => {
          setmessageUser(response);
        })
      }
    })
    return () => {
      isMounted = false;
    };
  }, [convoId, user.id, messages]);

  
  const handleChange = (e) => {
    setFormInput((prevState) => ({
      ...prevState,
      [e.target.id]: e.target.value,
    }));
  };

  const handleSubmit = (e) => {

    e.preventDefault();
    const messageObj = {
      participantId: messageUser.id,
      matchId: convoId,
      body: formInput.body,
      participant: {
        id: messageUser.id,
        firebaseUid: messageUser.firebaseUid,
        userName: messageUser.userName,
        photo: messageUser.photo,
        skillLevel: messageUser.skillLevel
      }
      // timeSent: Date.now
    }

    createMessage(messageObj).then(getMessagesByMatch(convoId).then(setMessages));
  };

  return (
    <div>
        <h3>DirectMessageView</h3>
        <h4>{convoId}</h4>
        {messages.map((message) => (
          <div>
          <h6>{message.participant.userName}</h6>
          <p>{message.body}</p>
          </div>
        ))}
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
        <Link to={`/matches/${messageUser.id}`}>Go Back</Link>
    </div>
  )
}

DirectMessageView.propTypes = {
  user: PropTypes.shape({}),
};

DirectMessageView.defaultProps = {
  user: {},
};
