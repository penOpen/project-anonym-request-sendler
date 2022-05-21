import React from 'react'

function CreateInputFiles(props) {
  const { dispatch } = props
  
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
    if (fileList.length > 5) return
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
    <div className='wrap_create__files'>
      <label 
        htmlFor='send_files' 
        className='create__files'
      >
        <p>Выберите файлы</p>
      </label>

      <input
        type='file'
        id='send_files'
        multiple
        accept='.png,.jpg,.jpeg'
        onChange={onChange}
      />
    </div>
  )
}

export default CreateInputFiles