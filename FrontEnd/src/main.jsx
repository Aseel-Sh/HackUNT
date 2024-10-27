import * as React from 'react'
import * as ReactDOM from 'react-dom/client'
/* import App from './signIn.jsx' */
import { createBrowserRouter, RouterProvider} from "react-router-dom"
import App from './landingpage.jsx'
import signIn from './signIn.jsx'
import './styling.css'


const router = createBrowserRouter([
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
  
])


ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router}/>
  </React.StrictMode>
)
