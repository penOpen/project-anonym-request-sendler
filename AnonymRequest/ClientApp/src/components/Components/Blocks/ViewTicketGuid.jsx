import React from 'react'

function ViewTicketGuid(props) {
  const { guid } = props
  return (
    <div className='view__guid'>Ваш ключ доступа к этой заявке: {guid}.<br/>Пожалуйста, не теряйте его!</div>
  )
}

export default ViewTicketGuid