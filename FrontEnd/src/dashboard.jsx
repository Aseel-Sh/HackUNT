import { useState } from 'react'
import './styling.css';
import 'nes.css/css/nes.min.css';
import { CiSquarePlus } from "react-icons/ci";
import { FaUserPlus } from "react-icons/fa";
import { CiHome } from "react-icons/ci";



export default function Dashboard(){
    return(
        <div className="container" style={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center'
        }}>

            <div className='header' style={{
                position: 'absolute', // Position the div absolutely
                top: 10,              // Align to the top
                left: 10,             // Align to the left
                padding: '10px',     // Padding for aesthetics
                color: 'white',
                border: '0', // Border for visibility
                fontSize: '2rem',
                zIndex: 10,
                fontSize: '20px' 
            }}>
                <p>SyncItUp</p>
            </div>
            <div className="sideBar" style={{
                  position: 'absolute',
                  top: '60px',
                  left: '0',
                  height: '100%',
                  width: '300px',
                  transition: 'left .3s ease-in-out',
                  backgroundColor: 'black',
                  display: 'flex',
                  justifyContent: 'center',
                  flexDirection: 'center'
                
            }}>
                <div className="icon-container" style={{
                    display: 'flex',
                    flexDirection: 'column',
                    gap: '30px',
                    alignItems: 'center',
                    justifyContent: 'center'
                }}>
                <button className="nes-btn"><CiHome size={70} style={{color: 'orange', }}/></button>
                <button className="nes-btn"><CiSquarePlus size={70} style={{color: 'purple'}} /></button>
                <button className="nes-btn"><FaUserPlus size={70} style={{color: 'green'}}/></button>

                </div>

            </div>

        </div> // main container div
    );
}