using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditTime { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<Note, NoteDetailsDto>()
                .ForMember(noteDto => noteDto.Title, opt => opt.MapFrom(note => note.Title))
                .ForMember(noteDto => noteDto.Details, opt => opt.MapFrom(note => note.Details))
                .ForMember(noteDto => noteDto.Id, opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.CreationDate, opt => opt.MapFrom(note => note.CreationDate))
                .ForMember(noteDto => noteDto.EditTime, opt => opt.MapFrom(note => note.EditDate));
        }
    }
}
