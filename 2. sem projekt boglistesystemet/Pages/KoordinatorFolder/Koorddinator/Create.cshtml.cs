using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.Koordinatorer
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Koordinator Koordinator { get; set; }
        public IKoordinator Ik { get; set; }
        public CreateModel(IKoordinator ik)
        {

            Ik = ik;
        }

        public IActionResult OnGet(int id)
        {
            Koordinator.KoordinatorId = id;
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Page();
            }
            await Ik.AddItemAsync(Koordinator);
            return RedirectToPage("GetKoordinator");
        }

    }
}

