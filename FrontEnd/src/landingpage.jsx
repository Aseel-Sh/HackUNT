import { useState } from 'react'
import './styling.css';
import 'nes.css/css/nes.min.css';
import webs from './assets/webs.png'

export default function LandingPage() {

    return (
        <>
        <div style={{
             backgroundImage: `url(${webs})`,
             position: 'absolute',
             height: '100vh',
             width: '100vw',
             top: 0,
             left: 0,    
             transform: 'scale(.1)',
             transform: 'scaleX(-1)',
             zIndex: 1
            }}>
        </div>

        <div className="nes-container is-dark is-centered" 
        style={{
            textAlign: 'center',
            justifyContent: 'center',
            alignContent: 'center',
            backgroundColor: '#212529',
            border: '0',
            margin: '0',
            maxWidth: '50%',
            
            
        }}>
            <h1 
            style={{
                textAlign: 'center', 
                justifyContent: 'center',
                alignContent: 'center',
                border: '0',
                margin: '0',
                textWrap: 'wrap'
            }}
            >SyncItUp</h1>
            <p>A time-aware meeting scheduler, where everyone's availability is heard</p>

        </div>
        <div className="nes-container is-dark is-centered" style={{
            textAlign: 'center',
            border: '0',
            margin: '0'
        }}>

            <button className="nes-btn" style={{
                backgroundColor: "#CD04FF",
                boxShadow: "#680082"
            }}>Go To Dashboard</button>
        </div>
        


    </>
    );

}