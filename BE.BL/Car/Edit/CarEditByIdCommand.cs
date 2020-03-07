namespace BE.BL.Car.Edit
{
    public class CarEditByIdCommand
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationId { get; set; }        
    }
}