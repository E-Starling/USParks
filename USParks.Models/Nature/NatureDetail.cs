using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USParks.Models.Nature
{
    public class NatureDetail
    {
        public enum KingdomType { Fauna, Flora, Funga }
        public enum DietType { Herbivore, Carnivore, Omnivore, NA }
        [Display(Name = "Nature Id")]
        public int NatureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public KingdomType Kingdom { get; set; }
        public string Class { get; set; }
        public DietType? Diet { get; set; }
    }
}
