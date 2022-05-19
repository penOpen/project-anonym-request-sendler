import React from 'react'
import {useNavigate} from "react-router-dom"
import "./HomeBtn.css"

function HomeBtn(props) {
  let {href, text} = props;
  let navigate = useNavigate();
  return (
    <button
      onClick={() => {
        navigate(href)
      }}
      className="home-btn"
    >
      {text}
    </button>
  )
}

export default HomeBtn