import React from 'react'
import "./CreateImage.css"
import svgshit from "./picture-svgrepo-com.svg"

function CreateImage(props) {
  const { name } = props
  const onClick = async(e) => {
    props.dispatch( { type: 'modalclicked', payload: name } )
  }

  return (
    <div 
      className="wrap_create__image center-items tooltip "
      onClick={ onClick }
    >
      <div className='create__image'>
        <img src={svgshit} alt="меня заставили что-то написать здесь"></img>
      </div>
      <div className='create__image-text'>
        { name }
      </div>
      <span 
        className="tooltiptext"
        onClick={e => e.stopPropagation()}
      > {name} </span>
    </div>
  )
}

export default CreateImage