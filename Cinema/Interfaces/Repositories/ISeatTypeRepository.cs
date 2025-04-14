using Cinema.Entity;

namespace Cinema.Interfaces.Repositories
{
    public interface ISeatTypeRepository
    {
        IEnumerable<SeatType> GetAll();
        SeatType? GetById(int id);
        SeatType Add(SeatType seattype);
        void Update(SeatType seattype);
        void Delete(int id);
    }
}
