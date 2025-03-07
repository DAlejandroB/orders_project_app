using orders_project_app.Model;
using orders_project_app.Model.Dto;

namespace orders_project_app.Service.Interface
{
    public interface IClientService
    {
        public Task<List<ClientDto>> GetClients();
        public Task<ClientDto> GetClientById(int id);
        public Task AddClient(ClientCreateDto order);
        public Task UpdateClient(ClientCreateDto order);
        public Task DeleteClient(int id);
    }
}
