using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Car
    {
        [Key]
        public int Car_Id { get; set; }
        [Required]
        public string Brand { get; set; }
        public int YearMade { get; set; }
        [Required]
        public int Seats { get; set; }
        [Required]
        public int PricePerDay { get; set; }
        public bool Availability { get; set; }

    }
}
