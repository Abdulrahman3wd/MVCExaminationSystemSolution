using Examination.DAL.Entities;
using Examination.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Examination.Bll.Services
{
    public interface IStudentServices
    {
        PagedResult<StudentsViewModel> GetAll(int pageNumber, int pageSize);
        Task<StudentsViewModel> AddAsync(StudentsViewModel vm);

        IEnumerable<Students> GetAllStudents();
        public bool SetGroupIdToStudents(GroupsViewModel vm);

        bool SetExamResult(AttendExamViewModel vm);
        IEnumerable<ResultViewModel> GetResults(int studentId);
        StudentsViewModel GetStudentDetails(int studentId);
        Task<StudentsViewModel> UpdateAsync(StudentsViewModel vm);
    }

}
