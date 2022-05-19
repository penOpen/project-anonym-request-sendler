import React from 'react'
import { Link } from 'react-router-dom'
import "./Footer.css"

function Footer() {
  return (
    <footer>
      <div className='center-items column-items'>
        <p>©Kiril Corp. 2022.</p>
        <p>Все права защищены</p>
        <p>
          <Link to='/privacy'>Политика конфиденциальности</Link> | <Link to="/eula">Условия использования</Link>
        </p>
      </div>
    </footer>
  )
}

export default Footer