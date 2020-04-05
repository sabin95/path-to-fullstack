using BE.BL.Clients.Cars;
using BE.BL.Clients.Revisions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BE.BL.Clients
{
    public class ClientAggregate
    {
        public long Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsModified { get; private set; }
        public List<Car> Cars { get; private set; }
        public List<Revision> Revisions { get; private set; } 

        public ClientAggregate(long id, string firstName, string lastName, string phoneNumber, string email, string password,
                                List<Car> cars, List<Revision> revisions)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Cars = cars;
            Revisions = revisions;
        }

        public ClientAggregate(string firstName, string lastName, string phoneNumber, string email, string password)
            :this(0,firstName,lastName,phoneNumber,email,password, new List<Car>(),new List<Revision>())
        {  
        }

        public void Edit(EditClientCommand editClientCommand)
        {
            if (editClientCommand is null)
            {
                throw new ArgumentNullException();
            }
            FirstName = editClientCommand.FirstName;
            LastName = editClientCommand.LastName;
            PhoneNumber = editClientCommand.PhoneNumber;
            Email = editClientCommand.Email;
            Password = editClientCommand.Password;
            IsModified = true;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void AddCar(CreateCarCommand createCarCommand)
        {
            if (createCarCommand is null)
            {
                throw new ArgumentNullException(nameof(createCarCommand), "Input was null!");
            }
            Cars.Add(new Car(createCarCommand.ClientId,createCarCommand.BrandName,createCarCommand.ModelName,
                            createCarCommand.PlateNumber,createCarCommand.RegistrationId));
        }

        public void EditCar(EditCarCommand editCarCommand)
        {
            if (editCarCommand is null)
            {
                throw new ArgumentNullException(nameof(editCarCommand), "Input was null!");
            }
            var car = Cars.FirstOrDefault(x => x.Id == editCarCommand.Id);
            if(car is null)
            {
                throw new ArgumentException(nameof(car),"No car with this id was found!");
            }
            car.Edit(editCarCommand);
        }

        public void DeleteCar(long carId)
        {
            var car = Cars.FirstOrDefault(x => x.Id == carId);
            if (car is null)
            {
                throw new ArgumentException(nameof(car), "No car with this id was found!");
            }
            car.Delete();    
        }

        public void AddRevision(CreateRevisionCommand createRevisionCommand)
        {
            if (createRevisionCommand is null)
            {
                throw new ArgumentNullException(nameof(createRevisionCommand), "Input was null!");
            }
            Revisions.Add(new Revision(createRevisionCommand.ClientId, createRevisionCommand.CarId,
                                       createRevisionCommand.Title, createRevisionCommand.ProblemDetails));
        }

        public void EditRevision(EditRevisionCommand editRevisionCommand)
        {
            if (editRevisionCommand is null)
            {
                throw new ArgumentNullException(nameof(editRevisionCommand), "Input was null!");
            }
            var revision = Revisions.FirstOrDefault(x => x.Id == editRevisionCommand.Id);
            if (revision is null)
            {
                throw new ArgumentException(nameof(revision), "No revision with this id was found!");
            }
            revision.Edit(editRevisionCommand);
        }

        public void DeleteRevision(long id)
        {
            var revision = Revisions.FirstOrDefault(x => x.Id == id);
            if (revision is null)
            {
                throw new ArgumentException(revision.ToString(), "No revision with this id was found!");
            }
            revision.Delete();
        }

        
    }
}
