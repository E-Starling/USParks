using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USParks.Models.Park
{
    public class ParkEdit
    {
        public enum ParkType { national, state }

        [Display(Name = "Park Id")]
        public int ParkId { get; set; }
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Display(Name = "Park Type")]
        public ParkType parkType { get; set; }
        [MaxLength(5000, ErrorMessage = "You have hit the 5000 character limit.")]
        public string Description { get; set; }
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Location { get; set; }
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public int Size { get; set; }
        [Display(Name = "Yearly Visitors")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public int YearlyVisitors { get; set; }
    }
}
