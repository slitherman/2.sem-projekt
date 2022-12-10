using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _2._sem_projekt_boglistesystemet.Models;
using _2._sem_projekt_boglistesystemet.Models.BookData;

namespace _2._sem_projekt_boglistesystemet.Pages.Crud
{
    public class IndexModel : PageModel
    {
        //private readonly _2._sem_projekt_boglistesystemet.Models.BookstoreDbContext _context;

        public IndexModel(/*_2._sem_projekt_boglistesystemet.Models.BookstoreDbContext context*/)
        {
            //_context = context;
        }

        //public IList<Underviser> Underviser { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_context.Undervisere != null)
            //{
            //    Underviser = await _context.Undervisere.ToListAsync();
            //}
        }
    }
}
