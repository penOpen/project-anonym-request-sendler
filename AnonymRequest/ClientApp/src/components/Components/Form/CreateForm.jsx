import React from 'react'
import CreateSubmit from '../Btn/CreateSubmit';
import ImagesBlock from '../Images/ImagesBlock';
import CreateInputDescription from '../Input/CreateInputDescription';
import CreateInputFiles from '../Input/CreateInputFiles';
import CreateInputName from '../Input/CreateInputName';
import CreateTicketType from '../Input/CreateTicketType';

function CreateForm(props) {
  const [state, dispatch] = props.state

  function onSubmit(e) {
    e.preventDefault();
    
    const req = {
      type: state.type,
      name: state.name,
      description: state.description,
      files: state.files
    }

    return false;
  }

  function onChangeFabric(type, dispatch) {
    return function(e) {
      dispatch( { type: type, payload: e.target.value } )
    }
  }

  return (
    <form 
      method='post' 
      className='create__form'
      onSubmit={onSubmit}
      encType="multipart/form-data" 
    >
      <p className="wrap_create__select">
        <div className="create__select-text">
          Укажите тип проблемы:
        </div> 
        <CreateTicketType 
          onChange={onChangeFabric("type", dispatch)}
        />
      </p>
      <CreateInputName 
        onChange={onChangeFabric("name", dispatch)}
      />
      <CreateInputDescription 
        onChange={onChangeFabric("description", dispatch)}
      />
      <div className='create__input-last'>
        <CreateInputFiles 
          onChange={onChangeFabric("files", dispatch)}
          dispatch={dispatch} 
        />
        <CreateSubmit/>
      </div>
      { 
        state.files.length
        ? <ImagesBlock dispatch={dispatch} files={state.files} classes="create__images" />
        : null
      }
    </form>
  )
}

export default CreateForm 