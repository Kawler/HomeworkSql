
namespace HomeworkSql.Models
{
    public class Teacher
    {
        public Teacher(int id, string teachersName, string taughtSubject)
        {
            Id = id;
            TeachersName = teachersName;
            TaughtSubject = taughtSubject;
        }

        public int Id { get; private set; }
        public string TeachersName{ get; private set; }
        public string TaughtSubject { get; private set; }
    }
}
