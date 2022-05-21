import React from 'react'
import ImagesBlock from '../Images/ImagesBlock'
import ViewTicketStatus from "./ViewTicketStatus"

function ViewTicketInfo(props) {
  const { state, dispatch } = props
  return (
    <div 
      className='view__ticket_info'
    >
      <section className='view__base_info'>
        <div
          className='view__ticket_name'
        >
          <p className='view__text_info_headers'>Название заявки:</p>
          <span>{state.name}</span>
        </div>
        <div 
          className='view__ticket_description'
        >
          <p className='view__text_info_headers'>Описание заявки:</p>
          <div className='view__text_info_text' disabled>{state.description}</div>
        </div>
        {
          state.files && state.files.length ?
          <div className='wrap_view__images'>
            <p className='view__text_info_headers'>Приложенные изображения:</p>
            <ImagesBlock dispatch={dispatch} files={state.files} classes="view__images"/>
          </div>
          : null
        }
      </section>
      <ViewTicketStatus state={state}/>
    </div>
  )
}

export default ViewTicketInfo