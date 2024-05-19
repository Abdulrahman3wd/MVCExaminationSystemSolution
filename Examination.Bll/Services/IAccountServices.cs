using Examination.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Bll.Services
{
    public interface IAccountServices
    {
        LoginViewModel Login(LoginViewModel vm);
        bool AddTeacher(LoginViewModel vm);
        PagedResult<UsersViewModel> GetAllTeachers(int pageNumber , int pageSize);

    }
}
