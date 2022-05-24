using MediatR;
using Notes.Domain;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _context;

        public DeleteNoteCommandHandler(INotesDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteNoteCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FindAsync(new object[] { command.Id }, cancellationToken);
            
            if (entity == null || entity.UserId != command.UserId)
                throw new NoteFoundException(nameof(Note), command.Id);

            _context.Notes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
