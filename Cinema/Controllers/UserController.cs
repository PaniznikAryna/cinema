using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Cinema.Entity;
using Cinema.Interfaces.Services;

namespace Cinema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Authorize(Roles = "Администратор")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }


        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound("Пользователь не найден");
            }

            int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (currentUserId == id || User.IsInRole("Кассир") || User.IsInRole("Администратор"))
            {
                return Ok(user);
            }

            return Forbid();
        }


        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody] UpdateUserModel model)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound("Пользователь не найден");
            }

            int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != id && !User.IsInRole("Администратор"))
            {
                return Forbid();
            }

            if (!string.IsNullOrWhiteSpace(model.Name))
                user.Name = model.Name;

            if (!string.IsNullOrWhiteSpace(model.Email))
                user.Email = model.Email;

            if (!string.IsNullOrWhiteSpace(model.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            if (model.DateOfBirth != default(DateTime))
                user.DateOfBirth = DateTime.SpecifyKind(model.DateOfBirth, DateTimeKind.Utc);

            if (!string.IsNullOrWhiteSpace(model.Role))
                user.Position = model.Role;

            _userService.Update(user);
            return Ok("Пользователь успешно обновлен");
        }


        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound("Пользователь не найден");
            }

            int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (currentUserId != id && !User.IsInRole("Администратор"))
            {
                return Forbid();
            }

            _userService.Delete(id);
            return Ok("Пользователь успешно удален");
        }
    }

    public class UpdateUserModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Role { get; set; }
    }
}
