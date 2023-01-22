using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ducinside.Models;

namespace Ducinside.Data
{
    public class BoardContext : DbContext
    {
        public BoardContext (DbContextOptions<BoardContext> options)
            : base(options)
        {
        }

        public DbSet<Ducinside.Models.Board> Board { get; set; } = default!;
    }
}
