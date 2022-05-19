import React from 'react'
import NavElem from "../Components/NavElem";
import "./Nav.css";

function NavLeft() {
  return (
    <div className="wrap__left-nav">
      <NavElem href="/" text="Главная"/>
    </div>
  )
}

export default NavLeft;