using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.Koordinatorer
{
    public class GetKoordinatorModel : PageModel
    {
        [BindProperty(SupportsGet = true)] 
        public IEnumerable<Koordinator> Koordikators { get; set; }
        public Koordinator Koordinator { get; set; }
        public IKoordinator Ik { get; set; }

        public GetKoordinatorModel(IKoordinator _Ik)
        {
            Ik= _Ik;
        }
        
        public async Task<IActionResult>  OnGet()
        {
            Koordikators = await Ik.GetItemsAsync();
            return Page();
        }
    }
}
