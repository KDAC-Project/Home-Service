-- Insert dummy data into Categories table first
INSERT INTO Categories (CategoryName) VALUES
('Plumbing'),
('Electrical'),
('Cleaning'),
('Carpentry'),
('Painting'),
('Gardening'),
('Moving'),
('Pest Control'),
('HVAC'),
('Handyman');

-- Insert dummy data into Services table
INSERT INTO Services (Description, CategoryID) VALUES
('Fix leaking faucet', 1),
('Install new light fixture', 2),
('Deep cleaning for a 3-bedroom house', 3),
('Build custom bookshelf', 4),
('Interior wall painting', 5),
('Lawn mowing and trimming', 6),
('Help with moving furniture', 7),
('Exterminate rodents', 8),
('Air conditioning repair', 9),
('General home repairs', 10);

-- Insert dummy data into Customers table
INSERT INTO Customers (Name, Email, Phone, Address, Password) VALUES
('John Doe', 'john.doe@example.com', '1234567890', '123 Main St', 'password1'),
('Jane Smith', 'jane.smith@example.com', '1234567891', '456 Elm St', 'password2'),
('Mike Johnson', 'mike.johnson@example.com', '1234567892', '789 Oak St', 'password3'),
('Emily Davis', 'emily.davis@example.com', '1234567893', '101 Pine St', 'password4'),
('Chris Brown', 'chris.brown@example.com', '1234567894', '102 Maple St', 'password5'),
('Patricia Taylor', 'patricia.taylor@example.com', '1234567895', '103 Birch St', 'password6'),
('Robert Anderson', 'robert.anderson@example.com', '1234567896', '104 Cedar St', 'password7'),
('Linda Martinez', 'linda.martinez@example.com', '1234567897', '105 Walnut St', 'password8'),
('James Lee', 'james.lee@example.com', '1234567898', '106 Cherry St', 'password9'),
('Barbara Harris', 'barbara.harris@example.com', '1234567899', '107 Poplar St', 'password10');

-- Insert dummy data into Workers table
INSERT INTO Workers (Name, Email, Phone, Skill, Password) VALUES
('Alex Green', 'alex.green@example.com', '2345678901', 'Plumbing', 'workerpassword1'),
('Samantha White', 'samantha.white@example.com', '2345678902', 'Electrical', 'workerpassword2'),
('Daniel Black', 'daniel.black@example.com', '2345678903', 'Cleaning', 'workerpassword3'),
('Nancy Blue', 'nancy.blue@example.com', '2345678904', 'Carpentry', 'workerpassword4'),
('George Yellow', 'george.yellow@example.com', '2345678905', 'Painting', 'workerpassword5'),
('Karen Brown', 'karen.brown@example.com', '2345678906', 'Gardening', 'workerpassword6'),
('Paul Red', 'paul.red@example.com', '2345678907', 'Moving', 'workerpassword7'),
('Lucy Pink', 'lucy.pink@example.com', '2345678908', 'Pest Control', 'workerpassword8'),
('Tom Orange', 'tom.orange@example.com', '2345678909', 'HVAC', 'workerpassword9'),
('Betty Violet', 'betty.violet@example.com', '2345678910', 'Handyman', 'workerpassword10');

-- Insert dummy data into Status table
INSERT INTO Status ( StatusDesc) VALUES
( 'Pending'),
( 'Confirmed'),
( 'Completed'),
( 'Cancelled'),
( 'In Progress');

-- Insert dummy data into Payments table
INSERT INTO Payments (Amount, PaymentDate) VALUES
(100.00, '2023-01-01'),
(150.00, '2023-02-01'),
(200.00, '2023-03-01'),
(250.00, '2023-04-01'),
(300.00, '2023-05-01'),
(350.00, '2023-06-01'),
(400.00, '2023-07-01'),
(450.00, '2023-08-01'),
(500.00, '2023-09-01'),
(550.00, '2023-10-01');

-- Insert dummy data into Ratings table
INSERT INTO Ratings (WorkerID, RatingValue) VALUES
(1, 5),
(2, 4),
(3, 3),
(4, 5),
(5, 4),
(6, 3),
(7, 5),
(8, 4),
(9, 3),
(10, 5);

INSERT INTO WorkerPayments (WorkerID, WpaymentAmount, WpaymentDate) VALUES
(1, 50.00, '2023-01-15'),
(2, 75.00, '2023-02-15'),
(3, 100.00, '2023-03-15'),
(4, 125.00, '2023-04-15'),
(5, 150.00, '2023-05-15'),
(6, 175.00, '2023-06-15'),
(7, 200.00, '2023-07-15'),
(8, 225.00, '2023-08-15'),
(9, 250.00, '2023-09-15'),
(10, 275.00, '2023-10-15');

-- Insert dummy data into Bookings table
INSERT INTO Bookings (CustomerID, WorkerID, ServiceID, BookingDate, StatusID, PaymentID) VALUES
(1, 1, 1, '2023-01-10', 1, 1),
(2, 2, 2, '2023-02-10', 2, 2),
(3, 3, 3, '2023-03-10', 3, 3),
(4, 4, 4, '2023-04-10', 4, 4),
(5, 5, 5, '2023-05-10', 5, 5),
(6, 6, 6, '2023-06-10', 1, 6),
(7, 7, 7, '2023-07-10', 2, 7),
(8, 8, 8, '2023-08-10', 3, 8),
(9, 9, 9, '2023-09-10', 4, 9),
(10, 10, 10, '2023-10-10', 5, 10);