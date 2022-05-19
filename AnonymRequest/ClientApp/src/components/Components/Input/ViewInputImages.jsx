import React from 'react'
import ImagesBlock from '../Images/ImagesBlock'

function ViewInputImages(props) {
  const { state, dispatch } = props

  async function filesToURL(fileList) {
    function toURL(file) {
      let filereader = new FileReader()
      return new Promise(resolve => {
        filereader.readAsDataURL(file)
        filereader.onload = e => resolve(e.target.result)
      })
    }
    const files = Array.apply({}, fileList).map( (file) => toURL(file) )
    return await Promise.all(files)
  }

  async function onChange(e) {
    const fileList = e.target.files
    const parsedFiles = await filesToURL(fileList)
    const merge = []
    for (let i = 0; i < fileList.length; i++) {
      merge.push(
        {
          name: fileList[i].name, 
          code: parsedFiles[i]
        }
      )
    }
    dispatch( {type: "files", payload: merge} )
  }

  return (
    <div className='wrap_view__form_images'>
      <label className='view__form_images_upload' htmlFor='view__upload'> </label>
      <input name='view__upload' id='view__upload' type={"file"} multiple onChange={onChange}/>
      
      { state.newComment.files.length 
        ? <ImagesBlock files={state.newComment.files} dispatch={dispatch} classes={"view__form_images"}/>
        : null}
    </div>
  )
}

export default ViewInputImages