import React from 'react';
import CreateImage from '../Images/CreateImage';

function ImagesBlock(props) {
  const { files, dispatch, classes } = props
  return (
    <div className={classes}>
      {
        files.map( file => 
          <CreateImage 
            name={file.name}
            dispatch={dispatch}
          /> )
      }
    </div>
  )
}

export default ImagesBlock