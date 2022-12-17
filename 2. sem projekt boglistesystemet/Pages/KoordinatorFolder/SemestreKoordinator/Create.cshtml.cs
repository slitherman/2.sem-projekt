using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.SemestreKoordinator
{
    public class CreateModel : PageModel
    {
        public Semestre Sem { get; set; } = new Semestre();
        public IGenericInterface<Semestre> Isem { get; set; }

        public CreateModel( IGenericInterface<Semestre> myProperty)
        {

            Isem = myProperty;
        }

        public IActionResult OnGet(int id)
        {
            Sem.SemesterId = id;
            return Page();
        }

        public async Task<IActionResult> OnPost() 
        { 
        if(!ModelState.IsValid)
            {
                return Page();
            }
            await Isem.AddItemAsync(Sem);
            return RedirectToPage("GetSen");
        }
    }
}
