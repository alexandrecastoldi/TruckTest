using System;
using System.Collections.Generic;
using System.Text;
using TruckTest.Domain.Entities.Enum;

namespace TruckTest.Domain.Dtos
{
    public class TruckDto
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime LastUpdate { get; set; }
        public TruckModel Model { get; set; }
        public string ModelName { get; set; }
        public int YearFactory { get; set; }
        public int YearModel { get; set; }
    }
}
