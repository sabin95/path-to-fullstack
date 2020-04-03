namespace BE.BL.Clients
{
    public interface IClientAggregateFactory
    {
        ClientAggregate Create(CreateClientCommand createClientCommand);
        ClientAggregate Create(long clientId);
    }
}