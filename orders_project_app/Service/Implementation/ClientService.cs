using orders_project_app.CustomException;
using orders_project_app.Model;
using orders_project_app.Model.Dto;
using orders_project_app.Repository.Interface;
using orders_project_app.Service.Interface;

namespace orders_project_app.Service.Implementation
{
    public class ClientService(IClientRepository clientRepository) : IClientService
    {
        public async Task<List<ClientDto>> GetClients()
        {
            List<Client> clients = await clientRepository.GetClients();
            List<ClientDto> clientDtos = [];
            clients.ForEach(client =>
            {
                ClientDto clientDto = new ClientDto
                {
                    Id = client.Id,
                    Name = client.Name,
                    ContactEmail = client.ContactEmail,
                    ContactPhone = client.ContactPhone,
                    Address = client.Address,
                    Orders = client.Orders.Select(order => order.Id).ToList()
                };
                clientDtos.Add(clientDto);
            });
            return clientDtos;
        }

        public async Task<ClientDto> GetClientById(int id)
        {
            Client clientEntity = await clientRepository.GetClientById(id);
            ClientDto clientDto = new ClientDto
            {
                Id = clientEntity.Id,
                Name = clientEntity.Name,
                ContactEmail = clientEntity.ContactEmail,
                ContactPhone = clientEntity.ContactPhone,
                Address = clientEntity.Address,
                Orders = clientEntity.Orders.Select(order => order.Id).ToList()
            };
            return clientDto;
        }

        public async Task AddClient(ClientCreateDto client)
        {
            Client clientEntity = new Client
            {
                Name = client.Name,
                ContactEmail = client.ContactEmail,
                ContactPhone = client.ContactPhone,
                Address = client.Address
            };
            await clientRepository.AddClient(clientEntity);
        }

        public async Task UpdateClient(ClientCreateDto client)
        {
            Client clientEntity = new Client
            {
                Name = client.Name,
                ContactEmail = client.ContactEmail,
                ContactPhone = client.ContactPhone,
                Address = client.Address
            };
            await clientRepository.UpdateClient(clientEntity);
        }

        public async Task DeleteClient(int id)
        {
            await clientRepository.DeleteClient(id);
        }
    }
}
