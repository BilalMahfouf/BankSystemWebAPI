using Domain_BLL.DTOs.Client;
using Domain_BLL.Interfaces;
using Infrastructure_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("All",Name ="GetAllClientsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<ReadClientDTO>>> GetAllClientsAsync()
        {
            var clients = await _clientService.GetAllClientsAsync();
            if(clients is null || !clients.Any())
            {
                return NotFound();
            }
            return Ok(clients);
        }

        [HttpGet("{clientID}", Name = "GetClientByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReadClientDTO>> GetClientByIDAsync(int clientID)
        {
            if (clientID <= 0) 
            {
                return BadRequest("ID must be grater then 0");
            }
            var client=await _clientService.FindClientByIDAsync(clientID);
            if(client is null )
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost("Create", Name = "CreateClientAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreateClientAsync(ClientDTO newClient)
        {
            if(newClient is null)
            {
                return BadRequest();
            }
            var insertedID = await _clientService.CreateClientAsync(newClient);
            if (insertedID <= 0) return BadRequest("client cannot be created");
            return CreatedAtRoute("GetClientByIDAsync", new { ClientID= insertedID }, null);

        }

        [HttpPut("Update/{clientID}", Name = "UpdateClientAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateClientAsync(int clientID, ClientDTO client)
        {
            if (client is null || clientID <= 0) 
            {
                return BadRequest("Invalid client or clientID data");
            }
            bool isUpdated = await _clientService.UpdateClientAsync(clientID, client);
            if(isUpdated)
            {
                return Ok(true);
            }
            return NotFound("Client with the specified ID was not found.");
        }

        [HttpPut("Activate/{clientID}", Name = "ActivateClientAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ActivateClientAsync(int clientID)
        {
            if ( clientID <= 0)
            {
                return BadRequest("Invalid clientID ");
            }
            bool isActivated = await _clientService.ActivateClientAsync(clientID);
            if (isActivated)
            {
                return Ok(true);
            }
            return NotFound("Client with the specified ID was not found.");
        }

        [HttpPut("DeActivate/{clientID}", Name = "DeActivateClientAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeActivateClientAsync(int clientID)
        {
            if (clientID <= 0)
            {
                return BadRequest("Invalid clientID ");
            }
            bool isDeActivate = await _clientService.DeActivateClientAsync(clientID);
            if (isDeActivate)
            {
                return Ok(true);
            }
            return NotFound("Client with the specified ID was not found.");
        }

        [HttpDelete("{clientID}", Name = "DeleteClientAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteClientAsync(int clientID)
        {
            if(clientID <= 0)
            {
                return BadRequest("invalid ID");
            }
            try
            {
                bool isDeleted = await _clientService.DeleteClientAsync(clientID);
                if (isDeleted)
                {
                    return Ok(true);
                }
                return NotFound("client is not found");
            }
            catch (Exception ex)
            {
                return Conflict("Client cannot be deleted because it is referenced by " +
                    "other data.");
            }
            
        }

        [HttpGet("{clientID}/{amount}", Name = "CanWithdrawAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> CanWithdrawAsync(int clientID,decimal amount)
        {
            if (clientID <= 0 || amount <= 0) 
            {
                return BadRequest("invalid data");
            }
            if(await _clientService.CanWithdrawAsync(clientID, amount))
            {
                return Ok(true);
            }
            return NotFound("client is not found or can't withdraw");
        }
    
    
    
    }
}
