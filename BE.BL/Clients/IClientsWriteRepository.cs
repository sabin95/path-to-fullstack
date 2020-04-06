namespace BE.BL.Clients
{
    public interface IClientsWriteRepository
    {
        void Save(ClientAggregate client);
    }
}