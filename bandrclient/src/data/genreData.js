import axios from 'axios';

const baseURL = 'https://localhost:7205/api'

const getAllGenres = () => new Promise((resolve, reject) => {
    axios
        .get(`${baseURL}/Genre`).then((response) => resolve(response.data))
        .catch(reject);
})

const getPlayedGenres = (id) => new Promise((resolve, reject) => {
    axios
        .get(`${baseURL}/PlayedGenre/user/${id}`).then((response) => resolve(response.data))
        .catch(reject);
})

export { getAllGenres, getPlayedGenres };