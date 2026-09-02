using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HoorAdmin.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
public class ContrModel : PageModel
{
    private readonly Jobzy _context;

    public ContrModel(Jobzy context)
    {
        _context = context;
    }

    public IList<Contract> CompletedContracts { get; set; }
    public IList<Contract> OngoingContracts { get; set; }
    public IList<Contract> CanceledContracts { get; set; }

    public async Task OnGetAsync()
    {
        // ÇáÚÞæÏ ÇáãßÊãáÉ
        CompletedContracts = await _context.Contracts
            .Include(c => c.Freelancer)  // ÌáÈ ÈíÇäÇÊ ÇáãÓÊÞá
            .Include(c => c.Employer)     // ÌáÈ ÈíÇäÇÊ ÕÇÍÈ ÇáÚãá
            .Where(c => c.Status == 2 && !c.IsDeleted)
            .ToListAsync();

        // ÇáÚÞæÏ ÇáÌÇÑíÉ
        OngoingContracts = await _context.Contracts
            .Include(c => c.Freelancer)
            .Include(c => c.Employer)
            .Where(c => c.Status == 1 && !c.IsDeleted)
            .ToListAsync();

        // ÇáÚÞæÏ ÇáãáÛÇÉ
        CanceledContracts = await _context.Contracts
            .Include(c => c.Freelancer)
            .Include(c => c.Employer)
            .Where(c => c.Status == 3 && c.IsDeleted)
            .ToListAsync();
    }
}
