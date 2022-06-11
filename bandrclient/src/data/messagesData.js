import axios from "axios";

const baseURL = "https://localhost:7205/api";

const getMessagesByMatch = (matchId) => new Promise((resolve, reject) => {
    axios
        .get(`${baseURL}/message/Match/${matchId}`).then((response) => resolve(response.data))
        .catch(reject);
});

const createMessages = (messageObj) => new Promise((resolve, reject) => {
    axios
        .post(`${baseURL}/Message`, messageObj).then((response) => resolve(response.data))
        .catch(reject);
});

export { getMessagesByMatch, createMessages};