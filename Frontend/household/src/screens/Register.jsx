import { useState } from "react";
import { toast } from "react-toastify";
import { Link, useNavigate } from "react-router-dom";
import { register } from '../services/admin';
import Navbar from "../components/Navbar";
import '../styles/Register.css'

function Register() {
  const [Name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [phone, setPhone] = useState('');

  const navigate = useNavigate();

  const onRegister = async () => {
    if (Name.length === 0) {
      toast.error('please enter name');
    } else if (email.length === 0) {
      toast.error('please enter email');
    } else if (password.length === 0) {
      toast.error('please enter password');
    } else {
      const result = await register(Name, email, password, phone);
      if (result['status'] === 'success') {
        toast.success('Successfully registered a new user');
        navigate('/login');
      } else {
        toast.error(result['error']);
      }
    }
  };

  return (
    <>
      <Navbar />
      <div className="container mt-5">
        <h2 className="page-header text-center">Register User</h2>
        <div className="row justify-content-center">
          <div className="col-md-6">
            <div className="form">
              <div className="mb-3">
                <label htmlFor="name">Name</label>
                <input
                  id="name"
                  onChange={(e) => setName(e.target.value)}
                  type="text"
                  className="form-control"
                />
              </div>
              <div className="mb-3">
                <label htmlFor="email">Email</label>
                <input
                  id="email"
                  onChange={(e) => setEmail(e.target.value)}
                  type="email"
                  className="form-control"
                />
              </div>
              <div className="mb-3">
                <label htmlFor="phone">Phone Number</label>
                <input
                  id="phone"
                  onChange={(e) => setPhone(e.target.value)}
                  type="tel"
                  className="form-control"
                />
              </div>
              <div className="mb-3">
                <label htmlFor="password">Password</label>
                <input
                  id="password"
                  onChange={(e) => setPassword(e.target.value)}
                  type="password"
                  className="form-control"
                />
              </div>
              <div className="mb-3 text-center">
                <div>
                  Already have an account? <Link to="/login">Login here</Link>
                </div>
                <button onClick={onRegister} className="btn btn-success mt-2">
                  Register
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default Register;
