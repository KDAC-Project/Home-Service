import { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { toast } from 'react-toastify'
import { wlogin } from '../services/Worker.js';
import "../styles/Login.css";

debugger;
function Login() {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [isEmailEmpty, setEmailEmpty] = useState(false)
  const [isPasswordEmpty, setPasswordEmpty] = useState(false)
  

  // get navigation hook
  const navigate = useNavigate()

  const onLogin = async () => {
    debugger;
    if (email.length == 0) {
      toast.error('Please enter email')
    } else if (password.length == 0) {
      toast.error('Please enter password')
    } else {
      try 
      {
      // call login API and check its success
      // go to home screen
      const response = await wlogin(email, password);
      debugger;
      console.log(response.status);
        if (response.status === 200) {
          toast.success('Login Successful');
           navigate('/WorkerDetails')
        } else {
          toast.error('Login failed. Please check your email and password.');
        }
      } catch (error) {
        toast.error('An error occurred during login. Please try again.');
      }
    }
  };
    
  

  return (
    <div>
      <h2 className='page-header'>Login</h2>
      <div className='row'>
        <div className='col'></div>
        <div className='col'>
          <div className='form'>
            <div className='mb-3'>
              <label htmlFor=''>Email</label>
              <input
                onChange={(e) => {
                  if (e.target.value.length == 0) {
                    setEmailEmpty(true)
                  } else {
                    setEmailEmpty(false)
                  }
                  setEmail(e.target.value)
                }}
                type='email'
                className='form-control'
              />
              {isEmailEmpty && (
                <p style={{ color: 'red' }}>Email is mandatory</p>
              )}
            </div>
            <div className='mb-3'>
              <label htmlFor=''>Password</label>
              <input
                onChange={(e) => {
                  if (e.target.value.length == 0) {
                    setPasswordEmpty(true)
                  } else {
                    setPasswordEmpty(false)
                  }
                  setPassword(e.target.value)
                }}
                type='password'
                className='form-control'
              />
              {isPasswordEmpty && (
                <p style={{ color: 'red' }}>Password is mandatory</p>
              )}
            </div>
            <div className='mb-3'>
              <div>
                Don't have account ? <Link to='/WorkerRegister'>Register here</Link>
              </div>
              <button onClick={onLogin} className='btn btn-success mt-2'>
                Login
              </button>
            </div>
          </div>
        </div>
        <div className='col'></div>
      </div>
    </div>
  )
}

export default Login
