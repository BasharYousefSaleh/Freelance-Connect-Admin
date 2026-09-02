using HoorAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HoorAdmin.Pages.Dashboard
{
    public class EmployeeModel : PageModel
    {
        private readonly Jobzy _context;

        public EmployeeModel(Jobzy context)
        {
            _context = context;
        }
        public List<AspNetUser> Employe { get; set; }
        public void OnGet()
            {
            // ÌáÈ ÈíÇäÇÊ ÇáãÓÊÎÏãíä ÇáÐíä íÚÊÈÑæä ãÓÊÞáíä ãä ÞÇÚÏÉ ÇáÈíÇäÇÊ
            Employe = _context.AspNetUsers
                                      .Where(u => !u.IsDeleted && u.Discriminator == "Employer")
                                      .ToList();
            }
        
    }
}
