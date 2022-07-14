using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkSql.Models
{
    public class Subjects
    {
        public Subjects(int id, int classroom, string subjectName)
        {
            Id = id;
            Classroom = classroom;
            SubjectName = subjectName;
        }

        public int Id { get; private set; }
        public int Classroom { get; private set; }
        public string SubjectName { get; private set; } 

        public void UpdateSubjectName(string newName)
        {
            SubjectName = newName;
        }

        public void UpdateSubjectClassroom(int newClassroom)
        {
            Classroom = newClassroom;
        }
    }
}
