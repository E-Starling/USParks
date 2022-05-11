using System.ComponentModel.DataAnnotations;

namespace USParks.Models.Nature
{
    public class NatureEdit
    {
        public enum KingdomType { fauna, flora, funga }
        public enum DietType { herbivore, carnivore, omnivore, other }

        [Display(Name = "Nature Id")]
        public int NatureId { get; set; }
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [MaxLength(5000, ErrorMessage = "You have hit the 5000 character limit.")]
        public string Description { get; set; }
        [Display(Name = "Kingdom (fauna, flora, or funga)")]
        public KingdomType Kingdom { get; set; }
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Class { get; set; }
        [Display(Name = "Diet (herbivore, carnivore, omnivore, other)")]
        public DietType? Diet { get; set; }
    }
}
