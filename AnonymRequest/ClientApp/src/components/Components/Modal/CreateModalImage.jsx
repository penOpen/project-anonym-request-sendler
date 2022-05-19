import React from 'react'


function CreateModalImage(props) {
  
  return (
    <div 
      className='wrap_create__modal'
      onClick={() => props.dispatch({type: "modalunmount"})}
    >
      <img 
        src={props.src}
        className="create__modal"
        alt=""
        onClick={(e) => e.stopPropagation()}
      />
    </div>
  )
}

export default CreateModalImage