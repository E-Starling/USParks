using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USParks.Models.Attraction
{
    public class AttractionCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(5000, ErrorMessage = "You have hit the 5000 character limit.")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Park Id")]
        [ForeignKey("Park Id")]
        public int ParkId { get; set; }
        [Display(Name = "Upload an image .png |.jpg | 3 MB Limit")]
        public byte[] Image { get; set; }
        
    }
}
