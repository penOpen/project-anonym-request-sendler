import React, {useReducer, useEffect} from 'react'
import { useNavigate } from 'react-router-dom'
import AccountNoTicketsFound from '../Components/Modal/AccountNoTicketsFound'
import Spinner from '../Components/Modal/Spinner'
import getFetch from '../utils/fetches'
import getStateManagement from '../utils/redusers'
import AccountTickets from '../Components/Blocks/AccountTickets'
import AccountError from '../Components/Modal/AccountError'
import "./Account.css"

function Account() {
  const [state, dispatch] = useReducer(...getStateManagement("account"))
  const navigate = useNavigate()

  useEffect(() => {
    if (!state.isLoad) return
    const fetchAccount = getFetch("POSTaccount")
    const req = { token: localStorage.getItem("__api_token") }
    fetchAccount(req)
    .then(resStream => resStream.json())
    .then(res => {
      if (!res.ok) {
        navigate("/", {replace: true})
        return
      }
      const { tickets } = res
      for (let ticket of tickets) {
        localStorage.setItem(ticket.guid, ticket.token)
      }
      dispatch({type: "fetch", payload: tickets})
      dispatch({type: "onload"})
    })
  })
  return (
    <div className='content center-items column-items'>
      { 
        state.isLoad 
      ? <Spinner/>
      : !state.tickets.length
      ? <AccountNoTicketsFound/>
      : state.isError 
      ? <AccountError/>
      : <AccountTickets tickets={state.tickets} dispatch={dispatch}/>
      }
    </div>
  )
}

export default Account