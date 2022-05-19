import React from 'react'
import ViewInputSubmit from '../Btn/ViewInputSubmit'
import ViewInputImages from '../Input/ViewInputImages'

function ViewFormLast(props) {
  const {state, dispatch} = props

  return (
    
    <div
      className='view__form_last'
    >
      <ViewInputImages state={state} dispatch={dispatch}/>
      <ViewInputSubmit/>
    </div>

  )
}

export default ViewFormLast