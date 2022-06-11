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

const addPlayedInstruments = (userId, instrumentId, instrumentName) => new Promise((resolve, reject) => {
    const playedObj = {
        userId: userId,
        instrumentId: instrumentId,
        instrument: {
          id: instrumentId,
          instrumentName: instrumentName
        }
    }
    axios
        .post(`${baseURL}/PlayedInstrument`, playedObj).then((response) => {console.warn(`POST!!!! ${response.data} POST!!!!`);
            resolve(response.data)})
        .catch(reject);
})

const removePlayedInstruments = (instrumentId) => new Promise((resolve, reject) => {
    axios
        .delete(`${baseURL}/PlayedInstrument/${instrumentId}`).then((response) => resolve(response.data))
        .catch(reject);
})

export {
    getAllInstruments,
    getPlayedInstruments,
    addPlayedInstruments,
    removePlayedInstruments
};