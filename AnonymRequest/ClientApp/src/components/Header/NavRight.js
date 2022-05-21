import React from 'react'
import NavElem from '../Components/NavElem'
import "./Nav.css";

function NavRight() {
  const token = localStorage.getItem("__api_token")
  return (
    <div className='wrap__right-nav'>
      <NavElem href={token ? "/account" : "/login"} text={token ? "Аккаунт" : "Войти"}/>
    </div>
  )
}

export default NavRight