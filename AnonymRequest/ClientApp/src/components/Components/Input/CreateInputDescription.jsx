import React from 'react'

function CreateInputDescription(props) {
  return (
    <textarea
      placeholder='Опишите проблему во всех подробностях'
      className='create__input create__description'
      onChange={ props.onChange }
    />
  )
}

export default CreateInputDescription