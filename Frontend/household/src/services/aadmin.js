import axios from 'axios';
import { config } from './config';

export async function login(email, password) {
    try {
      // Post body
      const body = { email, password };
  
      // Send the post request
      const response = await axios.post(`${config.serverUrl}/api/Admin/Login`, body);
  
      // Return the json body from response object
      return response;
    } catch (ex) {
      console.log(`Exception: `, ex);
    }
  
    return null;
  }