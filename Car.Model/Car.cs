using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Car.Model
{
    public class Vehicle
    {
        [Required]
        public string Make { get; set; }
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        public string Color { get; set; }
        [Required]
        [Range(0,2019)]
        public int Year { get; set; }
        [Range(0,1000000)]
        public double Price { get; set; }
        [Range(0,10)]
        public double TCCRating { get; set; }
        [Range(0,100)]
        public int HwyMPG { get; set; }
    }
}
