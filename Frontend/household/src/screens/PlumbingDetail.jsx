import React from 'react';
import { useParams } from 'react-router-dom';
import "../styles/PlumbingDetail.css"


// Sample data for demonstration purposes
const plumbingServices = [
  { id: '1', title: 'Pipe Fitting', description: 'Detailed description about pipe fitting.', imageUrl: 'path/to/Pipefitting.jpg' },
  { id: '2', title: 'Leak Repair', description: 'Detailed description about leak repair.', imageUrl: 'path/to/leak-repair.jpg' },
  { id: '3', title: 'Drain Cleaning', description: 'Detailed description about drain cleaning.', imageUrl: 'path/to/drain-cleaning.jpg' },
  // Add more plumbing services as needed
];

function PlumbingDetail() {
  const { id } = useParams();
  const service = plumbingServices.find(s => s.id === id);

  if (!service) return <div>Service not found</div>;

  return (
    <div className="plumbing-detail">
      <h1>{service.title}</h1>
      <img src={service.imageUrl} alt={service.title} />
      <p>{service.description}</p>
    </div>
  );
}

export default PlumbingDetail;
