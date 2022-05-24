using Notes.Application.Interfaces;
using Notes.Domain;
using MediatR;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _context;

        public CreateNoteCommandHandler(INotesDbContext context) => _context = context; 

        public async Task<Guid> Handle(CreateNoteCommand command, CancellationToken cancellationToken)
        {
            var note = new Note()
            {
                Id = Guid.NewGuid(),
                UserId = command.UserId,
                Title = command.Title,
                Details = command.Details,
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _context.Notes.AddAsync(note, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
