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
    if (fileList.length > 2) return
    const filteredFiles = []
    for (let f of fileList) {
      if (["image/jpeg", "image/png", "image/jpg"].includes(f.type)) filteredFiles.push(f)
    }
    if (!filteredFiles.length) return
    const parsedFiles = await filesToURL(filteredFiles)
    const merge = []
    for (let i = 0; i < filteredFiles.length; i++) {
      merge.push(
        {
          name: filteredFiles[i].name, 
          code: parsedFiles[i]
        }
      )
    }
    dispatch( {type: "files", payload: merge} )
  }

  return (
    <div className='wrap_view__form_images'>
      <label className='view__form_images_upload' htmlFor='view__upload'> </label>
      <input name='view__upload' id='view__upload' type={"file"} multiple onChange={onChange} accept=".png,.jpg,.jpeg"/>
      
      { state.newComment.files.length 
        ? <ImagesBlock files={state.newComment.files} dispatch={dispatch} classes={"view__form_images"}/>
        : null}
    </div>
  )
}

export default ViewInputImages