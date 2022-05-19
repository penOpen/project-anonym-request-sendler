import React from 'react'
import { Link } from "react-router-dom"
import "./NavElem.css"

function NavElem(props) {
  const { href, text } = props;
  return ( 
    <div className="nav-elem">
      <Link to={href}>{text}</Link>
    </div> 
  )
}

export default NavElem;