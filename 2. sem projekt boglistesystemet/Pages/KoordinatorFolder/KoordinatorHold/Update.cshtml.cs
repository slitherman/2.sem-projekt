using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.KoordinatorHold
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public Hold Hold { get; set; }

        public IGenericInterface<Hold> Ih { get; set; }
        public UpdateModel (IGenericInterface<Hold> ih)
        {
            
            Ih = ih;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Hold = await Ih.GetItemAsyncById(id);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid) 
            {
                return Page();
            }
            await Ih.UpdateItemAsync(Ih);
            return RedirectToPage("GetHold");
        }
    }
}
