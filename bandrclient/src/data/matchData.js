import axios from 'axios';

const baseURL = 'https://localhost:7205/api'

const createMatch = (matchObj) => new Promise((resolve, reject) => {
    axios
        .post(`${baseURL}/Match`, matchObj)
        .then((response) => resolve(response.data))
        .catch(reject);
});

export default createMatch;