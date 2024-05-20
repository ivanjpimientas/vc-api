using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebCoreVCard.Domain.Dtos;
using WebCoreVCard.Domain.Entities;
using WebCoreVCard.Infrastructure.Repositories.Interfaces;

namespace WebCoreVCard.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _ctRepo;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsers()
        {
            var listUsers = _ctRepo.GetUsers();

            var listUsersDto = new List<UserDto>();

            foreach (var user in listUsers)
            {
                listUsersDto.Add(_mapper.Map<UserDto>(user));
            }

            return Ok(new { result = listUsersDto });
        }

        [HttpGet("{userId:int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUser(int userId)
        {
            var itemUser = _ctRepo.GetUser(userId);

            if (itemUser == null)
            {
                return NotFound();
            }

            var itemUserDto = _mapper.Map<UserDto>(itemUser);

            return Ok(new { result = itemUserDto });
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateUser([FromBody] UserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (createUserDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_ctRepo.ExistUser(createUserDto.Name))
            {
                ModelState.AddModelError("", "The user name exist.");
                return StatusCode(404, ModelState);
            }

            var user = _mapper.Map<User>(createUserDto);
            if (!_ctRepo.CreateUser(user))
            {
                ModelState.AddModelError("", $"Enought, Error when saving register {user.Name}.");
                return StatusCode(404, ModelState);
            }

            return CreatedAtRoute("GetUser", new { userId = user.Id }, user);
        }

        [HttpPatch("{userId:int}", Name = "UpdateUser")]
        [ProducesResponseType(201, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUser(int userId, [FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (userDto == null || userId != userDto.Id)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(userDto);

            if (!_ctRepo.UpdateUser(user))
            {
                ModelState.AddModelError("", $"Enought, Error when updating register {user.Name}.");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetUser", new { userId = user.Id }, user);
        }

        [HttpDelete("{userId:int}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUser(int userId)
        {
            if (!_ctRepo.ExistUser(userId))
            {
                return NotFound();
            }

            var user = _ctRepo.GetUser(userId);

            if (!_ctRepo.DeleteUser(user))
            {
                ModelState.AddModelError("", $"Enought, Error when deleting register {user.Name}.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
