using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
