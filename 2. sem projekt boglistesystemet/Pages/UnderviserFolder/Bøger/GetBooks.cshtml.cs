using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.UnderviserFolder.Bøger
{
    public class GetBooksModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
      
        public IEnumerable<Books> BookCollection { get; set; }

        [BindProperty]
        public Books books { get; set; }
        public IGenericInterface<Books> Ib { get; set; }
        public GetBooksModel( IGenericInterface<Books> ib)
        {
            
            Ib = ib;
        }

        public async Task<IActionResult> OnGet()
        {
            BookCollection = await Ib.GetItemsAsync();
            return Page();
        }
    }
}
