import React from 'react'
import AccountTicketCard from './AccountTicketCard'

function AccountTickets(props) {
  const { tickets, dispatch } = props
  return (
    <div className="account__tickets">
      {
        tickets.map(ticket => <AccountTicketCard ticket={ticket} dispatch={dispatch}/>)
      }
    </div>
  )
}

export default AccountTickets