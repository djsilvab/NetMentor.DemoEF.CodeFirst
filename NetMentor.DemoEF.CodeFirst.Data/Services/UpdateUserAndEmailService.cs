using NetMentor.DemoEF.CodeFirst.Data.UnitOfWork;
using NetMentor.DemoEF.CodeFirst.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Services
{
    public class UpdateUserAndEmailService
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateUserAndEmailService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Execute(int id, string newEmail)
        {
            User? user = await unitOfWork.UserRepository.ReadOneById(id);
            if (user != null)
            {
                user.Email = newEmail;
                await unitOfWork.UserRepository.UpdateOne(user);
                await unitOfWork.Save();
            }
            return true;
        }
    }
}
