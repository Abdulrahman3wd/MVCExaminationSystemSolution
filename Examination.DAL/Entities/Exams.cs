namespace Examination.DAL.Entities
{
    public class Exams
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public int Time {  get; set; }
        public int GroupsId { get; set; }
        public required Groups Groups { get; set; }

        public required ICollection<ExamResults> ExamResults { get; set; } = new HashSet<ExamResults>();

        public required ICollection<QnAs> QnAs { get; set; } = new HashSet<QnAs>();






    }
}