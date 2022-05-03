using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USParks.Models.Park
{
    public class ParkListItem
    {
        public enum ParkType { National, State }

        [Display(Name = "Park Id")]
        public int ParkId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Park Type")]
        public ParkType parkType { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Size { get; set; }
        [Display(Name = "Yearly Visitors")]
        public int YearlyVisitors { get; set; }
    }
}
