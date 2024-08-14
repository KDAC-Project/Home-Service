import React from 'react';
import Navbar from "../components/Navbar";
//import '../styles/FAQ.css';

function FAQ() {
  return (
    <>
    <Navbar />
   
    
    <div className="faq-container">
      <h2 className="faq-title">F.A.Q</h2>
      <div className="faq-grid">
        <div className="faq-section">
          <div className="faq-question">
            <h3>How are charges determined for your services?</h3>
          </div>
          <div className="faq-answer">
            <p>Our pricing model is centered on transparency and fairness. We assess the tasks required comprehensively, providing you with a detailed breakdown of costs tailored to your specific needs. With a focus on accuracy and value, we ensure no hidden fees, giving you confidence in our service.</p>
          </div>
        </div>
        <div className="faq-section">
          <div className="faq-question">
            <h3>Do you have a cancellation policy?</h3>
          </div>
          <div className="faq-answer">
            <p>We understand that plans can change unexpectedly. To accommodate this, we kindly request at least 24 hours' notice for cancellations or rescheduling. This allows us to adjust our schedule efficiently while minimizing disruptions. Failure to provide sufficient notice may incur a cancellation fee, ensuring fairness to all our clients.</p>
          </div>
        </div>
        <div className="faq-section">
          <div className="faq-question">
            <h3>Do you provide insurance for your services?</h3>
          </div>
          <div className="faq-answer">
            <p>Yes, your safety and peace of mind are of utmost importance to us. To provide comprehensive protection, we maintain full insurance coverage for both your property and our team members. Rest assured, you are in capable hands, and any unforeseen incidents are fully covered, ensuring a worry-free experience.</p>
          </div>
        </div>
        <div className="faq-section">
          <div className="faq-question">
            <h3>What is our refund policy?</h3>
          </div>
          <div className="faq-answer">
            <p>Your satisfaction is paramount to us. Should you find any aspect of our service unsatisfactory, please inform us within 24 hours with Grievances Redressal Form. We are committed to promptly addressing your concerns, striving to resolve them to your satisfaction or issuing a refund if necessary. Your trust in us is our priority.</p>
          </div>
        </div>
        <div className="faq-section">
          <div className="faq-question">
            <h3>Are your products eco-friendly?</h3>
          </div>
          <div className="faq-answer">
            <p>Absolutely. We are deeply committed to environmental responsibility and your well-being. Our choice of Eco-friendly, non-toxic cleaning products reflects this commitment, ensuring a safe and sustainable cleaning experience for your home. With us, you can enjoy a spotless home while minimizing your ecological footprint.</p>
          </div>
        </div>
        <div className="faq-section">
          <div className="faq-question">
            <h3>What areas do you serve?</h3>
          </div>
          <div className="faq-answer">
            <p>We are humbled to offer our services across more than 20 cities, communities, and their surrounding areas. Our commitment to excellence drives us to serve as many clients as possible with the highest standards of service. Reach out to us today to discover the difference and book your appointment.</p>
          </div>
        </div>
      </div>
    </div>
    </>
  );
   
}

export default FAQ;
