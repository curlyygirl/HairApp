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
        public int idUser { get; set; }
        [UIHint("TypeDropDownList")]
        public string Type { get; set; }
        [UIHint("PorosityDropDownList")]
        public string Porosity { get; set; }
        [UIHint("ThicknessDropDownList")]
        public string Thickness { get; set; }
        [UIHint("DensityDropDownList")]
        public string Density { get; set; }
        public bool Dyed { get; set; }
        [UIHint("DestroyedDropDownList")]
        public string Destroyed { get; set; }
        [UIHint("LengthDropDownList")]
        public string Length { get; set; }

    }
}