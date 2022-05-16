using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USParks.Data
{
    public class Attraction
    {
        [Key]
        [Display(Name = "Attraction Id")]
        public int AttractionId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Park")]
        [ForeignKey("Park")]
        public int ParkId { get; set; }
        public virtual Park Park { get; set; }
    }
}
