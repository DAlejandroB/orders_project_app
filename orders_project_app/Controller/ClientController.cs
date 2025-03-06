using Microsoft.AspNetCore.Mvc;
using orders_project_app.Model.Dto;
using orders_project_app.Service.Interface;

namespace orders_project_app.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        [HttpGet]
        public async Task<List<ClientDto>> GetClients()
        {
            return await clientService.GetClients();
        }

        [HttpGet("{id}")]
        public async Task<ClientDto> GetClientById(int id)
        {
            return await clientService.GetClientById(id);
        }

        [HttpPost]
        public async Task AddClient(ClientCreateDto client)
        {
            await clientService.AddClient(client);
        }

        [HttpPut]
        public async Task UpdateClient(ClientCreateDto client)
        {
            await clientService.UpdateClient(client);
        }

        [HttpDelete("{id}")]
        public async Task DeleteClient(int id)
        {
            await clientService.DeleteClient(id);
        }
    }
}
