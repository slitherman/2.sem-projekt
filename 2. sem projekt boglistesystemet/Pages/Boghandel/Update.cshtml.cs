using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.Boghandel
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public Boghandler boghandler { get; set; }
        public IBoghandler Ib { get; set; }

        public UpdateModel( IBoghandler ib)
        {
          
            Ib = ib;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            boghandler = await Ib.GetItemAsyncById(id);
            return Page();

        }
        public async Task<IActionResult> OnPost()
        {

            if(!ModelState.IsValid)
            {
                return Page();
            }
            await Ib.UpdateItemAsync(Ib);
            return RedirectToPage("GetBoghandel");
        }
    }
}
