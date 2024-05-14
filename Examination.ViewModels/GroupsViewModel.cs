using Examination.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.ViewModels
{
    public class GroupsViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = " Group Name")]

        public required string Name { get; set; } 
        [Required]
        [Display(Name = "Description")]

        public required string Description { get; set; } 
        [Required]
        [Display(Name = "User")]

        public int UserId { get; set; }
        public required List<GroupsViewModel> GroupList { get; set; }
        public int TotalCount { get; set; }
        public GroupsViewModel(Groups model)
        {
            Id = model.Id;
            Name = model.Name ?? "";
            Description = model.Description ?? "";
            UserId = model.UserId;

        }

        public Groups ConvertViewModel(GroupsViewModel vm)
        {
            return new Groups
            {
                Id = vm.Id,
                Name = vm.Name ?? "",
                Description = vm.Description ?? "",
                UserId = vm.UserId
            };

        }
    }
}
