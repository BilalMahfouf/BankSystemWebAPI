using Domain_BLL.DTOs.JobTitle;
using Domain_BLL.DTOs.TransactionType;
using Domain_BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypeController : ControllerBase
    {
        private readonly TransactionTypeService _transactionTypeService;
        public TransactionTypeController(TransactionTypeService transactionTypeService)
        {
            _transactionTypeService = transactionTypeService;
        }

        [HttpGet("All", Name = "GetAllTransactionTypesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ReadTransactionTypeDTO>>>
            GetAllTransactionTypesAsync()
        {
            var transactionTypes = await _transactionTypeService.GetAllTransactionTypesAsync();
            if (transactionTypes is null || !transactionTypes.Any())
            {
                return NotFound();
            }
            return Ok(transactionTypes); 
        }
    }
}
