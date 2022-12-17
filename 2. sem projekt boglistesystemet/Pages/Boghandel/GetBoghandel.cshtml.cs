using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.Boghandel
{
    public class GetBoghandelModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public IEnumerable<Boghandler> Boghandlers { get; set; }

        [BindProperty]
        public Boghandler Boghandel { get; set; }
        public IBoghandler Ib { get; set; }

        public GetBoghandelModel(IBoghandler _Ib)
        {
            Ib= _Ib;
        }

        public async Task<IActionResult> OnGet()
        {
            Boghandlers = await Ib.GetItemsAsync();
            return Page();
        }
    }
}
