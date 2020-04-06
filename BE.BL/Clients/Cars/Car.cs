using System;

namespace BE.BL.Clients.Cars
{
    public class Car
    {
        public long Id { get; private set; }
        public long ClientId { get; private set; }
        public string BrandName { get; private set; }
        public string ModelName { get; private set; }
        public string PlateNumber { get; private set; }
        public string RegistrationId { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsModified { get; private set; } 

        public Car(long id, long clientId, string brandName, string modelName, string plateNumber, string registrationId)
        {
            Id = id;
            ClientId = clientId;
            BrandName = brandName;
            ModelName = modelName;
            PlateNumber = plateNumber;
            RegistrationId = registrationId;
        }

        public Car(long clientId, string brandName, string modelName, string plateNumber, string registrationId)
            :this(0,clientId,brandName,modelName,plateNumber,registrationId)
        {
        }

        public void Edit(EditCarCommand editCarCommand)
        {
            if (editCarCommand is null)
            {
                throw new ArgumentNullException(nameof(editCarCommand), "Input was null!");
            }
            IsModified = true;
            BrandName = editCarCommand.BrandName;
            ModelName = editCarCommand.ModelName;
            PlateNumber = editCarCommand.PlateNumber;
            RegistrationId = editCarCommand.RegistrationId;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
