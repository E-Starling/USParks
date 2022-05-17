using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using USParks.Models.Attraction;
using USParks.Models.ParkNature;

namespace USParks.Models.Park
{
    public class ParkDetail
    {
        public enum ParkType { National, State }
        [Display(Name = "Park Id")]
        public int ParkId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Park Type")]
        public ParkType parkType { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        [Display(Name = "Size (mi²)")]
        public int Size { get; set; }
        [Display(Name = "Yearly Visitors")]
        public int YearlyVisitors { get; set; }

        public byte[] Image { get; set; }

        public virtual List<ParkNatureListItem> Nature { get; set; } = new List<ParkNatureListItem>();
        public virtual List<AttractionListItem> Attractions { get; set; } = new List<AttractionListItem>();
    }
}
