using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkSql.Models;

namespace HomeworkSql.Repositories
{
    public interface ISubjectsRepository
    {
        IReadOnlyList<Subjects> GetAll();
        Subjects GetById(int id);
        Subjects GetByName(string name);
        void Update(Subjects subjects);
        void Delete(Subjects subjects);
    }
}
