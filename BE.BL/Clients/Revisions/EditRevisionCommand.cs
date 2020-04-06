namespace BE.BL.Clients.Revisions
{
    public class EditRevisionCommand
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string Title { get; set; }
        public string ProblemDetails { get; set; } 
        
    }
}