using Examination.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.ViewModels
{
    public class ExamsViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Exam Name")]
        public required string Title { get; set; }
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public int Time { get; set; }
        public int GroupsId { get; set; }
        public required List<ExamsViewModel> ExamsList { get; set; }
        public int TotalCount { get; set; }

        public ExamsViewModel(Exams model)
        {
            Id = model.Id;
            Title = model.Title ?? "";
            Description = model.Description ?? "";
            StartDate = model.StartDate;
            Time = model.Time;
            GroupsId = model.GroupsId;
        }
        public Exams ConvertVIewModel(ExamsViewModel vm)
        {
            return new Exams
            {
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                StartDate = vm.StartDate,
                Time = vm.Time,
                GroupsId = vm.GroupsId,
            };


        }
    }
}
