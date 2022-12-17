using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.KoordinatorHold
{
    public class Delete_Model : PageModel
    {
        [BindProperty]
        public Hold hold  { get; set; }
        public IGenericInterface<Hold> Ih{ get; set; }
        public Delete_Model( IGenericInterface<Hold> ih)
        {
          
            Ih = ih;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            hold = await Ih.GetItemAsyncById(id);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            await Ih.DeleteItemsAsync(hold);
            return RedirectToPage("GetHold");
        }
    }
}
