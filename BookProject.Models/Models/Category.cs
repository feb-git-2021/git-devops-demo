using System.ComponentModel.DataAnnotations;

namespace BookProject.Models.Models
{
    public class Category
    {
        
        public int Id { get; set; }
      [StringLength(20)]
      [Required]
      [Display(Name ="Category Name")]
      [RegularExpression(@"^[A-Za-z]+[\s]{1}[A-Za-z]+$", ErrorMessage ="Category name can only contain characters")]
       

        public string CategoryName { get; set; }
        [Display(Name = "Display Order")]
        [Range(1,100,ErrorMessage ="Display order range is between 1 and 100 only")]
        public int  DisplayOrder { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
