namespace HomeServices.Dto
{
    public class BookingDto
    {
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int WorkerID { get; set; }
        public int ServiceID { get; set; }
        public DateTime BookingDate { get; set; }
        public int StatusID { get; set; }
        public int PaymentID { get; set; }

    }
}
