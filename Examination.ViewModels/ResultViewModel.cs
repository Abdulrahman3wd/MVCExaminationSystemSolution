using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.ViewModels
{
    public class ResultViewModel
    {
        public int StudentId { get; set; }
        public string ExamName { get; set; } = string.Empty;
        public int TotalQustion { get; set; }
        public int CorrectAnswer { get; set; }
        public int WrongAnswer { get; set; }
    }
}
