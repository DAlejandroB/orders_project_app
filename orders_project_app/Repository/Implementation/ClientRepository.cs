using Microsoft.EntityFrameworkCore;
using orders_project_app.CustomException;
using orders_project_app.Data;
using orders_project_app.Model;
using orders_project_app.Repository.Interface;

namespace orders_project_app.Repository.Implementation
{
    public class ClientRepository(OrdersAppDb appDb) : IClientRepository
    {
        public async Task AddClient(Client client)
        {
            await appDb.Clients.AddAsync(client);
            await appDb.SaveChangesAsync();
        }

        public async Task DeleteClient(int id)
        {
            Client? client = await appDb.Clients.FindAsync(id) ?? throw new EntityNotFoundException("Client not found");
            appDb.Clients.Remove(client);
            await appDb.SaveChangesAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            Client? client = await appDb.Clients.FindAsync(id);
            if (client == null)
            {
                throw new EntityNotFoundException("Client not found");
            }
            return client;
        }

        public async Task<List<Client>> GetClients()
        {
            return await appDb.Clients.ToListAsync();
        }

        public async Task UpdateClient(Client client)
        {
            Client? existingClient = await appDb.Clients.FindAsync(client.Id);
            if (existingClient == null)
            {
                throw new EntityNotFoundException("Client not found");
            }
            appDb.Entry(existingClient).CurrentValues.SetValues(client);
            await appDb.SaveChangesAsync();
        }
    }
}
