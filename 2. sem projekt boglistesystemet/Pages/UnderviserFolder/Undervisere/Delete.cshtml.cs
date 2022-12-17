using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.UnderviserFolder.Undervisere
{
    public class DeleteModel : PageModel
    {

        [BindProperty]
        public Underviser  underviser { get; set; }
        public IUnderviser iu { get; set; }
        public DeleteModel( IUnderviser iu)
        {
            
            this.iu = iu;
        }
    
        public async Task<IActionResult> OnGet(int id)
        {
            underviser = await iu.GetItemAsyncById(id);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await iu.DeleteItemsAsync(underviser);
            return RedirectToPage("Get");
        }
    }
}
