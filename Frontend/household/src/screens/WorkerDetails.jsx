import React, { useState, useEffect } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import '../styles/WorkerDetails.css'
import Navbar from '../components/Navbar';

const BookingDetailsContainer = () => {
  const [bookingData, setBookingData] = useState({});

  

  useEffect(() => {
    axios.get('/api/worker') // replace with your API endpoint
      .then(response => {
        setBookingData(response.data);
      })
      .catch(error => {
        console.error(error);
      });
  }, []);

  return (
    <div className="container-fluid ">
      <Navbar />
      <div className="row no-gutters" >
        <div className="col-md-10 offset-md-1 worker-info-container">
          <WorkerInfoContainer bookingData={bookingData} />
        </div>
        <div className="col-md-10 offset-md-1 booking-details-container mt-2" >
          <BookingDetails />
        </div>
      </div>
    </div>
  );
};

const BookingDetails = () => {
  return (
    <div className="card mb-0" style={{ padding: '60px',width:'100%'}}>
      <h2 className="card-title">Task Booking Details</h2>
      <button className="btn btn-primary" style={{ padding: '24px 48px' }} onClick={() => window.location.href = '/BookingDetails'}>
       Booking Details
      </button>
    </div>
  );
};

const WorkerInfoContainer = ({ bookingData }) => {
  return (
    <div className="card mb-0" style={{ padding: '60px' ,width:'100%', marginBottom:'20%'}}>
      <div className="text-center">
        <h2 className="card-title">Worker Info</h2>
        <div className="worker-image" style={{ fontSize: '72px' }}>
          <i className="fas fa-user-circle"></i>
        </div>
      </div>
      <div className="worker-details text-center">
        <p>Worker Name: {bookingData.workerName}</p>
        <p>Worker ID: {bookingData.workerId}</p>
      </div>
    </div>
  );
};

export default BookingDetailsContainer;