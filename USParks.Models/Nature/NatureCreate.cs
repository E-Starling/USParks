using System.ComponentModel.DataAnnotations;

namespace USParks.Models.Nature
{
    public class NatureCreate
    {
        public enum KingdomType { Fauna, Flora, Funga }
        public enum DietType { Herbivore, Carnivore, Omnivore, Other }
        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(5000, ErrorMessage = "You have hit the 5000 character limit.")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Kingdom (fauna, flora, or funga)")]
        public KingdomType Kingdom { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Class { get; set; }
        [Required]
        [Display(Name = "Diet (herbivore, carnivore, omnivore, other)")]
        public DietType? Diet { get; set; }
    }
}
