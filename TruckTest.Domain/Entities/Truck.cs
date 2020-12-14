using TruckTest.Domain.Entities.Enum;

namespace TruckTest.Domain.Entities
{
    public class Truck : BaseEntity
    {
        public TruckModel Model { get; set; }
        public int YearFactory { get; set; }
        public int YearModel { get; set; }
    }
}