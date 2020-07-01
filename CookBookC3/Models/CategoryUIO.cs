﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class CategoryUIO
    {
            const string ErrorMessageText = "Podanie tego pola jest obowiązkowe";
            public int Id { get; set; }
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = ErrorMessageText)]
            public string Name { get; set; }
        [Display(Name = "Opis")]
        [Required(ErrorMessage = ErrorMessageText)]
            public string Description { get; set; }    
    }
}
