namespace BE.BL.Cars.Create
{
    public class CreateCarCommand
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationId { get; set; }
    }
}