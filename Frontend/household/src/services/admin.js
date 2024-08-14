import axios from 'axios';
import { config } from './config';


export async function register(Name, email, password, phone,Address) {
  try {
    // Post body
    const body = { Name, email, password, phone ,Address };

    // Send the post request
    const response = await axios.post(`${config.serverUrl}/api/Customer`, body);

    // Return the json body from response object
    return response.data;
  } catch (ex) {
    console.log(`Exception: `, ex);
  }

  return null;
}

export async function login(email, password) {
  try {
    debugger;
    // Post body
    const body = { email, password };

    // Send the post request
    const response = await axios.post(`${config.serverUrl}/api/Customer/Login`, body);

    // Return the json body from response object
    return response;
  } catch (ex) {
    console.log(`Exception: `, ex);
  }

  return null;
}


export async function Services(serviceID, description,categoryID) {
  try {
    // Post body
    const body = { serviceID, description,categoryID  };

    // Send the post request
    const response = await axios.post(`${config.serverUrl}/api/Services`, body);

    // Return the json body from response object
    return response.data;
  } catch (ex) {
    console.log(`Exception: `, ex);
  }

  return null;
}

export async function getServices() {
  try {
    // Post body
    //const body = { serviceID, description,categoryID  };

    // Send the post request
    const response = await axios.get(`${config.serverUrl}/api/Services`);

    // Return the json body from response object
    return response.data;
  } catch (ex) {
    console.log(`Exception: `, ex);
  }

  return null;
}