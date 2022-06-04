import './App.css';
import {useState, useEffect} from 'react'
import auth from './data/firebaseAuth';
import { checkUserCreatedInDB } from './data/userData';
import Routing from './routes';

function MainView() {
  const [user, setUser] = useState(null);

  useEffect(() => {
    auth.onAuthStateChanged(async (response) => {
        if (response) {
            const user = {
                firebaseId: response.uid,
                name: response.displayName,
                photo: response.photoURL,
            };
            setUser(user);
            
            //you can also do this to save the token for later use
            sessionStorage.setItem("token", response.accessToken);
            checkUserCreatedInDB(response.accessToken);

        } else {
            setUser({});
             
            //don't forget to clear the token if using sessionStorage!
            sessionStorage.removeItem("token");

            // navigate('/');
        }
    });
}, []);
  
  return (
    <div className="App">
      <header className="App-header">
      <Routing user={user}></Routing>
      </header>
    </div>
  );
}

export default MainView;
