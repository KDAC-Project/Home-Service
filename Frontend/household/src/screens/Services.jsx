import React, { useEffect, useState } from 'react';

import Navbar from '../components/Navbar';
import '../styles/Services.css';
import axios from 'axios';
import { Modal, Button } from 'react-bootstrap';

// Mapping of service types to image filenames
const imageMap = {
  Housekeeping: 'housekeeping.jpg',
  Electrician: 'Electrician.jpg',
  Cooking: 'Chef.webp',
};

function Services() {
  const [services, setServices] = useState([]);
  const [show, setShow] = useState(false);
  const [selectedService, setSelectedService] = useState(null);

  useEffect(() => {
    const getServices = async () => {
      try {
        const response = await axios.get('https://localhost:7227/api/Services');
        setServices(response.data);
      } catch (err) {
        console.log(err);
      }
    };
    getServices();
  }, []);

  const handleShow = (service) => {
    setSelectedService(service);
    setShow(true);
  };

  const handleClose = () => setShow(false);

  const handleApply = () => {
    // Add logic to confirm booking
    alert('Booking confirmed!');
    handleClose();
  };

  const handleGetBookingDetails = () => {
    // Logic to fetch booking details or navigate to the details page
    if (selectedService) {
      // Example: redirect to the booking details page
      window.location.href = `/BookingDetails/${selectedService.serviceID}`;
    }
  };

  return (
    <>
      <Navbar />
      <div className="services-container">
        <h1>Our Services</h1>
        <p>Details about the services we offer.</p>
        <br />
        <div className="services-card-container">
          {services.map((service) => {
            const imageUrl = `img/${imageMap[service.title] || 'housekeeping.jpg'}`;
            return (
              <div key={service.serviceID} className="card">
                <img src={imageUrl} className="card-img-top" alt={service.title} />
                <div className="card-body">
                  <p className="card-text">{service.description}</p>
                  <Button variant="primary" onClick={() => handleShow(service)}>
                    Click For Apply
                  </Button>
                </div>
              </div>
            );
          })}
        </div>
      </div>

      {/* Modal for booking confirmation */}
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Booking Confirmation</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p>Your Booking Is Confirmed!!{selectedService?.title}</p>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          
          <Button variant="info" onClick={handleGetBookingDetails}>
            Get Booking Details
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default Services;
