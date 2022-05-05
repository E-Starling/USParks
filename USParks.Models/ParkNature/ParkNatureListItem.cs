using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USParks.Models.ParkNature
{
    public class ParkNatureListItem
    {
        //[Display(Name = "ParkNature Id")]
        //public int ParkNatureId { get; set; }
        [Display(Name = "Nature Id")]
        public int NatureId { get; set; }

        [Display(Name = "Nature Name")]
        public string NatureName { get; set; }
        //[Display(Name = "Park Id")]
        //public int ParkId { get; set; }
    }
}
