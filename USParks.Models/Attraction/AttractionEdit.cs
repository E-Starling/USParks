using System.ComponentModel.DataAnnotations;

namespace USParks.Models.Attraction
{
    public class AttractionEdit
    {
        [Display(Name = "Attraction Id")]
        public int AttractionId { get; set; }
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [MaxLength(5000, ErrorMessage = "You have hit the 5000 character limit.")]
        public string Description { get; set; }
        [Display(Name = "Park Id")]
        public int ParkId { get; set; }
        [Display(Name = "Upload an image .png |.jpg | 3 MB Limit")]
        public byte[] Image { get; set; }
    }
}
