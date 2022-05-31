import './App.css';
import Routing from './routes';

function MainView() {
  // const [user, setUser] = useState(null);

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
  
  return (
    <div className="App">
      <header className="App-header">
      <Routing></Routing>
      </header>
    </div>
  );
}

export default MainView;
