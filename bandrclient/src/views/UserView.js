import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom';
import { getSingleUser } from '../data/userData';
import { Link } from 'react-router-dom';
import { getPlayedInstruments } from '../data/instrumentData';

export default function UserView() {
const [profile, setProfile] = useState({});
const [instruments, setInstruments] = useState([]);

const { id } = useParams();

  useEffect(() => {
    let isMounted = true;
    if (isMounted) {
     getSingleUser(id).then((profile) => setProfile(profile));
     getPlayedInstruments(id).then((instruments => setInstruments(instruments)));
    }
    return () => {
      isMounted = false;
    };
  }, [id]);

  return (
    <div>
      <h3>UserView</h3>
      <img src={profile.photo} alt={profile.userName} width='250px' height='300px' />
      <p>{profile.userName}</p>
      <p>{profile.userAge}</p>
      <p>{profile.location}</p>
      <p>{profile.userBio}</p>
      <p>Instruments</p>
      {instruments.map((instrument) => (
          <p>{instrument.instrument.instrumentName}</p>
        ))}
      <Link to="/">Go Back</Link>
    </div>
  )
}