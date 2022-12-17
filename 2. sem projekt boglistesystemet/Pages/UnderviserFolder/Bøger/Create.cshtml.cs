using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.UnderviserFolder.Bøger
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Books boo{ get; set; }
        public IGenericInterface<Books> Ib{ get; set; }

        public CreateModel(IGenericInterface<Books> ib)
        {
         Ib= ib;
        }

        public async Task<IActionResult> OnGet(Books b)
        {
            boo.BogId = b.BogId;   
            return Page();

        }
        public async Task<IActionResult> OnPost() 
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            await Ib.AddItemAsync(boo);
           return RedirectToAction("Get");
        }
    }
}
