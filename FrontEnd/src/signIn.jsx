import { useState } from 'react'
import './App.css'
import './styling.css'


export default function signIn() {
    const [username,setUsername] = useState('');
    const [password,setPassword] = useState('');

    function validate(pw,user){
        
    }

    return(
        <div class="parent">
            <label>Sign In</label>
            <label>Username:</label>
            <input type='text' onChange={()=> setPassword(value)}/>
            <label>Password:</label>
            <input type='password'/>
            <button>Submit</button>
        </div>
    )
}