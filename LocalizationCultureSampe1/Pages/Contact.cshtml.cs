using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LocalizationCultureSampe1.Pages
{
    [BindProperties]
    public class ContactModel : PageModel
    {
        [Display(Name = "Message"), Required(ErrorMessage = "Message Required")]
        public string Message { get; set; }
        [Display(Name = "First Name"), Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name"), Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }
        [Display(Name = "Email"), Required(ErrorMessage = "Email Required"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public void OnGet()
        {
        }
    }
}
