import React from 'react';
import { Route ,BrowserRouter as Router } from 'react-router-dom';
import logo from './logo.svg';
import './App.css';
import Layout from "./components/layout";
import Home from "./components/Home/Home";

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
              <Route exact path='/' component={Home} />
          </Router>
      </Layout>
  )
}

export default App;
