import React from 'react'
import ImagesBlock from '../Images/ImagesBlock'

function ViewComment(props) {
  const { comment, dispatch } = props
  
  return (
    <div
      className='view__comment'
    >
      <div className='view__comment_text_info'>
        <div className='view__comment_header'>
          <p>№{comment.id}</p>
          <p>{comment.isMod ? "Модератор" : "Вы"} в {new Date(comment.time).toLocaleString()}</p>
        </div>
        <p className='view__comment_text'>{comment.text}</p>
      </div>
      {
        comment.files 
        ? <ImagesBlock dispatch={dispatch} files={comment.files} classes="view__comment_images"/>
        : null
      }
    </div>
  )
}

export default ViewComment