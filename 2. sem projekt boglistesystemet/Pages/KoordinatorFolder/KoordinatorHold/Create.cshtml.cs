using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.KoordinatorHold
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Hold Hold { get; set; } = new Hold(); 
        public IGenericInterface<Hold> Ig { get; set; }
        public CreateModel(IGenericInterface<Hold> ig)
        {
       
            Ig = ig;
        }

        public IActionResult OnGet(int id)
        {
            Hold.HoldId= id;
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            await Ig.AddItemAsync(Hold);
            return RedirectToPage("GetHold");
        }
    }
}
