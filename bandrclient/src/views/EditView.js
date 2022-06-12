import React, { useState, useEffect } from "react";
import { useParams, Link } from "react-router-dom";
import EditUserForm from "../components/EditUserForm";
import { getSingleUser } from "../data/userData";
import {
  getPlayedInstruments,
  getAllInstruments,
  addPlayedInstruments,
  removePlayedInstruments,
} from "../data/instrumentData";
import {
  getPlayedGenres,
  getAllGenres,
  addPlayedGenre,
  removePlayedGenres,
} from "../data/genreData";
import { Button } from "reactstrap";

export default function EditView() {
  const [profile, setProfile] = useState({});
  const [allInstruments, setAllInstruments] = useState([]);
  const [playedInstruments, setPlayedInstruments] = useState([]);
  const [allGenres, setAllGenres] = useState([]);
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
      getAllGenres().then((genreArr) => setAllGenres(genreArr));
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

  const addGenres = (userId, genreId, genreName) => {
    addPlayedGenre(userId, genreId, genreName);
  };

  const removeGenres = (genreId) => {
    removePlayedGenres(genreId);
  };

  return (
    <div>
      <h3>EditView</h3>
      <EditUserForm user={profile} />
      <div className="edit-item-div">
        <div className="item-div">
          {playedInstruments.map((playedInstrument) => (
            <div>
              <p>{playedInstrument.instrument.instrumentName}</p>
              <Button onClick={() => removeInstruments(playedInstrument.id)}>
                Remove
              </Button>
            </div>
          ))}
        </div>
        <div className="item-div">
          {allInstruments.map((instrument) => (
            <div>
              <p>{instrument.instrumentName}</p>
              <Button
                onClick={() =>
                  addInstruments(
                    profile.id,
                    instrument.id,
                    instrument.instrumentName
                  )
                }
              >
                {" "}
                Add Instrument
              </Button>
            </div>
          ))}
        </div>
      </div>
      <div className="edit-item-div">
        <div className="item-div">
          {playedGenres.map((playedGenre) => (
            <div key={playedGenre.id}>
              <p>{playedGenre.genre.genreName}</p>
              <Button onClick={() => removeGenres(playedGenre.id)}>
                Remove Genre
              </Button>
            </div>
          ))}
        </div>
        <div className="item-div">
          {allGenres.map((genre) => (
            <div>
              <p>{genre.genreName}</p>
              <Button
                onClick={() => {
                  addGenres(profile.id, genre.id, genre.genreName);
                }}
              >
                Add Genre
              </Button>
            </div>
          ))}
        </div>
      </div>
      <Link to="/swipe">Go Back</Link>
    </div>
  );
}
