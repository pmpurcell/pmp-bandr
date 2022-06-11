import axios from "axios";

const baseURL = "https://localhost:7205/api";

const getAllGenres = () =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Genre`)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

const getPlayedGenres = (id) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/PlayedGenre/user/${id}`)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

const addPlayedGenre = (userId, genreId, genreName) =>
  new Promise((resolve, reject) => {
    const playedObj = {
      userId: userId,
      genreId: genreId,
      genre: {
        id: genreId,
        genreName: genreName,
      },
    };
    axios
      .post(`${baseURL}/PlayedGenre`, playedObj)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

const removePlayedGenres = (genreId) =>
  new Promise((resolve, reject) => {
    axios
      .delete(`${baseURL}/PlayedGenre/${genreId}`)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

export { getAllGenres, getPlayedGenres, addPlayedGenre, removePlayedGenres };
