using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USParks.Data
{
    public class Nature
    {
        public enum KingdomType { Fauna, Flora, Funga }
        public enum DietType { Herbivore, Carnivore, Omnivore, NA}
        [Key]
        public int NatureId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public KingdomType Kingdom { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public DietType? Diet { get; set; }
    }
}
