import { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { toast } from 'react-toastify'
import Navbar from '../components/Navbar'
import '../styles/Login.css'


function Login() {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [isEmailEmpty, setEmailEmpty] = useState(false)
  const [isPasswordEmpty, setPasswordEmpty] = useState(false)

  // get navigation hook
  const navigate = useNavigate()

  const onLogin = () => {
    if (email.length == 0) {
      toast.error('Please enter email')
    } else if (password.length == 0) {
      toast.error('Please enter password')
    } else {
      // call login API and check its success
      // go to home screen
      navigate('/home')
    }
  }

  return (

    <>
    <Navbar />
    <div className="container">
      <h2 className="page-header">Login</h2>
      <div className="row justify-content-center">
        <div className="col-md-6 col-lg-4">
          <div className="form">
            <div className="mb-3">
              <label htmlFor="email">Email</label>
              <input
                id="email"
                onChange={(e) => {
                  if (e.target.value.length === 0) {
                    setEmailEmpty(true);
                  } else {
                    setEmailEmpty(false);
                  }
                  setEmail(e.target.value);
                }}
                type="email"
                className="form-control"
              />
              {isEmailEmpty && (
                <p style={{ color: 'red' }}>Email is mandatory</p>
              )}
            </div>
            <div className="mb-3">
              <label htmlFor="password">Password</label>
              <input
                id="password"
                onChange={(e) => {
                  if (e.target.value.length === 0) {
                    setPasswordEmpty(true);
                  } else {
                    setPasswordEmpty(false);
                  }
                  setPassword(e.target.value);
                }}
                type="password"
                className="form-control"
              />
              {isPasswordEmpty && (
                <p style={{ color: 'red' }}>Password is mandatory</p>
              )}
            </div>
            <div className="mb-3 text-center">
              <div>
                Don't have an account? <Link to="/register">Register here</Link>
              </div>
              <button onClick={onLogin} className="btn btn-success mt-2">
                Login
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </>
);
}

export default Login
