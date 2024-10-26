import { useState } from 'react'
import './styling.css'
import 'nes.css/css/nes.min.css';

export default function signIn() {
    const [username,setUsername] = useState('');
    const [password,setPassword] = useState('');

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
        <div class="nes-constainer is-dark"
        style={{
            border: "0"
        }}
        >
            <div class='nes-container is-dark'
                style={{
                fontSize: "2rem",
                marginBottom: "2rem",
                border: "0",
                margin: "0"
                }}
            >
                <label>Login</label>
            </div>
            <div className="nes-container is-dark"
                style={{
                    fontSize: "2rem",
                    marginBottom: "2rem",
                    border: "0",
                    margin: "0"
                }}
            > 
                <label>Username:</label>
                <input
                type='text'
                class = 'input.is-dark'
                style={{
                    backgroundColor: "#AD02D7",
                    color: "#00FF37",
                    fontSize: "2rem",
                    marginBottom: "2rem",
                    border: "0",
                    margin: "0"
                }}
                onChange={() => {setUsername}}/>
            </div>
            <div class='nes-container is-dark'
                style={{
                    fontSize: "2rem",
                    marginBottom: "2rem",
                    border: "0",
                    margin: "0"
                }}
            >
                <label>Password:</label>
                <input
                class="input.is-dark"
                style={{
                    backgroundColor: "#00FF37",
                    color: "#FF8408",
                    fontSize: "2rem",
                    marginBottom: "2rem",
                    border: "0",
                    margin: "0"
                }}
                type='password'
                onChange={setPassword}/>
            </div>
            {/*Remember sign in and forgot password */}
            <div class='nes-container is-dark'
            style={{
                margin: "0",
                border: "0"
            }}
            >
                <input type='checkbox' class="nes-checkbox is-dark" />
                <span>Remember Me</span>
            </div>

            <div className='nes-container is-dark'
                style={{
                    display: "flex",
                    margin: "0",
                    border: "0",
                    flexDirection: "column",
                    alignItems: "center",
                    justifyContent: "center",
                    gap: "1rem"
                }}
            >
            <a href='https://google.com' style={{color:"white"}}>Forgor Password</a>
            <button
                class="nes-btn"
                onClick={validate}
                style={{
                    backgroundColor: "#FF8408",
                    width: "60rem",
                    padding: "0"
                }}
            >Login</button>
            </div>
        </div>
    )
}