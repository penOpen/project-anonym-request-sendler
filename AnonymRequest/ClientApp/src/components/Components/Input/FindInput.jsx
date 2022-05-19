import React from 'react'
import './FindInput.css'

function FindInput() {
  return (
    <input 
      type="text" 
      name="ticket_key" 
      placeholder="Введите номер вашей жалобы" className="find__input"
    />
  )
}

export default FindInput