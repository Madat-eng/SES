namespace DAL
{
    public class EmailTransactionDTO
    {
        public int EmailTransactionID { get; set; }
        public int EmailID { get; set; }
        public string SenderEmail { get; set; }
        public string Status { get; set; }
        public DateTime SendDate { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
