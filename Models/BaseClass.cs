using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Models
{
    public class BaseClass
    {
        private double lat;
        private double lng;
        private double alt;

        public double Lat { get => lat; set => lat = value; }
        public double Lng { get => lng; set => lng = value; }
        public double Alt { get => alt; set => alt = value; }
    }
}
