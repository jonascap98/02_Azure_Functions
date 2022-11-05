using System;

namespace BezoekersService.Models
{
    public class CalculationRequest
    {
        public int Getal1 { get; set; }
        public int Getal2 { get; set; }

        public char Operator { get; set; }
    }
}
