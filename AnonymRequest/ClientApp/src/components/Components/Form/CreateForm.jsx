import React from 'react'
import {useNavigate} from "react-router-dom"
import getFetch from '../../utils/fetches';
import CreateSubmit from '../Btn/CreateSubmit';
import ImagesBlock from '../Images/ImagesBlock';
import CreateInputDescription from '../Input/CreateInputDescription';
import CreateInputFiles from '../Input/CreateInputFiles';
import CreateInputName from '../Input/CreateInputName';
import CreateErrorText from '../Modal/CreateErrorText';
import CreateTicketType from '../Input/CreateTicketType';

function CreateForm(props) {
  const [state, dispatch] = props.state
  const navigate = useNavigate()

  async function onSubmit(e) {
    e.preventDefault();
    
    if (!(Array.apply({}, e.target))[1].value || !(Array.apply({}, e.target))[2].value) {
      dispatch({type: "formReqErr"})
      setTimeout(() => dispatch({type: "errfalse"}), 10000)
      return
    }

    const req = {
      type: state.type,
      name: state.name,
      description: state.description,
      files: state.files
    }

    const createFetch = getFetch("POSTcreate")

    const res = await createFetch(req)
    const resObject = await res.json()
    
    let path = `/view/${resObject.guid}`;
    window.localStorage.setItem(`${resObject.guid}`, `${resObject.token}`)

    navigate(path, {replace: true})

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
        { state.isError 
          ? <CreateErrorText/>
          : null}
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