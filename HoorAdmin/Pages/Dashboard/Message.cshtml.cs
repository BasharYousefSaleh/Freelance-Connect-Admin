using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HoorAdmin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HoorAdmin.Pages.Dashboard
{
    public class MessageModel : PageModel
    {
        private readonly Jobzy _context;

        [BindProperty]
        public string Content { get; set; }

        public AspNetUser Recipient { get; set; }
        public string AdminId { get; set; }
        public IQueryable<Message> Messages { get; set; }

        public MessageModel(Jobzy context)
        {
            _context = context;
        }

        public IActionResult OnGet(string id)
        {
            // ÌáÈ ÇáãÓÊÎÏã ÇáåÏİ ÈäÇÁğ Úáì ãÚÑİå
            Recipient = _context.AspNetUsers.FirstOrDefault(u => u.Id == id);
            if (Recipient == null)
            {
                return NotFound();
            }

            // ÌáÈ ÇáÜ Admin ÇáĞí íãÊáß ÏæÑ "Administrator"
            var admin = _context.AspNetUsers.FirstOrDefault(u => u.Discriminator == "Administrator");
            if (admin == null)
            {
                return NotFound("Admin not found");
            }
            AdminId = admin.Id;

            // ÌáÈ ÌãíÚ ÇáÑÓÇÆá Èíä ÇáãÓÊÎÏã æÇáÇÏãä
            Messages = _context.Messages
                               .Where(m => (m.RecipientId == Recipient.Id && m.SenderId == AdminId) ||
                                           (m.SenderId == Recipient.Id && m.RecipientId == AdminId))
                               .OrderBy(m => m.CreatedOn);

            return Page();
        }

        public IActionResult OnPost(string id)
        {
            // ÌáÈ ÇáãÓÊÎÏã ÇáåÏİ ÈäÇÁğ Úáì ãÚÑİå
            var recipient = _context.AspNetUsers.FirstOrDefault(u => u.Id == id);
            if (recipient == null)
            {
                return NotFound();
            }

            // ÌáÈ ÇáãÓÊÎÏã ÇáĞí íãÊáß ÏæÑ "Admin"
            var admin = _context.AspNetUsers.FirstOrDefault(u => u.Discriminator == "Administrator");

            if (admin == null)
            {
                return NotFound("Admin not found");
            }

            // ÅäÔÇÁ ÇáÑÓÇáÉ ÇáÌÏíÏÉ
            var message = new Message
            {
                Id = Guid.NewGuid().ToString(), // ÊæáíÏ ãİÊÇÍ ÃÓÇÓí İÑíÏ
                Content = Content,
                RecipientId = recipient.Id,
                SenderId = admin.Id, // ÊÚííä SenderId Åáì ãÚÑİ ÇáÜ Admin
                CreatedOn = DateTime.UtcNow,
                IsRead = false,
                IsDeleted = false
            };

            // ÅÖÇİÉ ÇáÑÓÇáÉ Åáì ŞÇÚÏÉ ÇáÈíÇäÇÊ
            _context.Messages.Add(message);
            _context.SaveChanges();

            // ÅÚÇÏÉ ÇáÊæÌíå Åáì ÕİÍÉ ãÚíäÉ ÈÚÏ ÇáÅÑÓÇá
            return RedirectToPage("/Dashboard/Message", new { id = recipient.Id });
        }
    }
}
