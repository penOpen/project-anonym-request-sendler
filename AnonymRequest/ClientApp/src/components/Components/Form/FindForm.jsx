import React from 'react'
import {useNavigate} from "react-router-dom"
import FindInput from '../Input/FindInput'
import FindSubmit from "../Btn/FindSubmit"
import getFetch from '../../utils/fetches'
import "./FindForm.css"

function FindForm(props) {
  const { setOk } = props

  const navigate = useNavigate()

  const onSubmit = async (e) => {
    e.preventDefault()
    
    let [inputNodeElement] = document.getElementsByName("ticket_key")
    const req = JSON.stringify({guid: inputNodeElement.value})
    
    const fetchFind = getFetch("__find")

    const res = JSON.parse(await fetchFind(req))
    if (!res.ok) {
      setOk(false)

      setTimeout(() => setOk(true), 5000)

      return false
    }
    
    let path = `/view/${res.value.guid}`;
    navigate(path, {replace: true})

    return false
  }

  return (
    <form 
        className="find__form" 
        method='get' 
        onSubmit={ onSubmit }
      >
        <FindInput/>
        <FindSubmit/>
      </form>
  )
}

export default FindForm