using Examination.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.ViewModels
{
    public class StudentsViewModel
    {
        public StudentsViewModel(Students model)
        {
            Id = model.Id;
            Name = model.Name ?? "";
            UserName = model.UserName ?? "";
            Password = model.Password;
            Contact = model.Contact ?? "";
            CvFileName = model.CvFileName;
            PictureName = model.PictureName;
            GroupsId = model.GroupsId;
        }
        public Students ConvertViewModel(StudentsViewModel vm)
        {
            return new Students
            {
            Id = vm.Id,
            Name = vm.Name ?? "",
            UserName = vm.UserName ?? "",
            Password = vm.Password,
            Contact = vm.Contact ?? "",
            CvFileName = vm.CvFileName,
            PictureName = vm.PictureName,
            GroupsId = vm.GroupsId

        };

        }
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; } = null!;
        [Required]
        [Display(Name="User")]
        public string UserName { get; set; } = null!;
        [Required]

        public string Password { get; set; } = null!;
        [Required]
        [Display(Name = "Contact No")]
        public string Contact { get; set; } = null!;
        [Required]
        [Display(Name = "CV")]
        public string CvFileName { get; set; } = null!;
        [Required]
        [Display(Name = "Picture")]
        public string PictureName { get; set; } = null!;

        public int? GroupsId { get; set; }

        public IFormFile? PictureFile { get; set; }
        public IFormFile? Cv {  get; set; }
        public int TotalCount { get; set; }
        public List<StudentsViewModel> StudentList { get; set; } = null!;


    }
}
