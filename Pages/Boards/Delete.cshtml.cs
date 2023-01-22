using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ducinside.Data;
using Ducinside.Models;

namespace Guestbook_aspnet.Pages.Boards
{
    public class DeleteModel : PageModel
    {
        private readonly Ducinside.Data.BoardContext _context;

        public DeleteModel(Ducinside.Data.BoardContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Board Board { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Board == null)
            {
                return NotFound();
            }

            var board = await _context.Board.FirstOrDefaultAsync(m => m.Id == id);

            if (board == null)
            {
                return NotFound();
            }
            else 
            {
                Board = board;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Board == null)
            {
                return NotFound();
            }
            var board = await _context.Board.FindAsync(id);

            if (board != null)
            {
                Board = board;
                _context.Board.Remove(Board);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
