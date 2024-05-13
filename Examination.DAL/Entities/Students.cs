namespace Examination.DAL.Entities
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string CvFileName { get; set; } = null!;
        public string PictureName { get; set; } = null!;
        public int? GroupsId { get; set; }
        public Groups Groups { get; set; }
        public ICollection<ExamResults> ExamResults { get; set; } = new HashSet<ExamResults>();










    }
}