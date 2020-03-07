namespace BE.BL.Revisions.Create
{
    public class RevisionCreateCommand
    {      
        public string ProblemDetails { get; set; } 
        public int ClientId { get; set; }
        public BE.DAL.Car Car { get; set; }
    }
}