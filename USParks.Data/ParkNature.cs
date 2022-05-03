using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int NatureId { get; set; }
    }
}
