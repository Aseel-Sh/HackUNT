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
            <div class="nes-container is-dark"
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
                    backgroundColor: "#FF8408",
                    color: "#00FF37"
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
            <label class='nes-container is-dark'
            style={{
                margin: "0",
                border: "0"
            }}
            >
                <input type='checkbox' class="nes-checkbox is-dark"/>
                <span>Remember Me</span>
            </label>
            <div>
                <a class = "nes-container is-dark" href='https://google.com'
                    style={{
                        margin: "0",
                        border: "0"
                    }}
                >Forgor Password</a>
            </div>
            
            <div
                style={{
                    margin: "0",
                    border: "0"
                }}
            >
            <button
                class="nes-btn"
                onClick={validate}
            >Login</button>

            </div>
        </div>
    )
}