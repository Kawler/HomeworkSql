using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkSql.Models;

namespace HomeworkSql.Repositories
{
    public interface ITeacherRepository
    {
        IReadOnlyList<Teacher> GetAll();
        Teacher GetByName(string name);
        void Delete(Teacher teacher);
        IReadOnlyList<Teacher> GroupByTaughtSubject();
    }
}
