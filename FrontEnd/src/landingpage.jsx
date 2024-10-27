import { useState } from 'react'
import './styling.css';
import 'nes.css/css/nes.min.css';
import webs from './assets/webs.png'

export default function LandingPage() {

    return (
        <>
        <div style={{
            
            }}>
            <img src={webs} style={{
                position: 'absolute',
                height: '1920px',
                width: '1080px',
                top: '0',
                left: '0',
                
            }} />
        </div>

        <div className="nes-container is-dark with-title is-centered" 
        style={{
            textAlign: 'center',
            justifyContent: 'center',
            alignContent: 'center',
            backgroundColor: '#212529',
            border: '0',
            margin: '0'
            
        }}>
            <h1 
            style={{
                textAlign: 'center', 
                border: '0',
                margin: '0'
            }}
            >SyncItUp</h1>
            <p>A time-aware meeting scheduler, where everyone’s availability is heard</p>

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