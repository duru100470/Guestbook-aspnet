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
    public class IndexModel : PageModel
    {
        private readonly Ducinside.Data.BoardContext _context;

        public IndexModel(Ducinside.Data.BoardContext context)
        {
            _context = context;
        }

        public IList<Board> Board { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Board != null)
            {
                Board = await _context.Board.ToListAsync();
            }
        }
    }
}
