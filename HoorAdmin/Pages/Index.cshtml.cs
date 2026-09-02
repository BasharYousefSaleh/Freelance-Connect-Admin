using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HoorAdmin.Models;

namespace HoorAdmin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Jobzy _dbContext;
        private readonly PasswordHasher<string> _passwordHasher;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [FromQuery(Name = "ReturnUrl")]
        public string ReturnUrl { get; set; }

        public IndexModel(Jobzy dbContext)
        {
            _dbContext = dbContext;
            _passwordHasher = new PasswordHasher<string>();
        }

        public IActionResult OnPost()
        {
            // «·»ÕÀ ⁄‰ «·„” Œœ„ »«·»—Ìœ «·≈·ﬂ —Ê‰Ì
            var user = _dbContext.AspNetUsers.FirstOrDefault(u => u.Email == Email);
            if (user != null)
            {
                // «· Õﬁﬁ „‰ ﬂ·„… «·„—Ê— »«” Œœ«„ PasswordHasher
                //var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user.Email, user.PasswordHash, Password);
                //if (passwordVerificationResult == PasswordVerificationResult.Success)
                //{
                    //  ⁄ÌÌ‰ «· ŒÿÌÿ «·ÃœÌœ ›Ì ViewData
                    ViewData["Layout"] = "~/Pages/Dashboard/Shared/_Layout.cshtml";

                    // ≈⁄«œ…  ÊÃÌÂ «·„” Œœ„ ≈·Ï ’›Õ… ·ÊÕ… «· Õﬂ„
                    return RedirectToPage("/Dashboard/Index");
                //}
            }

            // ›Ì Õ«·… ›‘· «· Õﬁﬁ
            ModelState.AddModelError(string.Empty, "«·»—Ìœ «·≈·ﬂ —Ê‰Ì √Ê ﬂ·„… «·„—Ê— €Ì— ’ÕÌÕ….");
            ViewData["Layout"] = "~/Pages/Shared/_Layout.cshtml";
            return Page();
        }
    }
}
