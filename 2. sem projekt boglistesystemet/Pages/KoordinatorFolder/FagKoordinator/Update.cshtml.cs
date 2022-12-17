using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.FagKoordinatir
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public Fag Fag { get; set; }
        public IGenericInterface<Fag>  If { get; set; }
        public UpdateModel(IGenericInterface<Fag> @if)
        {
          
            If = @if;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Fag = await If.GetItemAsyncById(id);
            return Page();
        }

        public async Task<IActionResult> OnPost() 
        { 
        if(!ModelState.IsValid)
            {
                return Page();
            }
        await If.UpdateItemAsync(If);
            return RedirectToPage("GetFag");
        }
    }
}
