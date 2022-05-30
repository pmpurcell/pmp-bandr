import { useState, useEffect } from 'react';
import logo from './logo.svg';
import './App.css';
import { Button } from 'reactstrap';
import auth from './data/firebaseAuth';
import { checkUserCreatedInDB, getAllUsers, getSingleUser, signInUser, signOutUser } from './data/userData';
import UserCard from './components/UserCard';

function MainView() {
  // const [user, setUser] = useState(null);
  const [userList, setUserList] = useState([]);
  const [match, setMatch] = useState({});

  useEffect(() => {
  let isMounted = true;

    getAllUsers().then((response) => {
      if (isMounted){
        setUserList(response)
      }},);
    return () => {
      isMounted = false
    }
  }, [userList]);
  

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
let random = Math.floor(Math.random() * userList.length + 1);
console.warn(random);
getSingleUser(random).then(response => setMatch(response))
};
  
  return (
    <div className="App">
      <header className="App-header">
        <p>
          Welcome to Bandr!
        </p>
        <UserCard user={match} />
        <Button onClick={signInUser}>Sign In</Button>
        <Button onClick={signOutUser}>Sign Out</Button>
        <Button onClick={findMatch}>Find A Match</Button>
      </header>
    </div>
  );
}

export default MainView;
