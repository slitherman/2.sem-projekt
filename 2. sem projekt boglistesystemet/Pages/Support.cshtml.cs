using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2._sem_projekt_boglistesystemet.Pages
{
    public class SupportModel : PageModel
    {
        private readonly ILogger<SupportModel> _logger;

        public SupportModel(ILogger<SupportModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
