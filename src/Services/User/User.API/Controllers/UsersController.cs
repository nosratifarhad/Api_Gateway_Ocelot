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
        [HttpGet("/api/users/{usersId:int}", Name = nameof(GetUser))]
        public async Task<IActionResult> GetUser(int usersId)
        {
            var userViewModel = await Task.FromResult(CreateFakerUser(usersId));

            return Ok(userViewModel);
        }

        #region FakeData

        private static UserViewModel CreateFakerUser(int usersId)
            => new Faker<UserViewModel>()
                .CustomInstantiator(f => new UserViewModel
                {
                    UserId = usersId,
                    FirstName = f.Name.FirstName(),
                    LastName = f.Name.LastName(),
                    Email = f.Internet.Email(),
                    Password = f.Internet.Password(),
                    DateOfBirth = f.Date.Past(30, DateTime.Now.AddYears(-18)), // فرض بر این که کاربر حداقل 18 سال سن دارد
                    PhoneNumber = f.Phone.PhoneNumber(),
                    Address = f.Address.FullAddress(),
                    MiddleName = f.Name.FirstName(), // به عنوان مثال
                    Gender = f.PickRandom(new[] { "Male", "Female", "Other" }), // مقدار تصادفی برای جنسیت
                    AcceptTerms = f.Random.Bool()
                });

        #endregion FakeData
    }
}
