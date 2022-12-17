using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.UnderviserFolder.Bøger
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Books boo { get; set; }
        public IGenericInterface<Books> Ib { get; set; }

        public DeleteModel  ( IGenericInterface<Books> ib)
        {
           
            Ib = ib;
        }

        public IActionResult OnGet(Books b)
        {
            boo.BogId= b.BogId;
            return RedirectToPage("Get");
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await Ib.DeleteItemsAsync(boo);
            return RedirectToPage("Get");
        }
    }
}
