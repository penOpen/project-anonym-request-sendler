import React from 'react'

function CreateInputName(props) {
  return (
    <input  
      type="text" 
      placeholder='Кратко опишите суть проблемы' 
      className='create__input'
      onChange={ props.onChange }
    />
  )
}

export default CreateInputName