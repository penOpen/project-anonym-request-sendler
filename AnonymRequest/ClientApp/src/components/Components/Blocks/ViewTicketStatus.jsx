import React from 'react'
import defaultUser from "./moderatorDefault.svg"

function ViewTicketStatus(props) {
  const { state } = props
  const { avatar, name } = state.moderator 
  const status = -1
  let statusInfo = []

  switch(status) {
    case -1:
      statusInfo.push("Отклонено")
      statusInfo.push("view__ticket_status_rejected")
      break;
    case 0:
      statusInfo.push("На рассмотрении")
      statusInfo.push("view__ticket_status_pending")
      break;
    case 1:
      statusInfo.push("Удовлетворено")
      statusInfo.push("view__ticket_status_done")
      break;
    case 2:
      statusInfo.push("Провал")
      statusInfo.push("view__ticket_status_failed")
      break;
    default:

  }

  return (
    <div className='view__ticket_status'>
      <img 
        src={avatar || defaultUser} 
        alt="modAvatar"
      />
      <p 
        className="view__ticket_mod_name"
      >
        { name }
      </p>
      <p
        className={`view__ticket_status_info ${statusInfo.slice(0).join(" ")}`}
      >
        {statusInfo[0]}
      </p>
    </div> 
  )
}

export default ViewTicketStatus