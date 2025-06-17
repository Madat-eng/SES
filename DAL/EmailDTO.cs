namespace DAL
{
    public class EmailDTO
    {
        public int EmailID { get; set; }
        public string EmailAddress { get; set; }
        public bool IsVerified { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
