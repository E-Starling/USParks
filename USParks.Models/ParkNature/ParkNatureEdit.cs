using System.ComponentModel.DataAnnotations;

namespace USParks.Models.ParkNature
{
    public class ParkNatureEdit
    {
        [Display(Name = "ParkNature Id")]
        public int ParkNatureId { get; set; }
        [Display(Name = "Nature Id")]
        public int NatureId { get; set; }
        [Display(Name = "Park Id")]
        public int ParkId { get; set; }
    }
}
