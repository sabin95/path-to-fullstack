namespace BE.BL.Clients.Cars
{
    public class EditCarCommand
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationId { get; set; }        
    }
}