import React from 'react';
import { Link } from 'react-router-dom';
import Navbar from '../components/Navbar';
import '../styles/Services.css';
import img from '../images/housekeeping.jpg';
import img2 from '../images/Electrician.jpg';
import img3 from '../images/Plumbing.jpg';
import img4 from '../images/Chef.webp';
import img5 from '../images/PestControl.jpeg';
import img6 from '../images/Gardening.jpg';


// Sample data for demonstration purposes
const services = [
  { id: 1, title: 'Housekeeping', description: 'Detailed description about housekeeping.', imageUrl: img, applyLink: '#' },
  { id: 2, title: 'Electrician', description: 'Detailed description about electrician.', imageUrl: img2, applyLink: '#' },
  { id: 3, title: 'Plumbing', description: 'Detailed description about plumbing.', imageUrl: img3, applyLink: '#' },
  { id: 4, title: 'Cooking', description: 'Detailed description about cooking.', imageUrl: img4, applyLink: '#' },
  { id: 5, title: 'Pest Control', description: 'Detailed description about pest control.', imageUrl: img5, applyLink: '#' },
  { id: 6, title: 'Gardening', description: 'Detailed description about gardening.', imageUrl: img6, applyLink: '#' },
];

function Services() {
  return (
    <>
      <Navbar />
      <div className="services-container">
        <h1>Our Services</h1>
        <p>Details about the services we offer.</p>
        <br />
        <div className="services-card-container">
          {services.map(service => (
            <div key={service.id} className="card">
              <img src={service.imageUrl} className="card-img-top" alt={service.title} />
              <div className="card-body">
                <h5 className="card-title">{service.title}</h5>
                <p className="card-text">{service.description}</p>
                <Link to={`/service/${service.id}`} className="btn btn-primary">
                  Click For Apply
                </Link>
              </div>
            </div>
          ))}
        </div>
      </div>
    </>
  );
}

export default Services;
