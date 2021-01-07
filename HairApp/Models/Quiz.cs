using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairApp.Models
{
    public class Quiz
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("User")]
        public int idUser { get; set; }
        public User User { get; set; }
        [UIHint("TypeDropDownList")]
        [Display(Name = "Typ")]
        public string Type { get; set; }
        [UIHint("PorosityDropDownList")]
        [Display(Name = "Porowatość")]
        public string Porosity { get; set; }
        [UIHint("ThicknessDropDownList")]
        [Display(Name = "Grubość")]
        public string Thickness { get; set; }
        [UIHint("DensityDropDownList")]
        [Display(Name = "Gęstość")]
        public string Density { get; set; }
        [Display(Name = "Farbowane")]
        public bool Dyed { get; set; }
        [UIHint("DestroyedDropDownList")]
        [Display(Name = "Zniszczone")]
        public string Destroyed { get; set; }
        [UIHint("LengthDropDownList")]
        [Display(Name = "Długość")]
        public string Length { get; set; }

    }
}