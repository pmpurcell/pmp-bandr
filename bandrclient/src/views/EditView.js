import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import EditUserForm from "../components/EditUserForm";
import { getSingleUser } from "../data/userData";
import { getPlayedInstruments } from "../data/instrumentData";
import { getPlayedGenres } from "../data/genreData";

export default function EditView() {
  const [profile, setProfile] = useState({});
  const [playedInstruments, setplayedInstruments] = useState([]);
  const [playedGenres, setplayedGenres] = useState([]);

  const { id } = useParams();

  useEffect(() => {
    let isMounted = true;
    if (isMounted) {
      getSingleUser(id).then((profile) => setProfile(profile));
      getPlayedInstruments(id).then((instrumentArr) =>
        setplayedInstruments(instrumentArr)
      );
      console.warn(playedInstruments);
      getPlayedGenres(id).then((genreArr) => setplayedGenres(genreArr));
    }
    return () => {
      isMounted = false;
    };
  }, [id]);

  return (
    <div>
      <h3>EditView</h3>
      <EditUserForm user={profile} />
      {playedInstruments.map((playedInstrument) => {
        <p>{playedInstrument.instrument.instrumentName}</p>;
      })}
      {playedGenres.map((playedGenre) => {
        <p>{playedGenre.genre.genreName}</p>;
      })}
    </div>
  );
}
