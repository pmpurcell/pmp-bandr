import { useState, useEffect } from 'react';
import logo from './logo.svg';
import './App.css';
import { Button } from 'reactstrap';
import auth from './data/firebaseAuth';
import { checkUserCreatedInDB, getSingleUser, signInUser, signOutUser } from './data/userData';

function App() {
  // const [user, setUser] = useState(null);
  const [match, setMatch] = useState(null);

//   useEffect(() => {
//     auth.onAuthStateChanged(async (response) => {
//         if (response) {
//             const user = {
//                 uid: response.uid,
//                 fullName: response.displayName,
//                 profilePic: response.photoURL,
//                 username: response.email.split('@')[0],
//                 token: response.accessToken,
//             };
//             setUser(user);
            
//             //you can also do this to save the token for later use
//             sessionStorage.setItem("token", response.accessToken);

//             checkUserCreatedInDB();

//         } else {
//             setUser(false);
             
//             //don't forget to clear the token if using sessionStorage!
//             sessionStorage.removeItem("token");

//             // navigate('/');
//         }
//     });
// }, []);

const findMatch = () => {
let random = 1
getSingleUser(random).then(response => console.warn(response))
};
  
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Welcome to Bandr!
        </p>
        {/* <p>{user.userName}</p> */}
        {/* <p>{match.userName}</p> */}
        <Button onClick={signInUser}>Sign In</Button>
        <Button onClick={signOutUser}>Sign Out</Button>
        <Button onClick={findMatch}>Find A Match</Button>
      </header>
    </div>
  );
}

export default App;
