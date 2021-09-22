using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistrationandCRUD.API.Entities;
using Core.Service;
using Microsoft.AspNetCore.Authorization;

namespace UserRegistrationandCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserDB> _userManager;
        private readonly SignInManager<UserDB> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(UserManager<UserDB> userManager, SignInManager<UserDB> signInManager, IMapper mapper, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Get()
        {
            var userscore = await _userService.Get();
            if (userscore != null)
            {
                var usersview = _mapper.Map<List<Entities.UserModelView>>(userscore);
                return Ok(usersview);

            }
            return BadRequest();
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _userService.Get(id);
            var apiuser = _mapper.Map<UserModelView>(result);
            if (apiuser != null)
            {
                return Ok(apiuser);

            }
            throw new Exception("Null");
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {

            var result = await _userService.Delete(id);
            if (result == 0)
            {
                throw new Exception("Null Id");
            }
            return Ok(id);
        }


        [HttpPost("Update")]
        [Authorize]
        public async Task<ActionResult> Update(UserUpdate userupdate)
        {
            if (userupdate is null)
            {
                throw new ArgumentNullException(nameof(userupdate));
            }

            //var homeworkcore = new Core.Entites.Homework
            //{
            //    Id = homework.Id,
            //    Title = homework.Title,
            //    Description = homework.Description,
            //    Link = homework.Link

            //};

            var usercore = _mapper.Map<Core.Entities.UserCore>(userupdate);

            var result = await _userService.Update(usercore);

            return Ok(result);

        }




        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLogin user)
        {
           // var user = _mapper.Map<IdentityUser>(user);

            var usersucces = await _userManager.FindByNameAsync(user.Email);
            if (usersucces != null)
            {
                var signinresult = await _signInManager.PasswordSignInAsync(usersucces, user.Password, true, false);

                if (signinresult.Succeeded)
                {
                    return Ok();
                }

            }
            return BadRequest();
        }

        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegister user)
        {
          

            if (ModelState.IsValid)
            {
                var useridentity = _mapper.Map<UserDB>(user);

                var res = await _userManager.CreateAsync(useridentity, user.Password);

                if (res.Succeeded)
                {
                    var signinresult = await _signInManager.PasswordSignInAsync(useridentity, user.Password, true, false);
                    if (signinresult.Succeeded)
                    {
                        return Ok(user);
                    }
                }
                return BadRequest();

            }
            return Ok();
        }
    }
}