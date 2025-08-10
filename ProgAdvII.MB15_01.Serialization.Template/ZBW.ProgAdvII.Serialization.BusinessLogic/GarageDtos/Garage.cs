using System.Collections.Generic;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic.GarageDtos {
    public class Garage {
        public int GarageNumber { get; set; }
        public Address Address { get; set; }
        public List<Car> Cars { get; set; }
    }
}