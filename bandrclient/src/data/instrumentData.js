import axios from 'axios';

const baseURL = 'https://localhost:7205/api'

const getAllInstruments = () => new Promise((resolve, reject) => {
    axios
        .get(`${baseURL}/Instrument`).then((response) => resolve(response.data))
        .catch(reject);
})

const getPlayedInstruments = (id) => new Promise((resolve, reject) => {
    axios
        .get(`${baseURL}/PlayedInstrument/user/${id}`).then((response) => resolve(response.data))
        .catch(reject);
})

export { getAllInstruments, getPlayedInstruments };