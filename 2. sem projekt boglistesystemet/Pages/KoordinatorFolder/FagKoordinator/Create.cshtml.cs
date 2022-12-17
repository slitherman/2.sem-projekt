using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.FagKoordinator
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Fag Fag { get; set; } = new Fag();
        
        public IGenericInterface<Fag> If { get; set; }
        public CreateModel(Fag  _Fag)
        {
            Fag= _Fag;
        }
        public IActionResult OnGet(int id)
        {
            Fag.FagId = id;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
        if(!ModelState.IsValid)
            {
                return Page();
            }
            await If.AddItemAsync(Fag);
            return RedirectToPage("GetFag");
        
        }
    }
}
