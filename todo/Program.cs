using System;
using todo.Models;
using todo.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace todo
{
    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("Opcje do wyboru:");
            Console.WriteLine("1) Pokaż listę rzeczy do zrobienia");
            Console.WriteLine("2) Dodaj nową rzecz do zrobienia");
            Console.WriteLine("3) Oznacz rzecz jako wykonaną");
            Console.WriteLine("4) Pobierz listę do pliku");
            Console.WriteLine("5) Exportuj dane z pliku");
            Console.WriteLine("6) Pokaż listę z warunkiem");
            Console.WriteLine("7) Oblicz silnię");
            Console.WriteLine("0) Zakończ program");
            Console.Write("Wybierz: ");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                int Option = int.Parse(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        Todo.TodoList();
                        break;
                    case 2:
                        Console.WriteLine("Dodaj nową rzecz do listy:");
                        Console.WriteLine("Podaj treść:");
                        string content = Console.ReadLine();
                        Console.WriteLine("Podaj priorytet:");
                        Todo.PrintPriorityType();
                        int priority = int.Parse(Console.ReadLine());

                        Console.WriteLine(Todo.NewTodo(content, priority));
                        break;
                    case 3:
                        Console.WriteLine(Todo.CheckTodo());
                        break;
                    case 4:
                        Console.WriteLine("Podaj ścieżkę do pliku");
                        string path = Console.ReadLine();
                        Console.WriteLine(Todo.GetListToFile(path));
                        break;
                    case 5:
                        Console.WriteLine("Podaj ścieżkę do pliku");
                        string filePath = Console.ReadLine();
                        Console.WriteLine(Todo.LoadTodoFromFile(filePath));
                        break;
                    case 6:
                        Console.WriteLine("Czy pokazać tylko wykonane rzeczy? [yes/no]");
                        string answer = Console.ReadLine();
                        bool show = answer == "yes" ? true : false;
                        Todo.TodoList(show);
                        break;
                    case 7:
                        Console.WriteLine("Podaj liczbę z które ma być obliczona silnia: ");
                        ulong num = ulong.Parse(Console.ReadLine());
                        Console.WriteLine(Todo.Factorial(num));
                        break;
                    case 0:
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Brak takiej opcji");
                        break;
                }
            }
        }
    }
}
