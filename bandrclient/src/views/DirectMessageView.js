import React, {useState, useEffect} from 'react'
import { useParams } from 'react-router-dom';
import { getMessagesByMatch } from '../data/messagesData';

export default function DirectMessageView() {
  const [messages, setMessages] = useState([]);

  const { convoId } = useParams();

  useEffect(() => {
    let isMounted = true;

    getMessagesByMatch(convoId).then((response) => {
      if (isMounted) {
        setMessages(response);
      }
    });
    return () => {
      isMounted = false;
    };
  }, [convoId]);

  return (
    <div>
        <h3>DirectMessageView</h3>
        {messages.map((message) => (
          <div>
          <h6>{message.participantId}</h6>
          <p>{message.body}</p>
          </div>
        ))}
    </div>
  )
}
