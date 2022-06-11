import React, { useState, useEffect } from 'react'
import { useParams } from "react-router-dom";
import EditUserForm from '../components/EditUserForm'
import { getSingleUser } from '../data/userData';
import { getPlayedInstruments } from '../data/instrumentData';
import { getPlayedGenres } from '../data/genreData';

export default function EditView() {
  const [profile, setProfile] = useState({});
  const [instruments, setInstruments] = useState([]);
  const [genres, setGenres] = useState([]);

  const { id } = useParams();

  useEffect(() => {
    let isMounted = true;
    if (isMounted) {
      getSingleUser(id).then((profile) => setProfile(profile));
      getPlayedInstruments(id).then((instrumentArr) =>
        setInstruments(instrumentArr)
      );
      getPlayedGenres(id).then((genreArr) => setGenres(genreArr));
    }
    return () => {
      isMounted = false;
    };
  }, [id]);


  return (
    <div>
        <h3>EditView</h3>
        <EditUserForm user={profile} />
    </div>
  )
}
