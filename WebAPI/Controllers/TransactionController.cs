using Domain_BLL.DTOs.Client;
using Domain_BLL.DTOs.Misc;
using Domain_BLL.DTOs.Transaction;
using Domain_BLL.Interfaces;
using Domain_BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }


        [HttpGet("All", Name = "GetAllTransactionsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<ReadTransactionDTO>>> 
            GetAllTransactionsAsync()
        {
            var Transactions = await _transactionService.GetAllTransactionsAsync();
            if (Transactions is null || !Transactions.Any())
            {
                return NotFound();
            }
            return Ok(Transactions);
        }

        [HttpGet("{transactionID}", Name = "GetTransactionByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReadTransactionDTO>> GetTransactionByIDAsync
            (int transactionID)
        {
            if (transactionID <= 0)
            {
                return BadRequest("ID must be grater then 0");
            }
            var transaction = await _transactionService.GetTransactionByIdAsync(transactionID);
            if (transaction is null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost("Deposit", Name = "DepositAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> DepositAsync(TransactionDTO newDeposit)
        {
            if (newDeposit is null)
            {
                return BadRequest();
            }
            var insertedID = await _transactionService.DepositAsync(newDeposit);
            if (insertedID <= 0) return BadRequest("deposit cannot be made");
            return CreatedAtRoute("GetTransactionByIDAsync", new { TransactionID = insertedID }
            , null);

        }

        [HttpPost("Withdraw", Name = "WithdrawAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> WithdrawAsync(TransactionDTO newWithdraw)
        {
            if (newWithdraw is null)
            {
                return BadRequest();
            }
            var insertedID = await _transactionService.WithdrawAsync(newWithdraw);
            if (insertedID <= 0) return BadRequest("withdraw cannot be made");
            return CreatedAtRoute("GetTransactionByIDAsync", new { TransactionID = insertedID }
            , null);

        }

        [HttpPost("Transfer", Name = "TransferAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> TransferAsync(TransferRequestDTO newTransfer)
        {
            if (newTransfer is null)
            {
                return BadRequest();
            }
            var insertedID = await _transactionService.TransferAsync(newTransfer);
            if (insertedID <= 0) return BadRequest("withdraw cannot be made");
            return CreatedAtRoute("GetTransactionByIDAsync", new { TransactionID = insertedID }
            , null);

        }

        [HttpDelete("{transactionID}", Name = "DeleteTransactionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteTransactionAsync(int transactionID)
        {
            if (transactionID <= 0)
            {
                return BadRequest("invalid ID");
            }
            try
            {
                bool isDeleted = await _transactionService.DeleteTransactionAsync
                    (transactionID);
                if (isDeleted)
                {
                    return Ok(true);
                }
                return NotFound("transaction is not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EX: {ex}");
                return Conflict("transaction cannot be deleted because it is referenced by " +
                    "other data.");
            }

        }

    }

}
