/**
 * Returns fetch what you need. Dev fetches starts with "__"
 * @param {'POSTview' | 'POSTfind' | 'POSTcreate' | 'PUTview'} type type of fetch
 * @return {(options) => Promise<string>} fetch
 * @example 
 * const fetch = getFetch("__view")
 * fetch({guid: "some-guid-1234"}).then(value => JSON.parse(value)).then(...)
 */
export default function getFetch(type) {
  switch (type) {
    case "POSTview":
      return _viewFetchPost
    case "POSTfind":
      return _findFetchPost
    case "POSTcreate":
      return _createFetchPost
    case "PUTview":
      return _viewFetchPut
    default:
      return null
  }
}

async function _viewFetchPost(body) {
  const res = await postData('https://localhost:7144/api/view', body)
  return res
}

async function _createFetchPost(body) {
  const res = await postData("https://localhost:7144/api/create", body)
  return res
}

async function _findFetchPost(body) {
  const res = await postData('https://localhost:7144/api/find', body)
  return res
}

async function _viewFetchPut(body) {
  const res = await putData('https://localhost:7144/api/view', body)
  return res
}

async function postData(url = '', data = {}) {
  const response = await fetch(url, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  }
  );

  return response; // parses JSON response into native JavaScript objects
}

async function putData(url = '', data = {}) {
  const response = await fetch(url, {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  }
  );
  return response // parses JSON response into native JavaScript objects
}