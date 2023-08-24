using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persons.Entities;
using Persons.Info.Interface;
using Persons.Info.Model;
using Persons.Info.Repository;

namespace PersonDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsInfo _personsInfo;
        private readonly ILogger<PersonsController> _logger;
        private readonly IMapper _mapper;
        private readonly PersonsInfoService _userInfoService;

        public PersonsController(IPersonsInfo personInfo, ILogger<PersonsController> logger, IMapper mapper, PersonsInfoService personInfoService)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _personsInfo = personInfo ?? throw new ArgumentException(nameof(personInfo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userInfoService = personInfoService ?? throw new ArgumentNullException(nameof(personInfoService));
        }

        [HttpGet("api/users")]
        public async Task<ActionResult<IEnumerable<PersonsInfo>>> GetAllUsersAsync()
        {
            var users = await _personsInfo.GetAllUsersAsync();
            if (users == null)
            {
                _logger.LogInformation("We have no users on Db");
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<PersonsInfo>>(users));
        }

        [HttpGet("api/userById/{id}")]
        public async Task<ActionResult<PersonsInfo>> GetUserInfoByIdAsync(int id)
        {
            var user = await _personsInfo.GetUserInfoByIdAsync(id);
            if (user == null)
            {
                _logger.LogInformation($"We have no user on Db with this id: {id} ");
                return NoContent();
            }
            return Ok(_mapper.Map<PersonsEntity>(user));
        }

        [HttpPost("api/createUser")]
        public async Task<ActionResult<PersonsInfo>> CreateUserAsync([FromBody] PersonsInfo userInfo)
        {
            var newUser = _mapper.Map<PersonsEntity>(userInfo);
            await _personsInfo.CreateUser(newUser);
            await _userInfoService.SaveChangesAsync();
            return Ok(newUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var users = await _personsInfo.GetUserInfoByIdAsync(id);

            if (users == null)
            {
                _logger.LogInformation($"We have no user on Db with this id: {id} ");
                return NoContent();
            }
            _personsInfo.DeleteUserAsync(users);
            await _userInfoService.SaveChangesAsync();
            return Ok(users);
        }
    }
}