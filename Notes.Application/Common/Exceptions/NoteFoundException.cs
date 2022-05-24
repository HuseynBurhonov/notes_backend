namespace Notes.Application.Common.Exceptions
{
    public class NoteFoundException : Exception
    {
        public NoteFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) not found.") { }
    }
}
