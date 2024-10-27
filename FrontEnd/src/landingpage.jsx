import { useState } from 'react'
import './styling.css';
import 'nes.css/css/nes.min.css';
import webs from './assets/webs.png'
import ghost from './assets/Ghost.gif'

export default function LandingPage() {

    return (
        <div className="container" style={{
            display: 'flex',
            alignContent: 'center',
            justifyContent: 'center'
        }}>
        <div className="web-container" style={{
             backgroundImage: `url(${webs})`,
             position: 'absolute',
             height: '100vh',
             width: '100vw',
             top: 0,
             left: 0,    
             transform: 'scale(.1)',
             transform: 'scaleX(1)',
             zIndex: 1
            }}>
        </div>
        <div className="monster-container" style={{
            zIndex: 1,
            backgroundColor: "#212529",
            maxWidth: '200wh'
            
        }}> 
            <img src={ghost}></img>

        </div>
        <div className="nes-container is-dark is-centered" 
        style={{
            textAlign: 'center',
            justifyContent: 'center',
            alignContent: 'center',
            backgroundColor: '#212529',
            border: '0',
            margin: '0',
            display: 'flex',
            flexDirection: 'column',
            maxWidth: '50vw',
            maxHeight: '50vh'

        }}>
            <h1 
            style={{
                textAlign: 'center', 
                justifyContent: 'center',
                alignContent: 'center',
                border: '0',
                margin: '0',
                fontSize: '60px'
            }}
            >SyncItUp</h1>
            <p style={{
                textWrap: 'wrap'
        
            }}>A time-aware meeting scheduler, where everyone's availability is heard</p>
             <button className="nes-btn" style={{
                backgroundColor: "#CD04FF",
                boxShadow: "#680082",
                zIndex: 2,
                color: 'white'
            }}>Go To Dashboard</button>
        </div>
           


    </div>
    );

}