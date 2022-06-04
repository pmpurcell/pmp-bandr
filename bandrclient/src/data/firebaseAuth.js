// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAuth } from "firebase/auth";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyChz-Yd3e0RWwtsZsVgw7-q_UfKeHbviHg",
  authDomain: "bandr-27ff9.firebaseapp.com",
  projectId: "bandr-27ff9",
  storageBucket: "bandr-27ff9.appspot.com",
  messagingSenderId: "581957882721",
  appId: "1:581957882721:web:36f1588b69b7d7723f2b20",
  measurementId: "G-H92J1410G0"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);

const auth = getAuth(app);

export default auth;