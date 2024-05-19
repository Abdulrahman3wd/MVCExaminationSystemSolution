using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.ViewModels
{
    public class AttendExamViewModel
    {
        public int StudentId { get; set; }
        public string ExamName { get; set; } = null!;
        public required List<QnAsViewModel> QnAs { get; set; }
        public string Message { get; set; } = null!;


    }
}
