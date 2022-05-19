import React from 'react'
import errorImage from "./premium-icon-error-2828865.png"

function ViewErrorFindingText() {
  return (
    <div className='view__error_finding_block'>
      <img src={errorImage} alt="idk" />
      <p>Извините, но по вашему запросу ничего не найдено!</p>
    </div>
  )
}

export default ViewErrorFindingText