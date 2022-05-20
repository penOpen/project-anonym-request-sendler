import React from 'react'
import ViewInputText from '../Input/ViewInputText';
import ViewFormLast from '../Blocks/ViewFormLast';
import { useParams } from 'react-router-dom';
import getFetch from '../../utils/fetches';

function ViewForm(props) {
  const { state, dispatch } = props
  const { guid } = useParams()

  async function onSubmit(e) {
    e.preventDefault();

    const req = {
      isLogged: state.isMod.toString(),
      text: state.newComment.text,
      time: Date.now().toString(),
      gid: guid,
      files: state.newComment.files,
    }

    const viewFormFetch = getFetch("PUTview")
    const res = await viewFormFetch(req)
    const resObj = await res.json()
    console.log(resObj)

    if (!res.ok) return false

    dispatch({type: "commentsUpdate", payload: resObj.comment})

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