import React, { useState } from 'react'
import FindForm from '../Components/Form/FindForm'
import FindErrorText from '../Components/Modal/FindErrorText'
import "./Find.css"

function Find() {
  const [ok, setOk] = useState(true)

  return (
    <div className="content center-items column-items">
      <FindForm setOk={ setOk }/>
      { ok ? null
          : <FindErrorText/> }
    </div>
  )
}

export default Find