using HomeworkSql.Models;
using HomeworkSql.Repositories;

const string connectionString = @"Data Source=DESKTOP-7A97DSQ;Initial Catalog=Homework;Pooling=true;Integrated Security=SSPI;TrustServerCertificate=True";

ISubjectsRepository subjectsRepository = new RawSqlSubjectsRepository(connectionString);
ITeacherRepository teacherRepository = new RawSqlTeacherRepository(connectionString);

PrintCommands();
while (true)
{
    Console.WriteLine("Введите команду:");
    string command = Console.ReadLine();

    if (command == "get-teachers")
    {
        IReadOnlyList<Teacher> teachers = teacherRepository.GetAll();
        if (teachers.Count == 0)
        {
            Console.WriteLine("Предметы не найдены!");
            continue;
        }

        foreach (Teacher teacher in teachers)
        {
            Console.WriteLine($"Id: {teacher.Id},TeachersName: {teacher.TeachersName}, TaughtSubject: {teacher.TaughtSubject}");
        }
    }

    else if (command == "get-subjects")
    {
        IReadOnlyList<Subjects> subjects = subjectsRepository.GetAll();
        if (subjects.Count == 0)
        {
            Console.WriteLine("Предметы не найдены!");
            continue;
        }

        foreach (Subjects subject in subjects)
        {
            Console.WriteLine($"Id: {subject.Id},Classroom: {subject.Classroom}, SubjectName: {subject.SubjectName}");
        }
    }
    else if (command == "get-by-name")
    {
        Console.WriteLine("Введите имя:");
        string name = Console.ReadLine();
        Subjects subject = subjectsRepository.GetByName(name);
        if (subject == null)
        {
            Console.WriteLine("Предмет не найден");
        }
        else
        {
            Console.WriteLine($"Id: {subject.Id},Classroom: {subject.Classroom}, Name:{subject.SubjectName}");
        }

    }
    else if (command == "delete-teacher-by-name")
    {
        Console.WriteLine("Введите имя:");
        string name = Console.ReadLine();
        Teacher teacher = teacherRepository.GetByName(name);
        if (teacher == null)
        {
            Console.WriteLine("Преподаватель не найден");
        }
        else
        {
            teacherRepository.Delete(teacher);
            Console.WriteLine("реподаватель удалён");
        }
    }
    else if (command == "get-teachers-grouped-by-subjects")
    {
        IReadOnlyList<Teacher> teachers = teacherRepository.GroupByTaughtSubject();
        if (teachers.Count == 0)
        {
            Console.WriteLine("Предметы не найдены!");
            continue;
        }

        foreach (Teacher teacher in teachers)
        {
            Console.WriteLine($"NumberOfTeachersTeachingTheSubject {teacher.Id}, TaughtSubject: {teacher.TaughtSubject}");
        }
    }
    else if (command == "update-subject")
    {
        bool condition;
        int id;
        do
        {
            Console.WriteLine("Введите Id:");
            string temp = Console.ReadLine();
            condition = Int32.TryParse(temp, out id);
            if (condition == false)
            {
                Console.WriteLine("Некоректные данные, повторите ввод");
            }
        } while (condition == false);
        Subjects subject = subjectsRepository.GetById(id);
        if (subject == null)
        {
                Console.WriteLine("Предмет не найден");
                continue;
        }
        else
        {
                condition = false;
                int newClassroom;
                do
                {
            
                    Console.WriteLine("Введите номер класса: ");
                    string temp = Console.ReadLine();
                    condition = Int32.TryParse(temp, out newClassroom);
                    if (condition == false)
                    {
                        Console.WriteLine("Некоректные данные, повторите ввод");
                    }
                } while (condition == false);

                Console.WriteLine("Введите новое название предмета: ");
                string newSubjectName = Console.ReadLine();
                Subjects newSubject =new (id, newClassroom, newSubjectName);
                subjectsRepository.Update(newSubject);
                Console.WriteLine("Данные обновленны");
        }
        
    }
    else if (command == "help")
    {
        PrintCommands();
    }
    else if (command == "exit")
    {
        break;
    }
    else
    {
        Console.WriteLine("Неправильно введенная команда");
    }
}

void PrintCommands()
{
    Console.WriteLine("Доступные команды:");
    Console.WriteLine("get-teachers - Получить список учителей");
    Console.WriteLine("get-subjects - Получить список предметов");
    Console.WriteLine("get-by-name - Получить предмет по имени");
    Console.WriteLine("get-teachers-grouped-by-subjects - Получить список предметов сортированный по количеству учителей");
    Console.WriteLine("delete-teacher-by-name - Удалить предмет по имени");
    Console.WriteLine("update-subject - Обновить предмет");
    Console.WriteLine("help - Список команд");
    Console.WriteLine("exit - Выход");
}