using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetMentor.DemoEF.CodeFirst.Data.Services;
using NetMentor.DemoEF.CodeFirst.Data.UnitOfWork;
using NetMentor.DemoEF.CodeFirst.Entities.Models;

namespace NetMentor.DemoEF.CodeFirst.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersCrudController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly InsertUserOnlyService insertUserService;
        private readonly UpdateUserAndEmailService updateUserAndEmailService;

        public UsersCrudController(IUnitOfWork unitOfWork, 
                                              InsertUserOnlyService insertUserService,
                                              UpdateUserAndEmailService updateUserAndEmailService
            )
        {
            this.unitOfWork = unitOfWork;
            this.insertUserService = insertUserService;
            this.updateUserAndEmailService = updateUserAndEmailService;
        }

        [HttpGet]
        public async Task<List<User>> ReadAll()
            => await unitOfWork.UserRepository.ReadAll().ToListAsync();

        [HttpGet("userId")]
        public async Task<User?> ReadOneById(int userId)
            => await unitOfWork.UserRepository.ReadOneById(userId);

        [HttpPost("{uniqueId}")]
        public async Task<bool> Create(int uniqueId)
            => await insertUserService.Execute(uniqueId);

        [HttpPut("userId")]
        public async Task<bool> Update(int userId, string newEmail)
            => await updateUserAndEmailService.Execute(userId, newEmail);

        [HttpDelete("userId")]
        public async Task<bool> Delete(int userId)
        {
            _ = await unitOfWork.UserRepository.DeleteOneSof(userId);
            await unitOfWork.Save();
            return true;
        }            
            
    }
}
