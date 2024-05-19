using Examination.DAL.UnitOfWork;
using Examination.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Bll.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountServices()
        {
            
        }
        public bool AddTeacher(LoginViewModel vm)
        {
            throw new NotImplementedException();
        }

        public PagedResult<UsersViewModel> GetAllTeachers(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public LoginViewModel Login(LoginViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
