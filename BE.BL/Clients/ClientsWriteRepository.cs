using BE.BL.Clients.Cars;
using BE.BL.Clients.Revisions;
using BE.DAL;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace BE.BL.Clients
{
    public class ClientsWriteRepository : IClientsWriteRepository
    {
        private readonly WriteGetYourCarFixedDbContext _writeContext;

        public ClientsWriteRepository(WriteGetYourCarFixedDbContext writeContext)
        {
            _writeContext = writeContext;
        }
        public void Save(ClientAggregate client)
        {
            var createdCars = client.Cars.Where(x => x.Id == 0).ToArray();
            var updatedCars = client.Cars.Where(x => x.IsModified).ToArray();
            var deletedCars = client.Cars.Where(x => x.IsDeleted).ToArray();
            var createdRevisions = client.Revisions.Where(x => x.Id == 0).ToArray();
            var updatedRevisions = client.Revisions.Where(x => x.IsModified).ToArray();
            var deletedRevisions = client.Revisions.Where(x => x.IsDeleted).ToArray();

            if (client.Id == 0 && !client.IsDeleted)
            {
                Create(client);
            }
            else if (client.IsDeleted)
            {
                Delete(client);
            }
            else if (client.IsModified)
            {
                Edit(client);
            }

            Create(createdCars);
            Edit(updatedCars);
            Delete(deletedCars);

            Create(createdRevisions);
            Edit(updatedRevisions);
            Delete(deletedRevisions);

        }

        private void Create(params ClientAggregate[] clients)
        {
            if (!clients.Any())
            {
                return;
            }
            var createClientDao = new DataTable();
            createClientDao.Columns.Add("FirstName");
            createClientDao.Columns.Add("LastName");
            createClientDao.Columns.Add("PhoneNumber");
            createClientDao.Columns.Add("Email");
            createClientDao.Columns.Add("Password");
            foreach (var client in clients)
            {
                createClientDao.Rows.Add(client.FirstName, client.LastName, client.PhoneNumber, client.Email, client.Password);
            }


            var parameter = new SqlParameter("@CreateClient", SqlDbType.Structured)
            {
                Value = createClientDao,
                TypeName = "dbo.UT_CreateClient"
            };                        

            _writeContext.Database.ExecuteSqlRaw("EXEC [dbo].[usp_CreateClient] {0}", new[] { parameter });
        }

        private void Edit(params ClientAggregate[] clients)
        {
            if (!clients.Any())
            {
                return;
            }
            var createClientDao = new DataTable();
            createClientDao.Columns.Add("Id");
            createClientDao.Columns.Add("FirstName");
            createClientDao.Columns.Add("LastName");
            createClientDao.Columns.Add("PhoneNumber");
            createClientDao.Columns.Add("Email");
            createClientDao.Columns.Add("Password");
            foreach (var client in clients)
            {
                createClientDao.Rows.Add(client.Id, client.FirstName, client.LastName, client.PhoneNumber, client.Email, client.Password);
            }


            var parameter = new SqlParameter("@EditClient", SqlDbType.Structured)
            {
                Value = createClientDao,
                TypeName = "dbo.UT_EditClient"
            };
            _writeContext.Database.ExecuteSqlRaw("EXEC [dbo].[usp_EditClient] {0}", new[] { parameter });
        }

        private void Delete(params ClientAggregate[] clients)
        {
            if (!clients.Any())
            {
                return;
            }
            var clientDto = new DataTable();
            clientDto.Columns.Add("Id");
            foreach (var client in clients)
            {
                clientDto.Rows.Add(client.Id);
            }
            var parameter = new SqlParameter("@DeleteClient", SqlDbType.Structured)
            {
                Value = clientDto,
                TypeName = "dbo.UT_BIGINT"
            };
            _writeContext.Database.ExecuteSqlRaw("EXEC [dbo].[usp_DeleteClient] {0}", new[] { parameter });
        }

        private void Create(params Car[] cars)
        {
            if (!cars.Any())
            {
                return;
            }
            var carsDto = new DataTable();
            carsDto.Columns.Add("ClientId");
            carsDto.Columns.Add("BrandName");
            carsDto.Columns.Add("ModelName");
            carsDto.Columns.Add("PlateNumber");
            carsDto.Columns.Add("RegistrationId");
            foreach (var car in cars)
            {
                carsDto.Rows.Add(car.ClientId, car.BrandName, car.ModelName, car.PlateNumber, car.RegistrationId);
            }


            var parameter = new SqlParameter("@CreateCar", SqlDbType.Structured)
            {
                Value = carsDto,
                TypeName = "dbo.UT_CreateCar"
            };
            _writeContext.Database.ExecuteSqlRaw("EXEC [dbo].[usp_CreateCar] {0}", new[] { parameter });
        }

        private void Edit(params Car[] cars)
        {
            if (!cars.Any())
            {
                return;
            }
            var carsDto = new DataTable();
            carsDto.Columns.Add("Id");
            carsDto.Columns.Add("ClientId");
            carsDto.Columns.Add("BrandName");
            carsDto.Columns.Add("ModelName");
            carsDto.Columns.Add("PlateNumber");
            carsDto.Columns.Add("RegistrationId");
            foreach (var car in cars)
            {
                carsDto.Rows.Add(car.Id, car.ClientId, car.BrandName, car.ModelName, car.PlateNumber, car.RegistrationId);
            }


            var parameter = new SqlParameter("@EditCar", SqlDbType.Structured)
            {
                Value = carsDto,
                TypeName = "dbo.UT_EditCar"
            };
            _writeContext.Database.ExecuteSqlRaw("EXEC [dbo].[usp_EditCar] {0}", new[] { parameter });
        }

        private void Delete(params Car[] cars)
        {
            if (!cars.Any())
            {
                return;
            }
            var carDto = new DataTable();
            carDto.Columns.Add("Id");
            foreach (var car in cars)
            {
                carDto.Rows.Add(car.Id);
            }
            var parameter = new SqlParameter("@DeleteCar", SqlDbType.Structured)
            {
                Value = carDto,
                TypeName = "dbo.UT_BIGINT"
            };
            _writeContext.Database.ExecuteSqlRaw("EXEC [dbo].[usp_DeleteCar] {0}", new[] { parameter });
        }

        private void Create(params Revision[] revisions)
        {
            if (!revisions.Any())
            {
                return;
            }
            var revisionDto = new DataTable();
            revisionDto.Columns.Add("ClientId");
            revisionDto.Columns.Add("CarId");
            revisionDto.Columns.Add("Title");
            revisionDto.Columns.Add("ProblemDetails");
            foreach (var revision in revisions)
            {
                revisionDto.Rows.Add(revision.ClientId, revision.CarId, revision.Title, revision.ProblemDetails);
            }


            var parameter = new SqlParameter("@CreateRevision", SqlDbType.Structured)
            {
                Value = revisionDto,
                TypeName = "dbo.UT_CreateRevision"
            };
            _writeContext.Database.ExecuteSqlRaw("EXEC [dbo].[usp_CreateRevision] {0}", new[] { parameter });
        }

        private void Edit(params Revision[] revisions)
        {
            if (!revisions.Any())
            {
                return;
            }
            var revisionDto = new DataTable();
            revisionDto.Columns.Add("Id");
            revisionDto.Columns.Add("ClientId");
            revisionDto.Columns.Add("CarId");
            revisionDto.Columns.Add("Title");
            revisionDto.Columns.Add("ProblemDetails");
            foreach (var revision in revisions)
            {
                revisionDto.Rows.Add(revision.Id, revision.ClientId, revision.CarId, revision.Title, revision.ProblemDetails);
            }


            var parameter = new SqlParameter("@EditRevision", SqlDbType.Structured)
            {
                Value = revisionDto,
                TypeName = "dbo.UT_EditRevision"
            };
            _writeContext.Database.ExecuteSqlRaw("EXEC [dbo].[usp_EditRevision] {0}", new[] { parameter });
        }

        private void Delete(params Revision[] revisions)
        {
            if (!revisions.Any())
            {
                return;
            }
            var revisionDto = new DataTable();
            revisionDto.Columns.Add("Id");
            foreach (var revision in revisions)
            {
                revisionDto.Rows.Add(revision.Id);
            }
            var parameter = new SqlParameter("@DeleteRevision", SqlDbType.Structured)
            {
                Value = revisionDto,
                TypeName = "dbo.UT_BIGINT"
            };
            _writeContext.Database.ExecuteSqlRaw("EXEC [dbo].[usp_DeleteRevision] {0}", new[] { parameter });
        }
    }
}
