﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class IngredientModelUI
    {
       
        const string ErrorMessageText = "Podanie tego pola jest obowiązkowe";
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessageText)]
        public string Name { get; set; }
        [Required(ErrorMessage = ErrorMessageText)]
        public string Description { get; set; }
        [Required(ErrorMessage = ErrorMessageText)]
        public string Unit { get; set; }
        [Required(ErrorMessage = ErrorMessageText)]
        public decimal CostPerUnit { get; set; }
        [Required(ErrorMessage = ErrorMessageText)]
        public int Callories { get; set; }
        public string Category { get; set; }
    }
}
