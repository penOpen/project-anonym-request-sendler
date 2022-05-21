import React, {useReducer, useEffect} from 'react'
import { useNavigate } from 'react-router-dom'
import getFetch from '../utils/fetches'
import getStateManagement from '../utils/redusers'
import "./Login.css"

export default function Login() {
  const [state, dispatch] = useReducer(...getStateManagement("login"))
  const navigate = useNavigate()

  useEffect(() => {
    const MaybeToken = localStorage.getItem("__api_token")
    if (MaybeToken) navigate('/account', {replace: true})
  })

  function onChange(e) {
    dispatch({type: "inputchange", payload: e.target.value})
  }

  async function onSubmit(e) {
    e.preventDefault()

    const token = state.token
    const fetchLogin = getFetch("POSTlogin")
    const req = {
      token
    }

    const res = await fetchLogin(req)
    const resObject = await res.json()
    if (!res.ok || !resObject.status) {
      dispatch({type: "onerr"})
      return false
    }

    localStorage.setItem("__api_token", resObject.token)
    navigate("/account", {replace: true})
    return false 
  }
  
  return (
    <div className='center-items column-items content login'>
      <p>Пожалуйста, введите токен модератора</p>
      <form className='login__form' onSubmit={onSubmit}>
         <input type={"password"} className="login__input_token" onChange={onChange}/>
         <input type={"submit"} className="login__submit" value={"Отправить"}/>
      </form>    
    </div>
  )
}