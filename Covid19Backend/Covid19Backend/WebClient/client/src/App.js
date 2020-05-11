import React from 'react';
import { Route ,BrowserRouter as Router } from 'react-router-dom';
import logo from './logo.svg';
import './App.css';
import Layout from "./components/layout";
import Home from "./components/Home/Home";
import EmailUnreg from "./components/EmailRegistration/EmailUnreg";
import WorldData from "./components/WorldData/WorldData";
import WorldDataTopRow from "./components/WorldData/WorldDataTopRow";
import WorldDataBottomRow from "./components/WorldData/WorldDataBottomRow";

function App() {
  /*return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );*/
  return (
      <Layout>
          <Router>
              <Route exact path='/' component={WorldDataTopRow} />
              <Route path='/emailUnreg/:email' component={EmailUnreg} />
              <Route path='/newZealand' component={Home} />
              <Route path='/other' component={WorldDataBottomRow} />
          </Router>
      </Layout>
  )
}

export default App;
