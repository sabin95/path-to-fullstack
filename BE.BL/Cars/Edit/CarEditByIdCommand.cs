namespace BE.BL.Cars.Edit
{
    public class CarEditByIdCommand
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationId { get; set; }        
    }
}