using CanvasSync.Models;
using Microsoft.EntityFrameworkCore;

namespace CanvasSync.Data {
    public class BoardContext : DbContext {
        public BoardContext(DbContextOptions<BoardContext> options) : base(options) {

        }

        public DbSet<Board> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Board>().ToTable("Board");
        }
    }
}
