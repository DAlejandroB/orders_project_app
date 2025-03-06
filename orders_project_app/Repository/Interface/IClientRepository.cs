using orders_project_app.Model;

namespace orders_project_app.Repository.Interface
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetClients();
        public Task<Client> GetClientById(int id);
        public Task AddClient(Client client);
        public Task UpdateClient(Client client);
        public Task DeleteClient(int id);
    }
}
