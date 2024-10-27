import { useNavigate } from "react-router-dom"
import { useState } from "react";
import webs from './assets/webs.png'

export default function signUp(){
    //DO NOT CHANGE
    let navigate = useNavigate();
    const routeChange = () =>{
        let path = '../signIn';
        navigate(path);
    }
    //DO NOT CHANGE
    const styling = {
        container:{
            display: 'flex',
            flexDirection: 'column',
        },
        form:{
            display:"flex",
            flexDirection: "column",
            border: 0,
            margin: 0
        },
        btnCont:{
            display:"flex",
            flexDirection: "row",
            border: 0,
            margin: 0,
            justifyContent: "space-between",
            backgroundColor: "#212529",
            marginTop: "5rem",
            zIndex: 2
        },
        imageDiv: {
            backgroundImage: `url(${webs})`,
            position: 'absolute',
            height: '100vh',
            width: '100vw',
            top: 0,
            left: 0,
            transform: 'scale(-1, -1)',
            zIndex: 0
        }
    }

    return(
        <div style={{display: 'flex', flexDirection:"column"}}>
            <div style={styling.imageDiv}></div>
            <form action="" className="nes-container is-dark" style={styling.form}>
                <h1>SignUp</h1>
                <label>Username</label>
                <input type="text" className="nes-input is-dark" style={{backgroundColor: '#AD02D7'}}/>
                <label>password</label>
                <input type="password" className="nes-input is-dark" style={{backgroundColor: '#00FF37'}}/>
                <label>Re-enter Password</label>
                <input type="password" className="nes-input is-dark" style={{backgroundColor: '#00FF37'}}/>
            </form>
            <div style={styling.btnCont}>
                <button className="nes-btn"style={{backgroundColor: "#FF8408", height:'3rem',width:'10rem'}}>Sign Up</button>
                <button className="nes-btn"style={{backgroundColor: "#FF8408", height: "3rem", width: '10rem'}} onClick={routeChange}>back</button>
            </div>
            
        </div>
    )
}