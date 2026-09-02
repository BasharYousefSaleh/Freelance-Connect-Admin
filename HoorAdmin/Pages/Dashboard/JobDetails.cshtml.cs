using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HoorAdmin.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HoorAdmin.Pages.Dashboard
{
    public class JobDetailsModel : PageModel
    {
        private readonly Jobzy _context;

        public JobDetailsModel(Jobzy context)
        {
            _context = context;
        }

        public Job Job { get; set; }
        public AspNetUser Freelancer { get; set; } // · ⁄—Ì› «·„” ﬁ·

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            // Ã·» »Ì«‰«  «·ÊŸÌ›… „⁄ «·»Ì«‰«  «·„— »ÿ…
            Job = await _context.Jobs
                .Include(j => j.Category)
                .Include(j => j.Employer)
                .Include(j => j.Contracts) // Ã·» «·⁄ﬁÊœ «·„— »ÿ…
                    .ThenInclude(c => c.Freelancer) // Ã·» «·„” ﬁ·
                .FirstOrDefaultAsync(j => j.Id == id);

            if (Job == null)
            {
                return NotFound();
            }

            // ≈–« ﬂ«‰ Â‰«ﬂ ⁄ﬁœ „— »ÿ »«·ÊŸÌ›…° Ã·» «·„” ﬁ·
            if (Job.Contracts != null && Job.Contracts.Count > 0)
            {
                var contract = Job.Contracts.FirstOrDefault();
                if (contract != null)
                {
                    Freelancer = contract.Freelancer;
                }
            }

            return Page();
        }
    }
}
