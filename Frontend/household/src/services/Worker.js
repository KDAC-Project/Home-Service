import axios from 'axios';
import { config } from './config';

export async function wRegister(Name, email, password, phone,Skill) {
  try {

    // Post body
    const body = { Name, email, password, phone ,Skill };

    // Send the post request
    const response = await axios.post(`${config.serverUrl}/api/Worker`, body);

    // Return the json body from response object
    return response;
  } catch (ex) {
    console.log(`Exception: `, ex);
  }

  return null;
}

export async function wlogin(email, password) {
  try {
    debugger;
    // Post body
    const body = { email, password };

    // Send the post request
    const response = await axios.post(`${config.serverUrl}/api/Worker/Login`, body);

    // Return the json body from response object
    return response;
  } catch (ex) {
    console.log(`Exception: `, ex);
  }

  return null;
}