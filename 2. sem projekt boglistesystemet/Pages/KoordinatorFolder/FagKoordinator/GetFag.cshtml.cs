using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.FagKoordinator
{
    public class GetFagModel : PageModel
    {

        [BindProperty(SupportsGet =true)]
        public IEnumerable<Fag> FagCollecttion { get; set; }


        [BindProperty]
        public Fag Fag { get; set; }
        public IGenericInterface<Fag> If { get; set; }
        public GetFagModel(IGenericInterface<Fag> @if)
        {
        

            If = @if;
        }

        public async Task<IActionResult> OnGet()
        {
            FagCollecttion = await If.GetItemsAsync();
            return Page();
        }
    }
}
