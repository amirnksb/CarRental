using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Car")]
        public int Car_Id { get; set; }
        [ForeignKey("Car_Id")]
        public Car car { get; set; }
        [DisplayName("Name")]
        public int Student_Id { get; set; }
        [ForeignKey("Student_Id")]
        public Student student { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public float Price { get; set; }
        [Required]
        public DateTime RentDate { get; set; }
    }
}
