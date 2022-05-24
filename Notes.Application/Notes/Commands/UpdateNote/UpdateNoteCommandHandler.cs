using MediatR;
using Notes.Domain;
using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _context;

        public UpdateNoteCommandHandler(INotesDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateNoteCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FirstOrDefaultAsync(x => x.Id == command.Id);
        
            if (entity == null || entity.UserId != command.UserId)
            {
                throw new NoteFoundException(nameof(Note), command.Id);
            }

            entity.Title = command.Title;
            entity.Details = command.Details;
            entity.EditDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
