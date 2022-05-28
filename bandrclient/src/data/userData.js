import axios from 'axios';
import auth from './firebaseAuth';
import { getAuth, signInWithPopup, GoogleAuthProvider } from "firebase/auth";

const baseURL = 'https://localhost:7205/api'
 
const checkUserCreatedInDB = async () => {
		//get the token from sessionStorage like this
    const token= sessionStorage.getItem("token");

		//send the request with an Authorization header containing the token
    await axios.get(`${baseURL}/Users/Auth`, {
        headers: { Authorization: 'Bearer ' + token },
    });
};

const getSingleUser = (userId) => new Promise((resolve, reject) => {
    axiosc
        .get(`${baseURL}/User?Id=${userId}`).then((response) => resolve(response.data))
        .catch(reject);
 })
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
signInUser,
signOutUser,
getSingleUser
};