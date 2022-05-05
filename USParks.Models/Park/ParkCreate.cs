using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USParks.Models.Park
{
    public class ParkCreate
    {
        public enum ParkType { national, state }   
        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Park Type (national or state)")]
        public ParkType parkType { get; set; }
        [Required]
        [MaxLength(5000, ErrorMessage = "You have hit the 5000 character limit.")]
        public string Description { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Size (square miles)")]
        [Range(0, 20000, ErrorMessage = "Please enter a number between 0 and 20 thousand.")]
        public int Size { get; set; }
        [Required]
        [Display(Name = "Yearly Visitors")]
        [Range(0, 200000000, ErrorMessage = "Please enter a number between 0 and 20 million.")]
        public int YearlyVisitors { get; set; }
    }
}
