namespace Examination.DAL.Entities
{
    public class Groups
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int UserId { get; set; }

        public Users Users { get; set; } = null!;

        public ICollection<Students> Students { get; set; } = new HashSet<Students>();

        public ICollection<Exams> Exams { get; set; } = new HashSet<Exams>();
    }
}