import React, { useState, useEffect } from 'react';
import { useNavigate, useParams, Link } from 'react-router-dom';
import { getUserMatches } from '../data/matchData';

export default function MatchesView() {
  const [matches, setMatches] = useState([]);

  const navigate = useNavigate();

  const { id } = useParams();

  useEffect(() => {
    let isMounted = true;

    getUserMatches(id).then((response) => {
      if (isMounted) {
        setMatches(response);
      }
    });
    return () => {
      isMounted = false;
    };
  }, [id]);

  return (
    <div>
        <h3> MessagesView</h3>
        {
          matches.map((match) => (
            <Link to={`/messages/${match.id}`}>{match.id}</Link>
          ))
        }
    </div>
  )
}
