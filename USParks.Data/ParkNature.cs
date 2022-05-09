using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USParks.Data
{
    public class ParkNature
    {
        [Key]
        public int ParkNatureId { get; set; }
        [Required]
        [Display(Name = "Nature")]
        [ForeignKey("Nature")]
        public int NatureId { get; set; }
        public virtual Nature Nature { get; set; }
        [Required]
        [Display(Name = "Park")]
        [ForeignKey("Park")]
        public int ParkId { get; set; }
        public virtual Park Park { get; set; }
    }
}
