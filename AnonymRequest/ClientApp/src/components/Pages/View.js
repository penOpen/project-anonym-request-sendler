import React, { useEffect, useReducer } from 'react'
import { useParams } from "react-router-dom"
import ViewTicketComments from '../Components/Blocks/ViewTicketComments'
import ViewTicketInfo from '../Components/Blocks/ViewTicketInfo'
import ViewErrorFindingText from '../Components/Modal/ViewErrorFindingText'
import ViewForm from '../Components/Form/ViewForm'
import CreateModalImage from '../Components/Modal/CreateModalImage'
import getFetch from "../utils/fetches"
import getStateManagement from "../utils/redusers"
import Spinner from '../Components/Modal/Spinner'
import "./View.css"
import ViewTicketGuid from '../Components/Blocks/ViewTicketGuid'

function View() {
  let { guid } = useParams()

  const [state, dispatch] = useReducer(...getStateManagement("view"))
  
  useEffect(() => {
    if (!state.isLoad) return;
    const fetchView = getFetch("POSTview")

    fetchView({gid: guid, token: localStorage.getItem(guid)})
      .then(value => value.json())
      .then(res => {
          console.log(res)
          dispatch({type: "onload"})
          if (!res.ok) {
            dispatch({type: "fetchfailed"})
            return
          }
          dispatch({type: "fetch", payload: res})
        })
    }
  )
  

  const getImagesFromComments = (st) => {
    let i = []
    if (!st.comments || !st.comments.length) return i
    for (let k of st.comments) {
      i?.push(...k?.files)
    }
    return i
  }

  return (
    <div className="wrap_view column-items center-items">
    { state.modalClicked.ok 
      ? <CreateModalImage 
        src={[...state.files, ...state.newComment.files, ...getImagesFromComments(state)]?.find(file => file.name === state.modalClicked.name).code}
        dispatch={dispatch}  
      />
      : null
    }
    {   state.isLoad 
      ? <Spinner/>
      : state.isError 
      ? <ViewErrorFindingText/> //block for fatal error
      : 
        <div className="view column-items"> 
          <ViewTicketGuid guid={guid}/>
          <ViewTicketInfo dispatch={dispatch} state={state}/> 
          <ViewForm dispatch={dispatch} state={state}/>
          {state.comments ? <ViewTicketComments dispatch={dispatch} state={state}/> : null}
        </div>
    }
    </div>
  )
}

export default View