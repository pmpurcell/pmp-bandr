import axios from "axios";
import auth from "./firebaseAuth";
import { getAuth, signInWithPopup, GoogleAuthProvider } from "firebase/auth";

const baseURL = "https://localhost:7205/api";

const checkUserCreatedInDB = async () => {
  //get the token from sessionStorage like this
  const token = sessionStorage.getItem("token");
  //send the request with an Authorization header containing the token
  await axios.get(`${baseURL}/User/Auth`, {
    headers: { Authorization: "Bearer " + token },
  });
};

const getAllUsers = () =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/user`)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

const getSingleUser = (userId) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/User/${userId}`)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

const getSingleUserByFID = (firebaseId) =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/User/firebase/${firebaseId}`)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

const updateUserInfo = (userId, userObj) =>
  new Promise((resolve, reject) => {
    axios
      .patch(`${baseURL}/User/${userId}`, userObj)
      .then((response) => resolve(response.data))
      .catch(reject);
  });

const signInUser = () => {
  const provider = new GoogleAuthProvider();
  signInWithPopup(auth, provider);
};

const signOutUser = () =>
  new Promise((resolve, reject) => {
    getAuth().signOut().then(resolve).catch(reject);
  });

export {
  checkUserCreatedInDB,
  getAllUsers,
  signInUser,
  signOutUser,
  getSingleUser,
  getSingleUserByFID,
  updateUserInfo,
};
