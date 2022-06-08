import axios from 'axios';

const baseURL = 'https://localhost:7205'

const checkRelationship = (recId, swiperId, matchBool) => new Promise((resolve, reject) => {
    console.warn(`${recId}, ${swiperId}, ${matchBool}`)
    axios
        .get(`${baseURL}/Relationship/${recId}/${swiperId}/${matchBool}`)
        .then((response) => resolve(response.data))
        .catch(reject);
})

const createMatch = (matchObj) => new Promise((resolve, reject) => {
    axios
        .post(`${baseURL}/Match`, matchObj)
        .then((response) => resolve(response.data))
        .catch(reject);
});

export {createMatch, checkRelationship};