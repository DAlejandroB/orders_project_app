using orders_project_app.Model;

namespace orders_project_app.Repository.Interface
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetClients();
        public Task<Client> GetClientById(int id);
        public void AddClient(Client client);
        public void UpdateClient(Client client);
        public void DeleteClient(int id);
    }
}
