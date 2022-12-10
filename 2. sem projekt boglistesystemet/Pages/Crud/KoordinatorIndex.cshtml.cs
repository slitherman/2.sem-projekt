using _2._sem_projekt_boglistesystemet.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages
{
    public class Privacy1Model : PageModel
    {
        public void OnGet()
        {
        }
        private readonly ILogger<Privacy1Model> _logger;

        public Privacy1Model(ILogger<Privacy1Model> logger)
        {
            _logger = logger;
        }
    }
}
