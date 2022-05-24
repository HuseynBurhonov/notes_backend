using MediatR;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQuery : IRequest<NoteDetailsDto>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
