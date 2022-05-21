import React from 'react'
import { useNavigate } from 'react-router-dom'
import getFetch from '../../utils/fetches'

function AccountTicketCard(props) {
  const { ticket, dispatch } = props
  const navigate = useNavigate()

  const onClick = (e) => {
    navigate(`/view/${e.target.closest(".account__ticket").dataset.guid}`, {replace: true})
  }
  const onChange = async (e) => {
    const fetchAccount = getFetch("PUTaccount")
    const req = {
      token: localStorage.getItem("__api_token"),
      gid: e.target.closest(".account__ticket").dataset.guid,
      status: e.target.value
    }
    const res = await fetchAccount(req)
    const resObject = await res.json()
    if (!res.ok || !resObject.status) {
      dispatch({type: "onerr"})
      return
    }
  }

  return (
    <div className="account__ticket" data-guid={ticket.guid} onClick={onClick}>
      <div className="account__ticket_header">
        <p className='account__ticket_name'>{ ticket.name }</p>
        <select onClick={e => e.stopPropagation()} onChange={onChange}>
          <option value="-1" selected={ticket.status === "-1"}>Откл.</option>
          <option value="0" selected={ticket.status === "0"}>См.</option>
          <option value="1" selected={ticket.status === "1"}>Уд.</option>
          <option value="2" selected={ticket.status === "2"}>Пров.</option>
        </select>
      </div>
      <p className='account__ticket_desc'>{ ticket.description }</p>
    </div>
  )
}

export default AccountTicketCard