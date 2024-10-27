import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import landing from './landingpage.jsx';
import SignIn from './signIn.jsx';

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<landing />} />
        <Route path="/sign-in" element={<SignIn />} />
      </Routes>
    </Router>
  );
};

export default App;
