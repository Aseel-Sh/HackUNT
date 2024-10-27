import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './landingpage.jsx'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <App/>
  </StrictMode>,
)
