import React from 'react';
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate
} from "react-router-dom";
import "./App.css"

import Home from "./components/Pages/Home";
import Nav from "./components/Header/Nav";
import Footer from "./components/Footer/Footer";
import Find from "./components/Pages/Find";
import View from "./components/Pages/View";
import Create from "./components/Pages/Create";
import Account from './components/Pages/Account';
import Login from './components/Pages/Login';
import Privacy from './components/Pages/Privacy';
import EULA from './components/Pages/EULA';

export default function App() {
  return (
    <Router>
      <Nav/>
      <Routes>
        <Route path="/" element={ <Home/> }/>
        <Route path="/find" element={ <Find/> }/>
        <Route path='/view/:guid' element={ <View/> }/>
        <Route path='/create' element={ <Create/> }/>
        <Route path='/login' element={ <Login/> }/>
        <Route path="/account" element={ <Account/> }/>
        <Route path='/privacy' element={ <Privacy/> }/>
        <Route path='/eula' element={ <EULA/> }/>
        <Route path="*" element={<Navigate replace to="/"/>}/>
      </Routes>
      <Footer/>
    </Router>
  )
}