import React, { useEffect, useReducer } from 'react'
import {useParams} from "react-router-dom"
import ViewTicketComments from '../Components/Blocks/ViewTicketComments'
import ViewTicketInfo from '../Components/Blocks/ViewTicketInfo'
import ViewErrorFindingText from '../Components/Modal/ViewErrorFindingText'
import ViewForm from '../Components/Form/ViewForm'
import CreateModalImage from '../Components/Modal/CreateModalImage'
import getFetch from "../utils/fetches"
import getStateManagement from "../utils/redusers"
import "./View.css"

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
    })
        // const body = JSON.parse(value)
        // console.log(body)
        // if (!body.ok) {
        //   dispatch({type: "fetchfailed"})
        //   return
        // }
        // dispatch({type: "fetch", payload: body.value})

  return (
    <div className="wrap_view column-items center-items">
    { state.modalClicked.ok 
      ? <CreateModalImage 
        src={[...state.files, ...state.newComment.files].find(file => file.name === state.modalClicked.name).code}
        dispatch={dispatch}  
      />
      : null
    }
    {   state.isLoad 
      ? <div className='loader'></div>
      : state.isError 
      ? <ViewErrorFindingText/> //block for fatal error
      : 
        <div className="view column-items"> 
          <ViewTicketInfo dispatch={dispatch} state={state}/> 
          <ViewForm dispatch={dispatch} state={state}/>
          {state.comments ? <ViewTicketComments dispatch={dispatch} state={state}/> : null}
        </div>
    }
    </div>
  )
}

export default View