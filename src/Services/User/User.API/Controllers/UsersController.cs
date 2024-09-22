using Bogus;
using Microsoft.AspNetCore.Mvc;
using User.API.InputModels.UserInputModels;
using User.API.ViewModels.UserViewModels;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/users")]
        public async Task<IActionResult> GetUsers()
        {
            var userViewModels = await Task.FromResult((IEnumerable<UserViewModel>)CreateFakerUsers());

            return Ok(userViewModels);
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost("/api/users")]
        public async Task<IActionResult> CreateUser(CreateUserInputModel inputModel)
        {
            int usersId = await Task.FromResult(new Faker().Random.Number(1, 5));

            return CreatedAtRoute(nameof(GetUser), new { usersId }, new { UsersId = usersId });
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="usersId"></param>
        /// <returns></returns>
        [HttpGet("/api/users/{userId:int}", Name = nameof(GetUser))]
        public async Task<IActionResult> GetUser(int userId)
        {
            var userViewModel = await Task.FromResult(CreateFakerUser(userId));

            return Ok(userViewModel);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="usersId"></param>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPut("/api/users/{userId:int}")]
        public async Task<IActionResult> UpdateUser(int userId, UpdateUserInputModel inputModel)
        {
            if (userId != inputModel.UserId)
                return BadRequest();

            await Task.Delay(1000);

            return NoContent();
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="usersId"></param>
        /// <returns></returns>
        [HttpDelete("/api/users/{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await Task.Delay(1000);

            return NoContent();
        }

        #region FakeData

        private static UserViewModel CreateFakerUser(int userId)
            => new Faker<UserViewModel>()
                .CustomInstantiator(f => new UserViewModel
                {
                    UserId = userId,
                    FirstName = f.Name.FirstName(),
                    LastName = f.Name.LastName(),
                    Email = f.Internet.Email(),
                    Password = f.Internet.Password(),
                    DateOfBirth = f.Date.Past(30, DateTime.Now.AddYears(-18)), 
                    PhoneNumber = f.Phone.PhoneNumber(),
                    Address = f.Address.FullAddress(),
                    MiddleName = f.Name.FirstName(), 
                    Gender = f.PickRandom(new[] { "Male", "Female", "Other" }), 
                    AcceptTerms = f.Random.Bool()
                });

        private static List<UserViewModel> CreateFakerUsers()
            => new Faker<UserViewModel>()
                .CustomInstantiator(f => new UserViewModel
                {
                    UserId = f.Random.Int(1, 1000),
                    FirstName = f.Name.FirstName(),
                    LastName = f.Name.LastName(),
                    Email = f.Internet.Email(),
                    Password = f.Internet.Password(),
                    DateOfBirth = f.Date.Past(30, DateTime.Now.AddYears(-18)),
                    PhoneNumber = f.Phone.PhoneNumber(),
                    Address = f.Address.FullAddress(),
                    MiddleName = f.Name.FirstName(),
                    Gender = f.PickRandom(new[] { "Male", "Female", "Other" }),
                    AcceptTerms = f.Random.Bool()
                })
                .Generate(20);

        #endregion FakeData
    }
}
