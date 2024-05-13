using Examination.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.ViewModels
{
    public class UsersViewModel
    {
        public UsersViewModel(Users users)
        {
            Id= users.Id;
            Name=users.Name ?? "";
            UserName = users.UserName;
            Password=users.Password;
            Role = users.Role;
        }

        public Users ConvertViewModel(UsersViewModel model)
        {
            return new Users
            {
                Id = model.Id,
                Name = model.Name ?? "",
                UserName = model.UserName,
                Password = model.Password,
                Role = model.Role,
            };

        
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;
        [Required]
        [Display(Name="UserName")]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public int Role { get; set; }
    }
}
