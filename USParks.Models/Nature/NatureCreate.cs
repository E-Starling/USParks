using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USParks.Models.Nature
{
    public class NatureCreate
    {
        public enum KingdomType { Fauna, Flora, Funga }
        public enum DietType { Herbivore, Carnivore, Omnivore, NA }
        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(5000, ErrorMessage = "You have hit the 5000 character limit.")]
        public string Description { get; set; }
        [Required]
        public KingdomType Kingdom { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Class { get; set; }
        [Required]
        public DietType? Diet { get; set; }
    }
}
