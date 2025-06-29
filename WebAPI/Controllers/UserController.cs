using Domain_BLL.DTOs.User;
using Domain_BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("All", Name = "GetAllUsersAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ReadUserDTO>>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUserNamesAsync();
            if(users is null || !users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }


        [HttpGet("Find/{userID}", Name = "GetUserByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReadUserDTO>> GetUserByIDAsync(int userID)
        {
            if (userID <= 0)
            {
                return BadRequest("invalid ID");
            }
            var user = await _userService.FindUserByIDAsync(userID);
            if(user is null)
            {
                return NotFound($"User with ID {userID} don't exist");
            }
            return Ok(user);
        
        }


        [HttpPost("Create", Name = "CreateUserAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreateUserAsync(UserDTO newUser)
        {
            if(newUser is null)
            {
                return BadRequest("invalid data");
            }
            var insertedID = await _userService.CreateUserAsync(newUser);
            if (insertedID <= 0)
            {
                return NotFound("User Can't be Created");
            }
            return CreatedAtRoute("GetUserByIDAsync", new { UserID = insertedID }, null);
        }

        [HttpPut("Update{userID}", Name = "UpdateUserAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateUserAsync(int userID, UserDTO updatedUser)
        {
            if (updatedUser is null || userID <= 0)
            {
                return BadRequest("invalid data");
            }
            bool isUpdated = await _userService.UpdateUserAsync(userID, updatedUser);
            if (isUpdated)
            {
                return NoContent();
            }
            return NotFound($"User with ID {userID} is not found or can't be updated");
            
        }

        [HttpDelete("{userID}", Name = "DeleteUserAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteUserAsync(int userID)
        {
            if(userID <= 0)
            {
                return BadRequest("invalid userID");
            }
            try
            {
                if (await _userService.DeleteUserAsync(userID))
                {
                    return Ok(true);
                }
                return NotFound($"user with ID {userID} is not found");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"EX: {ex}");
                return Conflict($"User with ID {userID} can't be deleted because it has relations in the system");
            }
            

        }

        [HttpGet("CanCreate/{employeeID}", Name = "CanCreateUserAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> CanCreateUserAsync(int employeeID)
        {
            if(employeeID <= 0)
            {
                return BadRequest("invalid ID");
            }
            bool CanCreate = await _userService.CanCreateUserAsync(employeeID);
            if(CanCreate)
            {
                return Ok(true);
            }
            return NotFound($"Employee with ID {employeeID} is already a user");
        }


        [HttpGet("Activate/{userID}", Name = "ActivateUserAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ActivateUserAsync(int userID)
        {
            if (userID <= 0)
            {
                return BadRequest("invalid ID");
            }
            bool isActivated = await _userService.ActivateUserAsync(userID);
            if (isActivated)
            {
                return Ok(true);
            }
            return NotFound($"userID with ID {userID} not found");
        }


        [HttpGet("DeActivate/{userID}", Name = "DeActivateUserAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeActivateUserAsync(int userID)
        {
            if (userID <= 0)
            {
                return BadRequest("invalid ID");
            }
            bool isDeActivated = await _userService.DeActivateUserAsync(userID);
            if (isDeActivated)
            {
                return Ok(true);
            }
            return NotFound($"userID with ID {userID} not found");
        }
    }
}
