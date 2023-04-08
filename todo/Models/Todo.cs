using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo.DataContext;

namespace todo.Models
{
    class Todo
    {
        [Key]
        public int id { get; set; }
        public string content { get; set; }
        public int dateAdd { get; set; }
        public int priority { get; set; }
        public int done { get; set; }

        public static Dictionary<int, string> priorityType = new Dictionary<int, string>() 
        {
            { 0, "Mało ważne"},
            { 1, "Ważne"},
            { 2, "Bardzo ważne"} 
        };

        public static void PrintPriorityType()
        {
            foreach (KeyValuePair<int, string> prio in priorityType)
            {
                Console.WriteLine($"{prio.Key} - {prio.Value}");
            }
        }

        private static string ParseToTime(int dateAsInt)
        {
            int day = dateAsInt / 1000000;
            int month = (dateAsInt / 10000) % 100;
            int year = dateAsInt % 10000;

            DateTime date = new DateTime(year, month, day);

            return date.ToString("dd/MM/yyyy");
        }

        public static void TodoList()
        {
            using var result = new DbConn();
            List<Todo> list = result.todo.ToList();

            Console.WriteLine("-------------");
            
            foreach (Todo obj in list)
            {
                if (obj.done == 0)
                {
                    Console.WriteLine($"#{obj.id} {obj.content} {ParseToTime(obj.dateAdd)} {priorityType[obj.priority]}");
                }
            }
            Console.WriteLine("-------------");
            Console.WriteLine("Koniec listy");
        }

        public static void TodoList(bool done)
        {
            using var result = new DbConn();
            List<Todo> list = result.todo.ToList();

            Console.WriteLine("-------------");
            int isDone = done ? 1 : 0;

            foreach (Todo obj in list)
            {
                if (obj.done == isDone)
                {
                    Console.WriteLine($"#{obj.id} {obj.content} {ParseToTime(obj.dateAdd)} {priorityType[obj.priority]}");
                }
            }
            Console.WriteLine("-------------");
            Console.WriteLine("Koniec listy");
        }
        public static string NewTodo(string content, int priority)
        {
            if (priority < 0 || priority > 2)
            {
                return "Podano priorytet z poza przedziału";
            }

            using(var conn = new DbConn())
            {
                Todo newTodo = new Todo();
                newTodo.content = content.ToString();
                newTodo.priority = priority;
                newTodo.done = 0;

                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("ddMMyyyy");

                newTodo.dateAdd = Int32.Parse(formattedDate);
                conn.Add(newTodo);
                conn.SaveChanges();
            }

            return "Dodano nową rzecz do listy";
        }

        public static string CheckTodo()
        {
            Console.WriteLine("Podaj numer na liście:");
            int id = int.Parse(Console.ReadLine());

            using (var conn = new DbConn())
            {
                Todo todo = conn.todo.Single(t => t.id == id);

                if (todo == null)
                {
                    return "Nie znaleziono danego przedmiotu na liście";
                }
                else
                {
                    todo.done = 1;
                    conn.SaveChanges();
                }
            }

            return $"Przedmiot nr {id} został oznaczony jako wykonany";
        }

        public static string GetListToFile(string path)
        {
            try
            {
                using (StreamWriter writer = new(path))
                {
                    using var result = new DbConn();
                    List<Todo> list = result.todo.ToList();

                    foreach (Todo obj in list)
                    {
                        if (obj.done == 0)
                        {
                            writer.WriteLine($"#{obj.id} {obj.content} {ParseToTime(obj.dateAdd)} {priorityType[obj.priority]}");
                        }
                    }
                }
            } catch (Exception e)
            {
                return "Nie znaleziono ścieżki do pliku";
            }

            return "Pobrano listę do pliku: " + path;
        }

        public static string LoadTodoFromFile(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] data = line.Split("|");
                    int priority = int.Parse(data[1]);

                    if (priority < 0 || priority > 2)
                    {
                        return "Podano priorytet z poza przedziału";
                    }
                    NewTodo(data[0], priority);
                }
                
            }
            catch (Exception e)
            {
                return "Nie znaleziono ścieżki do pliku";
            }

            return "Pobrano listę z pliku: " + path;
        }

        public static ulong Factorial(ulong num)
        {
            if (num > 1)
            {
                num *= Factorial(num - 1);
            }

            return num;
        }
    }
}
