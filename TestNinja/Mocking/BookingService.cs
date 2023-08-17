using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IBookingService
    {
        IQueryable<Booking> GetOtherActiveBookings(Booking booking);
    }

    public class BookingService : IBookingService
    {
        public IQueryable<Booking> GetOtherActiveBookings(Booking booking)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Id != booking.Id && b.Status != "Cancelled");
            return bookings;
        }
    }
}
