using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public int Role {  get; set; }

    }
}
