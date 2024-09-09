import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Container, Row, Col, Card, Spinner, Alert, Button, Navbar } from 'react-bootstrap';
import axios from 'axios';

// Define the API URL (update with your actual API URL)
const API_URL = 'https://localhost:7227/api/Booking';

function BookingDetails() {
  const { bookingId } = useParams();
  const [booking, setBooking] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  debugger;
  useEffect(() => {
    // Fetch booking details from the API
    axios.get(`${API_URL}/${bookingId}`)
      .then(response => {
        setBooking(response.data);
        setLoading(false);
      })
      .catch(error => {
        setError('Booking not found');
        setLoading(false);
      });
  }, [bookingId]);

  if (loading) return <Spinner animation="border" />;
  if (error) return <Alert variant="danger">{error}</Alert>;
  if (!booking) return <Alert variant="warning">Booking not found.</Alert>;

  return (
    <>
    <Navbar />
    <Container className="mt-5">
      <Row className="justify-content-center">
        <Col md={8}>
          <Card>
            <Card.Header as="h5">Booking Details</Card.Header>
            <Card.Body>
              <Card.Title>Booking ID: {booking.bookingID}</Card.Title>
              <Card.Text>
                <strong>Customer ID:</strong> {booking.customerID}
              </Card.Text>
              <Card.Text>
                <strong>Worker ID:</strong> {booking.workerID}
              </Card.Text>
              <Card.Text>
                <strong>Service ID:</strong> {booking.serviceID}
              </Card.Text>
              <Card.Text>
                <strong>Booking Date:</strong> {new Date(booking.bookingDate).toLocaleDateString()}
              </Card.Text>
              <Card.Text>
                <strong>Status ID:</strong> {booking.statusID}
              </Card.Text>
              <Card.Text>
                <strong>Payment ID:</strong> {booking.paymentID}
              </Card.Text>
              <Button variant="primary" href={`/some-other-page`}>Go to Another Page</Button>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </Container>
    </>
  );
}

export default BookingDetails;
