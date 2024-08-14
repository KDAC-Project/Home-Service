import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { Navbar } from 'react-bootstrap';

function BookingForm() {
  debugger;
  const [formData, setFormData] = useState({
    customerID: '',
    workerID: '',
    serviceID: '',
    bookingDate: '',
    statusID: '',
    paymentID: ''
  });

  const navigate = useNavigate();
debugger;
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    debugger;
    axios.post('/api/Booking', formData)
      .then(response => {
        debugger;
        console.log('Booking created:', response.data);
        navigate(`/bookingDetails/${response.data.bookingID}`);
      })
      .catch(error => {
        console.error('Error creating booking:', error);
      });
  };

  return (
    <>
    <Navbar />
    
    <div className="container d-flex align-items-center justify-content-center min-vh-100">
      <div className="row w-100">
        <div className="col-md-6 mx-auto">
          <h2 className="text-center mb-4">Create Booking</h2>
          <form onSubmit={handleSubmit}>
            <div className="form-group mb-3">
              <label htmlFor="customerID">Customer ID:</label>
              <input
                type="text"
                id="customerID"
                name="customerID"
                className="form-control"
                value={formData.customerID}
                onChange={handleChange}
              />
            </div>
            <div className="form-group mb-3">
              <label htmlFor="workerID">Worker ID:</label>
              <input
                type="text"
                id="workerID"
                name="workerID"
                className="form-control"
                value={formData.workerID}
                onChange={handleChange}
              />
            </div>
            <div className="form-group mb-3">
              <label htmlFor="serviceID">Service ID:</label>
              <input
                type="text"
                id="serviceID"
                name="serviceID"
                className="form-control"
                value={formData.serviceID}
                onChange={handleChange}
              />
            </div>
            <div className="form-group mb-3">
              <label htmlFor="bookingDate">Booking Date:</label>
              <input
                type="date"
                id="bookingDate"
                name="bookingDate"
                className="form-control"
                value={formData.bookingDate}
                onChange={handleChange}
              />
            </div>
            <div className="form-group mb-3">
              <label htmlFor="statusID">Status ID:</label>
              <input
                type="text"
                id="statusID"
                name="statusID"
                className="form-control"
                value={formData.statusID}
                onChange={handleChange}
              />
            </div>
            <div className="form-group mb-3">
              <label htmlFor="paymentID">Payment ID:</label>
              <input
                type="text"
                id="paymentID"
                name="paymentID"
                className="form-control"
                value={formData.paymentID}
                onChange={handleChange}
              />
            </div>
            <button type="submit" className="btn btn-primary w-100">Create Booking</button>
          </form>
        </div>
      </div>
    </div>
    </>
  );
}

export default BookingForm;
