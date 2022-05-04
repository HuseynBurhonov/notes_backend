using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Notes.Persistence.EntityTypeConfiguration;
using Notes.Domain;

namespace Notes.Persistence
{
    internal class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}