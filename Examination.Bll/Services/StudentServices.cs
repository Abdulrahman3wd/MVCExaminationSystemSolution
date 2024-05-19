using Examination.DAL.Entities;
using Examination.DAL.UnitOfWork;
using Examination.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Bll.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        ILogger<StudentServices> _logger;

        public StudentServices(IUnitOfWork unitOfWork, ILogger<StudentServices> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<StudentsViewModel> AddAsync(StudentsViewModel vm)
        {
            try
            {
                Students obj = vm.ConvertViewModel(vm);
                await _unitOfWork.GenericRepository<Students>().AddAsync(obj);

            }
            catch (Exception ex)
            {
                return null!;
            }
            return vm;

            
        }

        public PagedResult<StudentsViewModel> GetAll(int pageNumber, int pageSize)
        {
            var model = new StudentsViewModel();
            try
            {
                int ExcludeRecords = (pageSize * pageSize) - pageSize;
                List<StudentsViewModel> detailList = new List<StudentsViewModel>();
                var modelList = _unitOfWork.GenericRepository<Students>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                var totalCount = _unitOfWork.GenericRepository<Students>().GetAll().ToList();
                detailList = GrouplistInfo(modelList);
                if(detailList is not null)
                {
                    model.StudentList = detailList;
                    model.TotalCount = totalCount.Count();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            var result = new PagedResult<StudentsViewModel>
            {
                Data = model.StudentList,
                TotalItems = model.TotalCount,
                PageIndex = pageNumber,
                PageSize = pageSize,
            };
            return result;
        }

        private List<StudentsViewModel> GrouplistInfo(List<Students> modelList)
        {
            return modelList.Select( o => new StudentsViewModel(o)).ToList();

        }

        public IEnumerable<Students> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResultViewModel> GetExamResults(int studentId)
        {
            try
            {
                var examResult = _unitOfWork.GenericRepository<ExamResults>().GetAll().
                    Where(a => a.StudentsId == studentId);
                var students = _unitOfWork.GenericRepository<Students>().GetAll();
                var exams = _unitOfWork.GenericRepository<ExamResults>().GetAll();
                var qnas = _unitOfWork.GenericRepository<QnAs>().GetAll();

                var requiredData = examResult.Join(students, er => er.StudentsId, s => s.Id,
                    (er, st) => new { er, st }).Join(exams, erj => erj.er.ExamsId, ex => ex.Id,
                    (erj, ex) => new { erj, ex }).Join(qnas, exj => exj.erj.er.QnAsId, q => q.Id,
                    (exj, q) => new ResultViewModel
                    {
                        
                    });
                return requiredData;
            }
            catch (Exception ex)
            {
                 _logger.LogError(ex.Message);
            }
            return Enumerable.Empty<ResultViewModel>();
        }

        public StudentsViewModel GetStudentDetails(int studentId)
        {
            try
            {
                var student = _unitOfWork.GenericRepository<Students>().GetById(studentId);
                return student is not null ? new StudentsViewModel(student) : null!;

            }
            catch(Exception ex)
            {
                _logger?.LogError(ex.Message);

            }
            return null!;



        }

        public bool SetExamResult(AttendExamViewModel vm)
        {
           
        }

        public bool SetGroupIdToStudents(GroupsViewModel vm)
        {
            throw new NotImplementedException();
        }

        public Task<StudentsViewModel> UpdateAsync(StudentsViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
