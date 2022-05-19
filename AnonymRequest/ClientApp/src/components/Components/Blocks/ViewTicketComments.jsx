import React from 'react'
import ViewComment from './ViewComment'

function ViewTicketComments(props) {
  const { state, dispatch } = props
  const { comments } = state
  let commentComponents = []
  for (let i = 0; i < comments.length; i++) {
    commentComponents.push(<ViewComment dispatch={dispatch} comment={comments[i]} key={i*1000}/>)
  }

  return (
    <div
      className='view__comments'  
    >
      { 
        commentComponents.length 
      ? <>
        <p className='view__comments_title'>Комментарии:</p>
        {
          commentComponents
        }
        </>
      : null
      }
    </div>
  )
}

export default ViewTicketComments