using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairApp.Models
{
    public class Ingredient
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [Display(Name="Nazwa")]
        public string Name { get; set; }
        [Required]
        [UIHint("IngredientTypeDropDownList")]
        [Display(Name="Rodzaj")]
        public string Type { get; set; }

    }
}