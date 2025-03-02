import { useState } from 'react';
import { useNavigate } from "react-router-dom";
import { Link } from 'react-router-dom';
import './styling.css'
import 'nes.css/css/nes.min.css';
import webs from './assets/webs.png'


export default function signIn() {
    const [username,setUsername] = useState('');
    const [password,setPassword] = useState('');

    //Navigates to dashboard without credentials for now
    let navigate = useNavigate();
    const routeChange = () =>{
        let path = 'dashboard';
        navigate(path);
    }


    const styles = {
        textDiv: {
          position: 'absolute', // Position the div absolutely
          top: 10,              // Align to the top
          left: 10,             // Align to the left
          padding: '10px',     // Padding for aesthetics
          color: 'white',
          border: '0', // Border for visibility
          fontSize: '2rem',
          zIndex: 10,          // Ensure it's above other elements
        },
        imageDiv: {
            backgroundImage: `url(${webs})`,
            position: 'absolute',
            height: '100vh',
            width: '100vw',
            top: 0,
            left: 0,
            transform: 'scale(-1, -1)',
            zIndex: 4
        }
      };

    //Backend logic here

    function validate(){
        if(password.length < 6){
            alert("Please enter a valid password" + ` ${password.length}`);
        }
        if(username.trim === ""){
            alert("Please enter a valid username");
        }
        //Backend logic here
    }

    return(
        <div>
            <div style={styles.imageDiv}></div>
            {/*Top Left Div */}
            <label style={styles.textDiv}>SyncItUp</label>
            
            {/*Login Title div */}
            <div class='nes-container is-dark'
                style={{
                    display: "flex",
                    fontSize: "2rem",
                    border: "0",
                    margin: "0",
                    alignContent: "center",
                    justifyContent: "center"
                }}
            >
                <h3>Login</h3>
            </div>
            {/*Input Username and Password */}
            <div className="nes-container is-dark"
                style={{
                    fontSize: "2rem",
                    marginBottom: "2rem",
                    border: "0",
                    margin: "0",
                    zIndex: 5
                }}
            > 
                <label>Username:</label>
                <input
                type='text'
                class = 'nes-input is-dark'
                style={{
                    backgroundColor: "#AD02D7",
                    color: "#00FF37",
                    fontSize: "2rem",
                    marginBottom: "2rem",
                    margin: "0"
                }}
                onChange={() => {setUsername}}/>
            </div>
            <div class='nes-container is-dark'
                style={{
                    fontSize: "2rem",
                    marginBottom: "2rem",
                    border: "0",
                    margin: "0",
                    zIndex: 5
                }}
            >
                <label>Password:</label>
                <input
                class="nes-input is-dark"
                style={{
                    backgroundColor: "#00FF37",
                    color: "#FF8408",
                    fontSize: "2rem",
                    marginBottom: "2rem",
                    margin: "0"
                }}
                type='password'
                onChange={setPassword}/>
            </div>
            {/*Remember sign in and forgot password */}
            
            <div class='nes-container is-dark'
            style={{
                margin: "0",
                border: "0",
                zIndex: 4
            }}>
            <label>
                <input type='checkbox' class="nes-checkbox is-dark" />
                <span>Remember Me</span>
            </label>
            </div>

            <div className='nes-container is-dark'
                style={{
                    display: "flex",
                    margin: "0",
                    border: "0",
                    flexDirection: "column",
                    alignItems: "center",
                    justifyContent: "center",
                    gap: "1rem",
                }}
            >
            <a href='https://google.com' style={{color:"white", zIndex: 4}}>Forgor Password</a>
            <button
                class="nes-btn"
                onClick={routeChange}
                style={{
                    backgroundColor: "#FF8408",
                    width: "60rem",
                    padding: "0",
                    zIndex: 5
                }}
            >Login</button>
            <label style={{zIndex: 4}}>Don't have an account? <Link to='/signUp' style={{color:'white'}}>Sign Up</Link></label>
            </div>
        </div>
    )
}