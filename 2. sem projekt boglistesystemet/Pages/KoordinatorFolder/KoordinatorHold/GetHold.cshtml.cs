using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.KoordinatorHold
{

    public class GetHoldModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
  
        public IEnumerable<Hold> HoldCollection { get; set; }

        [BindProperty]
        public Hold GetHold { get; set; }
        public IGenericInterface<Hold> Ih { get; set; }
        public GetHoldModel( IGenericInterface<Hold> ih)
        {
     
            Ih = ih;
        }

        public async Task <IActionResult> OnGet()
        {
            HoldCollection = await  Ih.GetItemsAsync();
            return Page();
        }
    }
}
