using HomeworkSql.Models;
using HomeworkSql.Repositories;

const string connectionString = @"Data Source=DESKTOP-7A97DSQ;Initial Catalog=Homework;Pooling=true;Integrated Security=SSPI;TrustServerCertificate=True";

ISubjectsRepository subjectsRepository = new RawSqlSubjectsRepository(connectionString);

PrintCommands();
while (true)
{
    Console.WriteLine("Введите команду:");
    string command = Console.ReadLine();

    if (command == "get-subjects")
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
    else if (command == "delete-subject-by-name")
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
            subjectsRepository.Delete(subject);
            Console.WriteLine("Предмет удален");
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
    Console.WriteLine("get-subjects - Получить список предметов авторов");
    Console.WriteLine("get-by-name - Получить предмет по имени");
    Console.WriteLine("delete-subject-by-name - Удалить предмет по имени");
    Console.WriteLine("update-subject - Обновить предмет");
    Console.WriteLine("help - Список команд");
    Console.WriteLine("exit - Выход");
}