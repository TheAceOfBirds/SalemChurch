using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlankMVC.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Select Type")]
        public int? Type { get; set; }

        public IList<SelectListItem> AvailableTypes { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday
        {
            get
            {
                return this.birthday.HasValue
                   ? this.birthday.Value
                   : DateTime.Now;
            }

            set { this.birthday = value; }
        }
        
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage= "Please enter a valid email.")]
        [Required(ErrorMessage = "Please enter a valid email.")]
        [StringLength(50)]
        [Display(Name = "Owner Email")]
        public string OwnerEmail { get; set; }
        public bool Fixed { get; set; }

        private DateTime? birthday = null;
        public Pet()
        {
            AvailableTypes = new List<SelectListItem>();
        }
    }
}
