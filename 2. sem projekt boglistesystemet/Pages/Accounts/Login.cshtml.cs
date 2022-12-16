using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace _2._sem_projekt_boglistesystemet.Pages.Shared
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login Login { get; set; }
        public void OnGet()
        {


        }

        public async Task<IActionResult> OnpostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (Login.UserName == "admin" && Login.Password == "password")
            {

             

                
                return RedirectToPage("/Crud/Underviserindex");

            }

            if (Login.UserName == "admin1" && Login.Password == "password1")
            {




                return RedirectToPage("/Crud/KoordinatorIndex");

            }

            return Page();

        }

    }
    public class Login
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
