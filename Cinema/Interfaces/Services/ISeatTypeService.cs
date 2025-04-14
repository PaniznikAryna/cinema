using Cinema.Entity;

namespace Cinema.Interfaces.Services
{
    public interface ISeatTypeService
    {
        IEnumerable<SeatType> GetAll();
        SeatType? GetById(int id);
        SeatType Add(SeatType seattype);
        void Update(SeatType seattype);
        void Delete(int id);
    }
}
