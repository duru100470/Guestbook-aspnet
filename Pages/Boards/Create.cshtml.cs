using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ducinside.Data;
using Ducinside.Models;

namespace Guestbook_aspnet.Pages.Boards
{
    public class CreateModel : PageModel
    {
        private readonly Ducinside.Data.BoardContext _context;

        public CreateModel(Ducinside.Data.BoardContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Board Board { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Board == null || Board == null)
            {
                return Page();
            }

            _context.Board.Add(Board);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
