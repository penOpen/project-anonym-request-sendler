import fs from "fs/promises"

export async function reqres1(req) {
  const dir = await fs.readdir('.\\')
  const requests = []
  const responses = []

  for (let fileName of dir) {
    if (fileName === "req-res1") continue
    let key = fileName.slice(0, 2)
    switch (key) {
      case "req":
        requests.push((await fs.readFile(`.\\${fileName}`)).toString())
        break
      case "res":
        responses.push((await fs.readFile(`.\\${fileName}`)).toString())
        break
      default:
        break
    }
  }

  const reqresmap = new Map()
  for (let i = 0; i < Math.min(requests.length, responses.length); i++) {
    reqresmap.set(requests[i], responses[i])
  }

  if (!reqresmap.has(req)) return
  
}

export async function postData(url = '', data = {}) {

  const response = await fetch(url, {
    method: 'POST',
    cache: 'no-cache',
    credentials: 'same-origin',
    headers: {
      'Content-Type': 'application/json'
    },
    referrerPolicy: 'no-referrer',
    body: JSON.stringify(data)
  });

  return await response.json(); // parses JSON response into native JavaScript objects
}