using AutoService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IspitAvtoServisi.Models {
    public class AddCarToServiceModel {
        public int carId { get; set; }
        public int serviceId { get; set; }

        public List<Car> cars { get; set; } = new List<Car>();
        public List<AutoServisi> autoServices { get; set; } = new List<AutoServisi>();
    }
}