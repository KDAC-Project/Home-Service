import axios from 'axios'
import { config } from './config'

export async function register(Name, email, password, phone) {
  try {
    // post body
    const body = { Name, email, password, phone }

    // send the post request
    const response = await axios.post(`${config.serverUrl}/user/register`, body)

    // return the json body from response object
    return response.data
  } catch (ex) {
    console.log(`exception: `, ex)
  }

  return null
}
