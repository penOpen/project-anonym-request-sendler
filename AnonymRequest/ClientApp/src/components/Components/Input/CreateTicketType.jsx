import React from 'react'

function CreateTicketType(props) {
  const types = [ "Другое", "Выплаты", "Застревание персонажей", "Предметы", "Внутриигровое время", "Аукцион", "Почта" ]
  const typeOptionsList = []

  for (let i = 0; i < types.length; i++) {
    typeOptionsList.push(<option value={`${i}`}> { types[i] } </option>)
  }

  return (
    <select 
      size={1}
      className="create__select"
      defaultValue={"0"}
      onChange={props.onChange}
    >
      {typeOptionsList}
    </select>
  )
}

export default CreateTicketType