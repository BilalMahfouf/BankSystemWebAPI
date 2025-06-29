using Domain_BLL.DTOs.Client;
using Domain_BLL.DTOs.TransferHistory;
using Domain_BLL.Interfaces;
using Domain_BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferHistoryController : ControllerBase
    {
        private readonly ITransferHistoryService _transferHistoryService;
        public TransferHistoryController(ITransferHistoryService transferHistoryService)
        {
            _transferHistoryService=transferHistoryService;
        }


        [HttpGet("All", Name = "GetAllTransferHistoriesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<ReadTransferHistoryDTO>>>
            GetAllTransferHistoriesAsync()
        {
            var transferHistories = await _transferHistoryService.
                GetAllTransferHistoriesAsync();
            if (transferHistories is null || !transferHistories.Any())
            {
                return NotFound();
            }
            return Ok(transferHistories);
        }

        [HttpGet("{transferHistoryID}", Name = "GetTransferHistoryByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReadTransferHistoryDTO>> GetTransferHistoryByIDAsync
            (int transferHistoryID)
        {
            if (transferHistoryID <= 0)
            {
                return BadRequest("ID must be grater then 0");
            }
            var transferHistory = await _transferHistoryService.GetTransferHistoryByIdAsync
                (transferHistoryID);
            if (transferHistory is null)
            {
                return NotFound();
            }
            return Ok(transferHistory);
        }


    }
}
