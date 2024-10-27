import * as React from 'react'
import * as ReactDOM from 'react-dom/client'
/* import App from './signIn.jsx' */
import { BrowserRouter, Route, Routes } from "react-router-dom"
import { createRoot } from 'react-dom/client'
import App from './landingpage.jsx'
import signIn from './signIn.jsx'
import './styling.css'
import LandingPage from './landingpage.jsx'
import signUp from './signUp.jsx'
import dashboard from './dashboard.jsx'


const root = createRoot(document.getElementById("root"));


root.render(
  <BrowserRouter>
    <Routes>
      {/*Add new routes here for navigation */}
      <Route path='/' Component={LandingPage}/>
      <Route path='/signIn' Component={signIn}/>
      <Route path='/signUp' Component={signUp}/>
      <Route path='/signIn/dashboard' Component={dashboard}/>
    </Routes>
  </BrowserRouter>
)
