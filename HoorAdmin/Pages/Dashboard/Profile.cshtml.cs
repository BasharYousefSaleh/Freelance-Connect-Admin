using HoorAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Linq;

namespace HoorAdmin.Pages.Dashboard 
{
    public class ProfileModel : PageModel
    {
        private readonly Jobzy _context;

        public ProfileModel(Jobzy context)
        {
            _context = context;
        }

        [BindProperty]
        public AspNetUser User { get; set; }

        public IActionResult OnGet(string id)
        {
            User = _context.AspNetUsers.FirstOrDefault(u => u.Id == id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostUpdateProfile(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userToUpdate = _context.AspNetUsers.FirstOrDefault(u => u.Id == id);
            if (userToUpdate == null)
            {
                return NotFound("«·„” Œœ„ €Ì— „ÊÃÊœ.");
            }

            //  ÕœÌÀ «·»Ì«‰« 
            userToUpdate.FirstName = User.FirstName;
            userToUpdate.LastName = User.LastName;
            userToUpdate.Email = User.Email;
            userToUpdate.PhoneNumber = User.PhoneNumber;
            userToUpdate.Location = User.Location;

            // „⁄«·Ã… —›⁄ ’Ê—… «·„·› «·‘Œ’Ì
            var file = Request.Form.Files["ProfilePicture"];
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine("wwwroot/uploads");
                var filePath = Path.Combine(uploadsFolder, file.FileName);
                Directory.CreateDirectory(uploadsFolder);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                userToUpdate.ProfileImageUrl = "/uploads/" + file.FileName;
            }

            try
            {
                _context.SaveChanges();
                return RedirectToPage(new { id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "ÕœÀ Œÿ√ √À‰«¡  ÕœÌÀ «·»Ì«‰« : " + ex.Message);
                return Page();
            }
        }
    }
}
