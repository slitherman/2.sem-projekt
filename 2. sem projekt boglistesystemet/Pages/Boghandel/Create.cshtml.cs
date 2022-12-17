using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.Boghandel
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Boghandler Boghandler { get; set; } = new Boghandler();
        public IBoghandler Iboghandel { get; set; }

        public CreateModel  (IBoghandler iboghandel)
        {
     
            Iboghandel = iboghandel;
        }

        public IActionResult OnGet(int id)
        {
            Boghandler.BoghandlerId = id;
            return Page();
        }

        public async Task<IActionResult> OnPost() 
        {
        if(!ModelState.IsValid)
            {
                return Page();
            }
            await Iboghandel.AddItemAsync(Boghandler);
            return RedirectToPage("GetBoghandel");
        
        }
    }
}
