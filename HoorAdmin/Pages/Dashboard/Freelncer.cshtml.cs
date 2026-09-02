using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HoorAdmin.Models;
using System.Collections.Generic;
using System.Linq;

namespace HoorAdmin.Pages.Dashboard
{
    public class FreelncerModel : PageModel
    {
        private readonly Jobzy _context;

        public FreelncerModel(Jobzy context)
        {
            _context = context;
        }

        public List<AspNetUser> Freelancers { get; set; }

        public void OnGet()
        {
            // ÌáÈ ÈíÇäÇÊ ÇáãÓÊÎÏãíä ÇáÐíä íÚÊÈÑæä ãÓÊÞáíä ãä ÞÇÚÏÉ ÇáÈíÇäÇÊ
            Freelancers = _context.AspNetUsers
                                  .Where(u => !u.IsDeleted && u.Discriminator == "Freelancer")
                                  .ToList();
        }
    }
}
