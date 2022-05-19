import React from 'react'
import "./FindErrorText.css"

function FindErrorText() {
  return (
    <p 
      className='find__error-text'
      name="error-text">
      Ваша заявка не найдена.<br/>Пожалуйста, проверьте корректность написания ключа заявки.
    </p>
  )
}

export default FindErrorText