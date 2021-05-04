using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScottAutoRepair.Data;
using ScottAutoRepair.Models;
using ScottAutoRepair.Utility;

namespace ScottAutoRepair.Pages.Users
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public List<ApplicationUser> ApplicationUserList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ApplicationUserList = await _db.ApplicationUser.ToListAsync();
            return Page();
        }
    }
}
