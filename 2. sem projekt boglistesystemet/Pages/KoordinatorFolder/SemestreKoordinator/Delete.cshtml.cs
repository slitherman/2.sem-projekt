using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.KoordinatorFolder.SemestreKoordinator
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Semestre  Sem { get; set; }
        public IGenericInterface<Semestre> Isem { get; set; }
        public DeleteModel( IGenericInterface<Semestre> isem)
        {
           
            Isem = isem;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Sem = await Isem.GetItemAsyncById(id);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            await Isem.DeleteItemsAsync(Sem);
            return RedirectToPage("GetSen");
        }
    }
}
