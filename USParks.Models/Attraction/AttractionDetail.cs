using System.ComponentModel.DataAnnotations;

namespace USParks.Models.Attraction
{
    public class AttractionDetail
    {

        [Display(Name = "Attraction Id")]
        public int AttractionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Park Id")]
        public int ParkId { get; set; }
        [Display(Name = "Park Name")]
        public string ParkName { get; set; }
    }
}
