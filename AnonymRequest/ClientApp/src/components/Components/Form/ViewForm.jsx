import React from 'react'
import ViewInputText from '../Input/ViewInputText';
import ViewFormLast from '../Blocks/ViewFormLast';

function ViewForm(props) {
  const { state, dispatch } = props

  function onSubmit(e) {
    e.preventDefault();

    const req = {
      text: state.newComment.text,
      files: state.newComment.files,
      isMod: state.isLogged,
    }

    return false;
  }

  return (
    <form
      method='post'
      className='view__form'
      onSubmit={onSubmit}
    >
      <ViewInputText dispatch={dispatch}/>
      <ViewFormLast state={state} dispatch={dispatch}/>
    </form>
  )
}

export default ViewForm