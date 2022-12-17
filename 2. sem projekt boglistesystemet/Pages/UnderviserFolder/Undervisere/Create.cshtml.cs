using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.UnderviserFolder.Undervisere
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Underviser underviser { get; set; } = new Underviser();  
        public IUnderviser iu { get; set; }
        public CreateModel( IUnderviser _iu)
        {
            iu = _iu;
            
        }

        public  IActionResult OnGet(int id)
        {
            underviser.UnderviserId= id;
            return Page();
        }
        public async Task<IActionResult> OnPost() 
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
           await iu.AddItemAsync(underviser);
           return  RedirectToPage("Get");
        }
    }
}
