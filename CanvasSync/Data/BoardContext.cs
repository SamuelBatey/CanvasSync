using CanvasSync.Models;
using Microsoft.EntityFrameworkCore;

namespace CanvasSync.Data {
    public class BoardContext : DbContext {
        public BoardContext(DbContextOptions<BoardContext> options) : base(options) {

        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Stroke> Strokes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Board>().ToTable("Board");
            modelBuilder.Entity<Line>().ToTable("Line");
            modelBuilder.Entity<Stroke>().ToTable("Stroke");
        }
    }
}
