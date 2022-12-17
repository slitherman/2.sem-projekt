using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.Boghandel
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Boghandler boghandler { get; set; }
        public IBoghandler Iboghandel { get; set; }
        public DeleteModel(IBoghandler iboghandel)
        {
     
            Iboghandel = iboghandel;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            boghandler = await Iboghandel.GetItemAsyncById(id);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            await Iboghandel.DeleteItemsAsync(boghandler);
            return RedirectToPage("GetBoghandel");

        }
    }
}
