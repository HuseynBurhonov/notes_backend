using MediatR;
using AutoMapper;
using Notes.Domain;
using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsDto>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;
        public GetNoteDetailsQueryHandler(INotesDbContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);

        public async Task<NoteDetailsDto> Handle(GetNoteDetailsQuery query, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FirstOrDefaultAsync(note => note.Id == query.Id, cancellationToken);
            
            if (entity == null || entity.UserId == query.UserId)
                throw new NoteFoundException(nameof(Note), query.Id);

            return _mapper.Map<NoteDetailsDto>(entity);
        }
    }
}
