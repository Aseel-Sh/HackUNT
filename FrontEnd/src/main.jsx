import * as React from 'react'
import * as ReactDOM from 'react-dom/client'
/* import App from './signIn.jsx' */
import { createBrowserRouter, RouterProvider} from "react-router-dom"
import App from './landingpage.jsx'
import signIn from './signIn.jsx'
import './styling.css'
import Dashboard from './dashboard.jsx'


/* const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      {
        path: 'signIn/',
        element: <signIn />
      }
    ]
  },
  
]) */
/* <RouterProvider router={router}/> */

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <Dashboard/>
  </React.StrictMode>
)
