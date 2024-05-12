namespace Examination.DAL.Entities
{
    public class ExamResults
    {

        public int Id { get; set; }
        public int StudentsId { get; set; }
        public required Students Students { get; set; }
        public int? ExamsId { get; set; }
        public int QnAsId { get;}
        public QnAs QnAs { get; set; }

    }
}