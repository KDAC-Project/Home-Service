import { useState } from "react"
import { toast } from "react-toastify"
import { Link, useNavigate } from "react-router-dom"
import { register } from '../services/admin'


function Register() {
    const [Name, setName] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('') 
    const [phone, setPhone] = useState('')
    const [Address, setAddress] = useState('')

  
    // get the navigation hook
    const navigate = useNavigate()
  
    const onRegister = async () => {
      debugger;
      if (Name.length == 0) {
        toast.error('please enter name')
      } else if (email.length == 0) {
        toast.error('please enter email')
      } else if (password.length == 0) {
        toast.error('please enter password')
      
      } else {
        debugger;
        // call post /admin/register api
        const result = await register(Name, email, password, phone,Address)
        if (result == 'success') {
          toast.success('Successfully registered a new user')
          navigate('/login')
        } else {
          toast.error(result['error'])
        }
      }
    }
  
    return (
      <div>
        <h2 className='page-header'>Register User</h2>
        <div className='row'>
          <div className='col'></div>
          <div className='col'>
            <div className='form'>
              <div className='mb-3'>
                <label htmlFor=''>Name</label>
                <input
                  onChange={(e) => setName(e.target.value)}
                  type='text'
                  className='form-control'
                />
              </div>
              <div className='mb-3'>
                <label htmlFor=''>Email</label>
                <input
                  onChange={(e) => setEmail(e.target.value)}
                  type='email'
                  className='form-control'
                />
              </div>
              <div className='mb-3'>
                <label htmlFor=''>Phone Number</label>
                <input
                  onChange={(e) => setPhone(e.target.value)}
                  type='tel'
                  className='form-control'
                />
              </div>
              <div className='mb-3'>
                <label htmlFor=''>Password</label>
                <input
                  onChange={(e) => setPassword(e.target.value)}
                  type='password'
                  className='form-control'
                />
              </div>
              <div className='mb-3'>
                <label htmlFor=''>Address</label>
                <input
                  onChange={(e) => setAddress(e.target.value)}
                  type='text'
                  className='form-control'
                />
              </div>
              <div className='mb-3'>
                <div>
                  Already have an account ? <Link to='/login'>Login here</Link>
                </div>
                <button onClick={onRegister} className='btn btn-success mt-2'>
                  Register
                </button>
              </div>
            </div>
          </div>
          <div className='col'></div>
        </div>
      </div>
    )
  }
  
  export default Register
  