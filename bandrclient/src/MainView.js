import "./App.css";
import { useState, useEffect } from "react";
import auth from "./data/firebaseAuth";
import { checkUserCreatedInDB, getSingleUserByFID } from "./data/userData";
import Routing from "./routes";
import { useNavigate } from "react-router-dom";

function MainView() {
  const [user, setUser] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    auth.onAuthStateChanged(async (response) => {
      if (response) {
        const firebaseUser = {
          firebaseId: response.uid,
          name: response.displayName,
          photo: response.photoURL,
        };
        getSingleUserByFID(firebaseUser.firebaseId).then((response) =>
          setUser(response)
        );

        sessionStorage.setItem("token", response.accessToken);
        checkUserCreatedInDB(response.accessToken);
      } else {
        setUser({});

        //don't forget to clear the token if using sessionStorage!
        sessionStorage.removeItem("token");

        navigate("/");
      }
    });
  }, [navigate]);

  return (
    <div className="App">
      <header className="App-header">
        <Routing user={user}></Routing>
      </header>
    </div>
  );
}

export default MainView;
