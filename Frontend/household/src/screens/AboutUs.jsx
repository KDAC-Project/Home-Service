import React from 'react';
import '../styles/AboutUs.css';

function App() {
  return (
    <div className="container">
      <div className="image-container">
        <img src="Frontend/src/images/worker.jpg" alt="Man in a hat" /> 
      </div>
      <div className="text-container">
        <h1>About Our Cleaning Service</h1>
        <p>
          We are a professional house cleaning and repair service dedicated to
          transforming your home into a spotless, well-maintained haven for you and your
          family. Our experienced team uses eco-friendly products for a thorough and safe
          cleaning experience, while also providing expert repairs and maintenance. Trust
          us to ensure your home is pristine, functional, and welcoming, allowing you to
          relax and thrive in your perfect space.
        </p>
      </div>
    </div>
  );
}

export default App;