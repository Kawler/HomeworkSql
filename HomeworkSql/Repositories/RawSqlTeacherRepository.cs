using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkSql.Models;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace HomeworkSql.Repositories
{
    public class RawSqlTeacherRepository: ITeacherRepository
    {
        private readonly string _connectionString;

        public RawSqlTeacherRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IReadOnlyList<Teacher> GetAll()
        {
            var result = new List<Teacher>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [TeachersName], [TaughtSubject] from [Teacher]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Teacher(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["TeachersName"]),
                    Convert.ToString(reader["TaughtSubject"])
                ));
            }

            return result;
        }

        public Teacher GetByName(string teachersName)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [Id], [TeachersName], [TaughtSubject] from [Teacher] where [TeachersName] = @teachersName";
            sqlCommand.Parameters.Add("@teachersName", SqlDbType.NVarChar, 50).Value = teachersName;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Teacher(
                    Convert.ToInt32(reader["Id"]),
                    Convert.ToString(reader["TeachersName"]),
                    Convert.ToString(reader["TaughtSubject"]));
            }
            else
            {
                return null;
            }
        }

        public void Delete(Teacher teachers)
        {
            if (teachers == null)
            {
                throw new ArgumentNullException(nameof(teachers));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [Teacher] where [Id] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = teachers.Id;
            sqlCommand.ExecuteNonQuery();
        }

        public IReadOnlyList<Teacher>GroupByTaughtSubject()
        {
            var result = new List<Teacher>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select count([Id]) c, [TaughtSubject] from [Teacher] group by [TaughtSubject]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Teacher(
                    Convert.ToInt32(reader["c"]),
                    "Lazyness",
                    Convert.ToString(reader["TaughtSubject"])
                ));
            }

            return result;
        }

    }
}
