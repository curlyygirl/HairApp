using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairApp.Models
{
    public class Wash
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Odżywka")]
        public string WashConditioner { get; set; }
        [Display(Name = "Myjadło / Szampon")]
        public string Shampoo { get; set; }
        [Display(Name = "Odżywka / Maska")]
        public string HairMask { get; set; }
    }
}