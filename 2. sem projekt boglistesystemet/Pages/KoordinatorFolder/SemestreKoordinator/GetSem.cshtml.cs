using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.SemestreKoordinator
{
    public class GetSemModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public IEnumerable<Semestre> SemCollection { get; set; }

        [BindProperty]
        public Semestre Sem { get; set; }
        public IGenericInterface<Semestre>  Isem { get; set; }

        public GetSemModel( IGenericInterface<Semestre> isem)
        {
          
            Isem = isem;
        }

        public async Task<IActionResult> OnGet()
        {
            SemCollection = await Isem.GetItemsAsync();
            return Page();
        }
    }
}
