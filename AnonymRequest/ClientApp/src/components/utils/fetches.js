/**
 * Returns fetch what you need. Dev fetches starts with "__"
 * @param {'__view' | '__find' | 'GETview' | 'GETfind' | 'POSTcreate' | 'POSTview'} type type of fetch
 * @return {(options) => Promise<string>} fetch
 * @example 
 * const fetch = getFetch("__view")
 * fetch({guid: "some-guid-1234"}).then(value => JSON.parse(value)).then(...)
 */
export default function getFetch(type) {
  switch (type) {
    case "__view":
      return fakeFetchGetTicket
    case "__find":
      return fakeFetchGetTicketFind
    case "GETview":
      return _viewFetchGet
    case "GETfind":
      return _findFetchGet
    case "POSTcreate":
      return _createFetchPost
    case "POSTview":
      return _viewFetchPost
    default:
      return null
  }
}

async function _viewFetchGet(body) {
  const res = await getData('/api/view', body)
  return res
}

async function _createFetchPost(body) {
  const res = await postData("/api/create", body)
  return res
}

async function _findFetchGet(body) {
  const res = await getData('/api/find', body)
  return res
}

async function _viewFetchPost(body) {
  const res = await postData('/api/view', body)
  return res
}

export async function fakeFetchGetTicket(body) {
  await new Promise((resolve) => setTimeout(() => {
    resolve()
  }, 3000)) // sleep

  if (body.guid === "936DA01F-9ABD-4d9d-80C7-02AF85C822A8") {
    return JSON.stringify({
      status: 200,
      ok: true,
      value: {
        name: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
        description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
        files: [ 
          { 
            name: "sede4ko.jpg", 
            code: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACAUlEQVR4AWKgGmgRY4gC4htA/BxAKDnA2hFFUXS+bdu2bdsKatu226iNWdu2gjqqjTjfen4zs3vvqfmTrME52euScYlR+1Ovgde+9t4yxvweXnsyzgKfOoIxMCUO79pCcDLVBRvdDWcy5pzKcMW79lD0jY/CxxovnI4xB8ts+xYu3OhhJA5OjoS4JBXi8gyIS9PRNSMJO0JttNujXJW9c1KoppuXBNXEKPS3+GF/iAmXlHDBjSfFdtDPi4W8JgvyulzIa3MgrclG95wkXCpw/VYjiWZ6LBStvniSa8sFt7lgYLDVGeJ8LsgGNuT9wqPmAAwuTiOJuCwD2hlxJOircuCCYS5QDdXbQTczAtKqDMjrv4Y3fkG9Motq0uos6BelQj05mgT95dbgWS64+ybTEJo2B+inB0NaHA95VTqwnmZDI0srM6BfmADtpBAoGpwwVGyCt2kCFzzggjEnQgUoSk2gabWFfqwrpKlekGf6EPxbP86VeooyEwzlC8TpMBJM+nYSZ86HCxguMYK62Qa60c4QJ7oT/JvXFKz3LXwhgsL8Xhh9E5gydh0KEvA81QCqOku2JDuCfw8XGlDwZaqAo8EUPsCw+NttbGB0XY9isyk2Ir6NepXVvt7EtpGutDuf3rlwChJnvqz3POPzRInNF8xAPBOoEaZ5GrkZrAuc5mkJAAifZEc6f0TMAAAAAElFTkSuQmCC"
          },
          { 
            name: "sede4ko.jpg", 
            code: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACAUlEQVR4AWKgGmgRY4gC4htA/BxAKDnA2hFFUXS+bdu2bdsKatu226iNWdu2gjqqjTjfen4zs3vvqfmTrME52euScYlR+1Ovgde+9t4yxvweXnsyzgKfOoIxMCUO79pCcDLVBRvdDWcy5pzKcMW79lD0jY/CxxovnI4xB8ts+xYu3OhhJA5OjoS4JBXi8gyIS9PRNSMJO0JttNujXJW9c1KoppuXBNXEKPS3+GF/iAmXlHDBjSfFdtDPi4W8JgvyulzIa3MgrclG95wkXCpw/VYjiWZ6LBStvniSa8sFt7lgYLDVGeJ8LsgGNuT9wqPmAAwuTiOJuCwD2hlxJOircuCCYS5QDdXbQTczAtKqDMjrv4Y3fkG9Motq0uos6BelQj05mgT95dbgWS64+ybTEJo2B+inB0NaHA95VTqwnmZDI0srM6BfmADtpBAoGpwwVGyCt2kCFzzggjEnQgUoSk2gabWFfqwrpKlekGf6EPxbP86VeooyEwzlC8TpMBJM+nYSZ86HCxguMYK62Qa60c4QJ7oT/JvXFKz3LXwhgsL8Xhh9E5gydh0KEvA81QCqOku2JDuCfw8XGlDwZaqAo8EUPsCw+NttbGB0XY9isyk2Ir6NepXVvt7EtpGutDuf3rlwChJnvqz3POPzRInNF8xAPBOoEaZ5GrkZrAuc5mkJAAifZEc6f0TMAAAAAElFTkSuQmCC"
          },
          { 
            name: "sede4ko.jpg", 
            code: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACAUlEQVR4AWKgGmgRY4gC4htA/BxAKDnA2hFFUXS+bdu2bdsKatu226iNWdu2gjqqjTjfen4zs3vvqfmTrME52euScYlR+1Ovgde+9t4yxvweXnsyzgKfOoIxMCUO79pCcDLVBRvdDWcy5pzKcMW79lD0jY/CxxovnI4xB8ts+xYu3OhhJA5OjoS4JBXi8gyIS9PRNSMJO0JttNujXJW9c1KoppuXBNXEKPS3+GF/iAmXlHDBjSfFdtDPi4W8JgvyulzIa3MgrclG95wkXCpw/VYjiWZ6LBStvniSa8sFt7lgYLDVGeJ8LsgGNuT9wqPmAAwuTiOJuCwD2hlxJOircuCCYS5QDdXbQTczAtKqDMjrv4Y3fkG9Motq0uos6BelQj05mgT95dbgWS64+ybTEJo2B+inB0NaHA95VTqwnmZDI0srM6BfmADtpBAoGpwwVGyCt2kCFzzggjEnQgUoSk2gabWFfqwrpKlekGf6EPxbP86VeooyEwzlC8TpMBJM+nYSZ86HCxguMYK62Qa60c4QJ7oT/JvXFKz3LXwhgsL8Xhh9E5gydh0KEvA81QCqOku2JDuCfw8XGlDwZaqAo8EUPsCw+NttbGB0XY9isyk2Ir6NepXVvt7EtpGutDuf3rlwChJnvqz3POPzRInNF8xAPBOoEaZ5GrkZrAuc5mkJAAifZEc6f0TMAAAAAElFTkSuQmCC"
          },
          { 
            name: "sede4ko.jpg", 
            code: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACAUlEQVR4AWKgGmgRY4gC4htA/BxAKDnA2hFFUXS+bdu2bdsKatu226iNWdu2gjqqjTjfen4zs3vvqfmTrME52euScYlR+1Ovgde+9t4yxvweXnsyzgKfOoIxMCUO79pCcDLVBRvdDWcy5pzKcMW79lD0jY/CxxovnI4xB8ts+xYu3OhhJA5OjoS4JBXi8gyIS9PRNSMJO0JttNujXJW9c1KoppuXBNXEKPS3+GF/iAmXlHDBjSfFdtDPi4W8JgvyulzIa3MgrclG95wkXCpw/VYjiWZ6LBStvniSa8sFt7lgYLDVGeJ8LsgGNuT9wqPmAAwuTiOJuCwD2hlxJOircuCCYS5QDdXbQTczAtKqDMjrv4Y3fkG9Motq0uos6BelQj05mgT95dbgWS64+ybTEJo2B+inB0NaHA95VTqwnmZDI0srM6BfmADtpBAoGpwwVGyCt2kCFzzggjEnQgUoSk2gabWFfqwrpKlekGf6EPxbP86VeooyEwzlC8TpMBJM+nYSZ86HCxguMYK62Qa60c4QJ7oT/JvXFKz3LXwhgsL8Xhh9E5gydh0KEvA81QCqOku2JDuCfw8XGlDwZaqAo8EUPsCw+NttbGB0XY9isyk2Ir6NepXVvt7EtpGutDuf3rlwChJnvqz3POPzRInNF8xAPBOoEaZ5GrkZrAuc5mkJAAifZEc6f0TMAAAAAElFTkSuQmCC"
          },
          { 
            name: "sede4ko.jpg", 
            code: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACAUlEQVR4AWKgGmgRY4gC4htA/BxAKDnA2hFFUXS+bdu2bdsKatu226iNWdu2gjqqjTjfen4zs3vvqfmTrME52euScYlR+1Ovgde+9t4yxvweXnsyzgKfOoIxMCUO79pCcDLVBRvdDWcy5pzKcMW79lD0jY/CxxovnI4xB8ts+xYu3OhhJA5OjoS4JBXi8gyIS9PRNSMJO0JttNujXJW9c1KoppuXBNXEKPS3+GF/iAmXlHDBjSfFdtDPi4W8JgvyulzIa3MgrclG95wkXCpw/VYjiWZ6LBStvniSa8sFt7lgYLDVGeJ8LsgGNuT9wqPmAAwuTiOJuCwD2hlxJOircuCCYS5QDdXbQTczAtKqDMjrv4Y3fkG9Motq0uos6BelQj05mgT95dbgWS64+ybTEJo2B+inB0NaHA95VTqwnmZDI0srM6BfmADtpBAoGpwwVGyCt2kCFzzggjEnQgUoSk2gabWFfqwrpKlekGf6EPxbP86VeooyEwzlC8TpMBJM+nYSZ86HCxguMYK62Qa60c4QJ7oT/JvXFKz3LXwhgsL8Xhh9E5gydh0KEvA81QCqOku2JDuCfw8XGlDwZaqAo8EUPsCw+NttbGB0XY9isyk2Ir6NepXVvt7EtpGutDuf3rlwChJnvqz3POPzRInNF8xAPBOoEaZ5GrkZrAuc5mkJAAifZEc6f0TMAAAAAElFTkSuQmCC"
          }
        ],
        status: 0,
        moderator: {
          avatar: null,
          name: "da986902-60fa-475a-a6e2-e7b6e8269927"
        },
        comments: [
          {
            id: 0,
            isMod: true,
            time: 1652141444545,
            text: "я не ебу че делать",
            files: [
              { 
                name: "sede4ko.jpg", 
                code: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACAUlEQVR4AWKgGmgRY4gC4htA/BxAKDnA2hFFUXS+bdu2bdsKatu226iNWdu2gjqqjTjfen4zs3vvqfmTrME52euScYlR+1Ovgde+9t4yxvweXnsyzgKfOoIxMCUO79pCcDLVBRvdDWcy5pzKcMW79lD0jY/CxxovnI4xB8ts+xYu3OhhJA5OjoS4JBXi8gyIS9PRNSMJO0JttNujXJW9c1KoppuXBNXEKPS3+GF/iAmXlHDBjSfFdtDPi4W8JgvyulzIa3MgrclG95wkXCpw/VYjiWZ6LBStvniSa8sFt7lgYLDVGeJ8LsgGNuT9wqPmAAwuTiOJuCwD2hlxJOircuCCYS5QDdXbQTczAtKqDMjrv4Y3fkG9Motq0uos6BelQj05mgT95dbgWS64+ybTEJo2B+inB0NaHA95VTqwnmZDI0srM6BfmADtpBAoGpwwVGyCt2kCFzzggjEnQgUoSk2gabWFfqwrpKlekGf6EPxbP86VeooyEwzlC8TpMBJM+nYSZ86HCxguMYK62Qa60c4QJ7oT/JvXFKz3LXwhgsL8Xhh9E5gydh0KEvA81QCqOku2JDuCfw8XGlDwZaqAo8EUPsCw+NttbGB0XY9isyk2Ir6NepXVvt7EtpGutDuf3rlwChJnvqz3POPzRInNF8xAPBOoEaZ5GrkZrAuc5mkJAAifZEc6f0TMAAAAAElFTkSuQmCC"
              },
              { 
                name: "sede4ko.jpg", 
                code: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACAUlEQVR4AWKgGmgRY4gC4htA/BxAKDnA2hFFUXS+bdu2bdsKatu226iNWdu2gjqqjTjfen4zs3vvqfmTrME52euScYlR+1Ovgde+9t4yxvweXnsyzgKfOoIxMCUO79pCcDLVBRvdDWcy5pzKcMW79lD0jY/CxxovnI4xB8ts+xYu3OhhJA5OjoS4JBXi8gyIS9PRNSMJO0JttNujXJW9c1KoppuXBNXEKPS3+GF/iAmXlHDBjSfFdtDPi4W8JgvyulzIa3MgrclG95wkXCpw/VYjiWZ6LBStvniSa8sFt7lgYLDVGeJ8LsgGNuT9wqPmAAwuTiOJuCwD2hlxJOircuCCYS5QDdXbQTczAtKqDMjrv4Y3fkG9Motq0uos6BelQj05mgT95dbgWS64+ybTEJo2B+inB0NaHA95VTqwnmZDI0srM6BfmADtpBAoGpwwVGyCt2kCFzzggjEnQgUoSk2gabWFfqwrpKlekGf6EPxbP86VeooyEwzlC8TpMBJM+nYSZ86HCxguMYK62Qa60c4QJ7oT/JvXFKz3LXwhgsL8Xhh9E5gydh0KEvA81QCqOku2JDuCfw8XGlDwZaqAo8EUPsCw+NttbGB0XY9isyk2Ir6NepXVvt7EtpGutDuf3rlwChJnvqz3POPzRInNF8xAPBOoEaZ5GrkZrAuc5mkJAAifZEc6f0TMAAAAAElFTkSuQmCC"
              }
            ]
          },
          {
            id: 1,
            isMod: false,
            time: 1652141454545,
            text: "я тоже",
            files: [
              { 
                name: "sede4ko.jpg", 
                code: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAACAUlEQVR4AWKgGmgRY4gC4htA/BxAKDnA2hFFUXS+bdu2bdsKatu226iNWdu2gjqqjTjfen4zs3vvqfmTrME52euScYlR+1Ovgde+9t4yxvweXnsyzgKfOoIxMCUO79pCcDLVBRvdDWcy5pzKcMW79lD0jY/CxxovnI4xB8ts+xYu3OhhJA5OjoS4JBXi8gyIS9PRNSMJO0JttNujXJW9c1KoppuXBNXEKPS3+GF/iAmXlHDBjSfFdtDPi4W8JgvyulzIa3MgrclG95wkXCpw/VYjiWZ6LBStvniSa8sFt7lgYLDVGeJ8LsgGNuT9wqPmAAwuTiOJuCwD2hlxJOircuCCYS5QDdXbQTczAtKqDMjrv4Y3fkG9Motq0uos6BelQj05mgT95dbgWS64+ybTEJo2B+inB0NaHA95VTqwnmZDI0srM6BfmADtpBAoGpwwVGyCt2kCFzzggjEnQgUoSk2gabWFfqwrpKlekGf6EPxbP86VeooyEwzlC8TpMBJM+nYSZ86HCxguMYK62Qa60c4QJ7oT/JvXFKz3LXwhgsL8Xhh9E5gydh0KEvA81QCqOku2JDuCfw8XGlDwZaqAo8EUPsCw+NttbGB0XY9isyk2Ir6NepXVvt7EtpGutDuf3rlwChJnvqz3POPzRInNF8xAPBOoEaZ5GrkZrAuc5mkJAAifZEc6f0TMAAAAAElFTkSuQmCC"
              }
            ]
          }
        ]
      }
    })
  } 
  return JSON.stringify({
    status: 404,
    ok: false
  })
}

export async function fakeFetchGetTicketFind(guid) {
  const body = JSON.parse(guid)

  if (body.guid === "936DA01F-9ABD-4d9d-80C7-02AF85C822A8") {
    return JSON.stringify({
      status: 200,
      ok: true,
      value: {
        guid: body.guid
      }
    })
  } 
  return JSON.stringify({
    status: 404,
    ok: false
  })
}

async function getData(url = '', data = {}) {
  const response = await fetch(url, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  })

  return await response.json(); // parses JSON response into native JavaScript objects
}

async function postData(url = '', data = {}) {
  const response = await fetch(url, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  });

  return await response.json(); // parses JSON response into native JavaScript objects
}