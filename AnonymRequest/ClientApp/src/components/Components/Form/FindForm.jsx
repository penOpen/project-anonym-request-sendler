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
    const req = {
      gid: inputNodeElement.value
    }
    
    const fetchFind = getFetch("POSTfind")

    const res = await fetchFind(req)
    const resObject = await res.json()

    if (!res.ok || !resObject.ok) {
      setOk(false)

      setTimeout(() => setOk(true), 5000)

      return false
    }

    let path = `/view/${resObject.guid}`;
    window.localStorage.setItem(`${resObject.guid}`, `${resObject.token}`)

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