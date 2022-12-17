using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.UnderviserFolder.Undervisere
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public Underviser underviser { get; set; }
        public IUnderviser iu { get; set; }


        public UpdateModel( IUnderviser _iu)
        {
           
            iu = iu;
        }
    
        public async Task<IActionResult> OnGet(int id)
        {
            underviser = await iu.GetItemAsyncById(id);
            return Page();
        }
        /// <summary>
        /// Not sure if this works
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid) return Page();
            underviser = await iu.UpdateItemAsync(iu);
            return RedirectToPage("Get");
        }
    }
}
