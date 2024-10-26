import { useState } from 'react'
import './styling.css';
import 'nes.css/css/nes.min.css';

export default function LandingPage() {

    return (
        <>
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
            <p>Where people blah blah time zone blah blah</p>

        </div>
        <div className="nes-container is-dark is-centered" style={{
            textAlign: 'center',
            border: '0',
            margin: '0'
        }}>

            <button className="nes-btn" style={{
                backgroundColor: "#CD04FF",
                boxShadow: "0"
            }}>Go To Dashboard</button>
        </div>
        


    </>
    );

}