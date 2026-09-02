using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HoorAdmin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace HoorAdmin.Pages.Dashboard
{
    public class jobsModel : PageModel
    {
        private readonly Jobzy _context;

        public jobsModel(Jobzy context)
        {
            _context = context;
        }

        public List<JobViewModel> Jobs { get; set; }

        public async Task OnGetAsync()
        {
            Jobs = await _context.Jobs
                .Where(j => !j.IsDeleted) // ⁄—÷ «·ÊŸ«∆› €Ì— «·„Õ–Ê›… ›ﬁÿ
                .Select(j => new JobViewModel
                {
                    Id = j.Id,
                    Title = j.Title,
                    Status = (JobStatus)j.Status, //  ÕÊÌ· «·Õ«·… ≈·Ï enum
                    Budget = j.Budget,
                    CreatedOn = j.CreatedOn,
                    EmployerName = j.Employer.FirstName + " " + j.Employer.LastName
                })
                .ToListAsync();
        }
    }

    // ‰„Ê–Ã ·⁄—÷ «·»Ì«‰« 
    public class JobViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public JobStatus Status { get; set; }
        public decimal Budget { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmployerName { get; set; }
    }

    // Enum ··Õ«·…
    public enum JobStatus
    {
        Open = 1,
        InContract = 2,
        Closed = 3,
    }
}
