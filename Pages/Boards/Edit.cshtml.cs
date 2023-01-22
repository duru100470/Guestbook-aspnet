using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ducinside.Data;
using Ducinside.Models;

namespace Guestbook_aspnet.Pages.Boards
{
    public class EditModel : PageModel
    {
        private readonly Ducinside.Data.BoardContext _context;

        public EditModel(Ducinside.Data.BoardContext context)
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

            var board =  await _context.Board.FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }
            Board = board;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Board).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(Board.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BoardExists(int id)
        {
          return (_context.Board?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
