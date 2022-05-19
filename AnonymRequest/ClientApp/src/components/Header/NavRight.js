import React from 'react'
import NavElem from '../Components/NavElem'
import "./Nav.css";

function NavRight() {
  return (
    <div className='wrap__right-nav'>
      <NavElem href="/login" text="Войти"/>
    </div>
  )
}

export default NavRight