using HoorAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace HoorAdmin.Pages.Dashboard
{
    public class projectModel : PageModel
    {
        private readonly Jobzy _context;

        public projectModel(Jobzy context)
        {
            _context = context;
        }

        // ﬁ«∆„… ·Õ›Ÿ »Ì«‰«  «·⁄—Ê÷
        public List<Offer> OffersList { get; set; }

        public void OnGet()
        {
            // Ã·» Ã„Ì⁄ «·⁄—Ê÷ „‰ ÃœÊ· «·⁄—Ê÷
            OffersList = _context.Offers.ToList();
        }
    }
}
