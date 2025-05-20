namespace Cinema.dto
{
    public class CreateTicketDto
    {
        public int SessionId { get; set; }
        public int SeatId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int UserId { get; set; }
    }

}
