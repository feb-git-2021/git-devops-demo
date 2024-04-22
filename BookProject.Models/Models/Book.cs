using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Models.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string BookTitle { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ValidateNever]
        
        public Category Category { get; set; }
    }
}
