using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models.BookData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages.UnderviserFolder.Undervisere
{
    public class GetModel : PageModel
    {
        [BindProperty(SupportsGet = true)]

        public Underviser  underviser { get; set; }
        public int Amount { get; set; }
        public IEnumerable<Underviser> undervisers { get; set; }

        [BindProperty]
        public IUnderviser iu { get; set; }
        public GetModel(IUnderviser iu)
        {

            this.iu = iu;
        }
        /// <summary>
        /// mangler en metode kan visse underviseren alle deres bøger ligesom
        /// public async Task<Customer> GetSalesByCustomerAsync(int id)
        //{      
          //  Customer Customer = await saleService.Customers
            //    .Include(s => s.Sales)  
              //   .AsNoTracking()
                //.FirstOrDefaultAsync(m => m.CustomerId == id);
            
            //if (Customer == null)
            //{
              //  return null;
            //}
            //
        /// <returns></returns>
        public async Task<IActionResult> OnGet()
        {
            undervisers = await iu.GetItemsAsync();
            return Page();

        }
    }
}
