using System.ComponentModel.DataAnnotations;

namespace USParks.Models.Attraction
{
    public class AttractionListItem
    {
        [Display(Name = "Attraction Id")]
        public int AttractionId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Park Id")]
        public int ParkId { get; set; }
        [Display(Name = "Park Name")]
        public string ParkName { get; set; }
        public byte[] Image { get; set; }
    }
}
