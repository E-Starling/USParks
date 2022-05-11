﻿using System.ComponentModel.DataAnnotations;

namespace USParks.Models.ParkNature
{
    public class ParkNatureDetail
    {
        public int ParkNatureId { get; set; }
        [Display(Name = "Nature Id")]
        public int NatureId { get; set; }
        [Display(Name = "Nature Name")]
        public string NatureName { get; set; }
        [Display(Name = "Park Id")]
        public int ParkId { get; set; }
        [Display(Name = "Park Name")]
        public string ParkName { get; set; }
    }
}
