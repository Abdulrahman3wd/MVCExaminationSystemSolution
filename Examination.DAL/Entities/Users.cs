namespace Examination.DAL.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }

        public ICollection<Groups> Groups { get; set; } = new HashSet<Groups>();



    }
}
