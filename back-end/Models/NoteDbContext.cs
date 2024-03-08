using Microsoft.EntityFrameworkCore;

namespace note_taking_app_api.Models
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options)
        {
        }
        public DbSet<Note> Notes { get; set; } = null!;
    }
}
