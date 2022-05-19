import React, { useReducer } from 'react'
import CreateForm from '../Components/Form/CreateForm'
import CreateModalImage from '../Components/Modal/CreateModalImage'
import getStateManagement from '../utils/redusers'
import "./Create.css"

function Create() {

  const [state, dispatch] = useReducer(...getStateManagement("create"))

  return (
    <div className='content create__content center-items'>
      {
        state.modalClicked.ok ?
        <CreateModalImage
          src={state.files.find(file => file.name === state.modalClicked.name).code}
          dispatch={dispatch}  
        />
        : null
      }
      <CreateForm state={[state, dispatch]} />
    </div>
  )
}

export default Create