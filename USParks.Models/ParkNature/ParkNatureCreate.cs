using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using USParks.Models.Park;

namespace USParks.Models.ParkNature
{
    public class ParkNatureCreate
    {
        [Display(Name = "Nature Id")]
        public int NatureId { get; set; }
        [Display(Name = "Park Id")]
        public int ParkId { get; set; }
        public virtual List<ParkListItem> Parks { get; set; } = new List<ParkListItem>();
    }
}
