namespace WebAPi.ViewModel
{
    public class RequestItemVM
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int ItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}

