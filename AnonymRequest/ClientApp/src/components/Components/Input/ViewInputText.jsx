import React from 'react'

function ViewInputText(props) {
  const { dispatch } = props
  
  function onChange(e) {
    dispatch( { type: "commenttextchange", payload: e.target.value } )
  }

  return (
    <div className="view__form_text">
      <textarea placeholder='Напишите что-нибудь для публикации комментария' onChange={onChange}></textarea>
    </div>
  )
}

export default ViewInputText