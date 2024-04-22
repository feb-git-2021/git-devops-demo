using BookProject.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;


namespace BookProject.Models.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }

        [ValidateNever]

        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> CategoryList { get; set; }
    }
}
