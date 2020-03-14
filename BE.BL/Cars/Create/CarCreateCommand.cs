namespace BE.BL.Cars.Create
{
    public class CarCreateCommand
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public string RegistrationId { get; set; }
    }
}