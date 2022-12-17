using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.Koordinatorer
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public Koordinator Koordinator { get; set; }
        public IKoordinator Ik { get; set; }

        public UpdateModel(IKoordinator ik)
        {

            Ik = ik;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Koordinator = await Ik.GetItemAsyncById(id);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid) 
            {
                return Page();
            }
            await Ik.UpdateItemAsync(Ik);
            return RedirectToPage("Get");
        }
    }
}
