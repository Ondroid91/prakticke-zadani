using System;
using System.Collections.Generic;
using System.Text;

namespace prakticke_zadani.Models
{
    public class CarSummary
    {
        public string Model { get; set; } = "";
        public double PriceWithoutDph {  get; set; }
        public double PriceWithDph { get; set; }

    }
}
