using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.UnderviserFolder.Bøger
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public Books boo { get; set; }
        public IGenericInterface<Books> Ib { get; set; }

        public UpdateModel(IGenericInterface<Books> ib)
        {
            
            Ib = ib;
        }
    
        public async Task<IActionResult> OnGet(int id)
        {
            boo = await Ib.GetItemAsyncById(id);
            return Page();

        }
       /// <summary>
       /// most likely doesnt work
       /// </summary>
       /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            await Ib.UpdateItemAsync(Ib);
            return RedirectToPage("Get");
        }
    }
}
