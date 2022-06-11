import React, { useState, useEffect } from "react";
import { useParams, Link } from "react-router-dom";
import EditUserForm from "../components/EditUserForm";
import { getSingleUser } from "../data/userData";
import {
  getPlayedInstruments,
  getAllInstruments,
  addPlayedInstruments,
  removePlayedInstruments
} from "../data/instrumentData";
import { getPlayedGenres } from "../data/genreData";
import { Button } from "reactstrap";

export default function EditView() {
  const [profile, setProfile] = useState({});
  const [allInstruments, setAllInstruments] = useState([]);
  const [playedInstruments, setPlayedInstruments] = useState([]);
  const [playedGenres, setPlayedGenres] = useState([]);

  const { id } = useParams();

  useEffect(() => {
    let isMounted = true;
    if (isMounted) {
      getSingleUser(id).then((profile) => setProfile(profile));
      getAllInstruments().then((instrumentArr) =>
        setAllInstruments(instrumentArr)
      );
      getPlayedInstruments(id).then((instrumentArr) =>
        setPlayedInstruments(instrumentArr)
      );
      getPlayedGenres(id).then((genreArr) => setPlayedGenres(genreArr));
    }
    return () => {
      isMounted = false;
    };
  }, [id, playedInstruments, playedGenres, allInstruments]);

  const addInstruments = (userId, instrumentId, instrumentName) => {
    addPlayedInstruments(userId, instrumentId, instrumentName);
  };

  const removeInstruments = (instrumentId) => {
    removePlayedInstruments(instrumentId);
  };

  return (
    <div>
      <h3>EditView</h3>
      <EditUserForm user={profile} />
      {playedInstruments.map((playedInstrument) => (
        <div>
          <p>{playedInstrument.instrument.instrumentName}</p>
          <Button onClick={() => removeInstruments(playedInstrument.id)}>Remove</Button>
        </div>
      ))}
      {allInstruments.map((instrument) => (
        <div>
          <p>{instrument.instrumentName}</p>
          <Button onClick={() => addInstruments(profile.id, instrument.id, instrument.instrumentName)}> Add Instrument</Button>
        </div>
      ))}
      {playedGenres.map((playedGenre) => (
        <p>{playedGenre.genre.genreName}</p>
      ))}
      <Link to="/swipe">Go Back</Link>
    </div>
  );
}
