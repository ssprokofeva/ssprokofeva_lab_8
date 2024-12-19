using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssprokofeva_lab_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = CreatePeople();
            var projects = CreateProjects(people);

            foreach (var project in projects)
            {
                Console.WriteLine($"Проект: {project.Description}");
                foreach (var task in project.Tasks)
                {
                    Console.WriteLine($"\tЗадача: {task.Description}, Статус: {task.CurrentStatus}");
                    foreach (var report in task.Reports)
                    {
                        Console.WriteLine($"\t\tОтчет: {report.Text}, Дата: {report.SubmissionDate}");
                    }
                }
            }

            Console.ReadKey();
        }

        private static List<Person> CreatePeople()
        {
            return new List<Person>
        {
            new Person("Иван Иванов"),
            new Person("Петр Петров"),
            new Person("Сергей Сергеев"),
            new Person("Андрей Андреев"),
            new Person("Алексей Алексеев"),
            new Person("Дмитрий Дмитриев"),
            new Person("Николай Николаев"),
            new Person("Михаил Михайлов"),
            new Person("Владимир Владимирович"),
            new Person("Евгений Евгеньевич")
        };
        }

        private static List<Project> CreateProjects(List<Person> people)
        {
            var projects = new List<Project>();

            var project1 = new Project(
                "Разработка нового продукта",
                DateTime.Now,
                DateTime.Now.AddMonths(6),
                people[0],
                people[1]);

            var task1 = new Task("Анализ требований", DateTime.Now.AddDays(7), people[0], people[2]);
            var task2 = new Task("Разработка прототипа", DateTime.Now.AddDays(14), people[0], people[3]);
            var task3 = new Task("Тестирование прототипа", DateTime.Now.AddDays(21), people[0], people[4]);

            project1.AddTask(task1);
            project1.AddTask(task2);
            project1.AddTask(task3);

            projects.Add(project1);

            return projects;
        }
    }
}
    

