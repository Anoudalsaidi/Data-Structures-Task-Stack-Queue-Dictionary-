using System;
using System.Collections.Generic;

namespace StudentServiceCenter
{
    internal class Program
    {
        static Dictionary<int, string> students = new Dictionary<int, string>();
        static Queue<int> queue = new Queue<int>();
        static Stack<int> stack = new Stack<int>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Student Service Center ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Remove Student");
                Console.WriteLine("4. Show All Students");
                Console.WriteLine("5. Join Service Queue");
                Console.WriteLine("6. Serve Next Student");
                Console.WriteLine("7. Undo Last Service");
                Console.WriteLine("8. Show Queue");
                Console.WriteLine("9. Exit");

                Console.Write("Choose: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddStudent(); break;
                    case 2: UpdateStudent(); break;
                    case 3: RemoveStudent(); break;
                    case 4: ShowStudents(); break;
                    case 5: JoinQueue(); break;
                    case 6: ServeStudent(); break;
                    case 7: UndoService(); break;
                    case 8: ShowQueue(); break;
                    case 9: return;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }

        // 1. Add Students
        static void AddStudent()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            if (students.ContainsKey(id))
            {
                Console.WriteLine("Student ID already exists!");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            students.Add(id, name);
            Console.WriteLine("Student added.");
        }

        // 2. Update Student
        static void UpdateStudent()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            if (students.ContainsKey(id))
            {
                Console.Write("Enter new name: ");
                students[id] = Console.ReadLine();
                Console.WriteLine("Updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        // 3. Remove Student
        static void RemoveStudent()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            if (students.Remove(id))
                Console.WriteLine("Removed successfully.");
            else
                Console.WriteLine("Student not found.");
        }

        // 4. Show All Students
        static void ShowStudents()
        {
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Key} -> {s.Value}");
            }
        }

        // 5. Join Queue
        static void JoinQueue()
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());

            if (!students.ContainsKey(id))
            {
                Console.WriteLine("Student not registered.");
                return;
            }

            queue.Enqueue(id);
            Console.WriteLine("Added to queue.");
        }

        // 6. Serve Student
        static void ServeStudent()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            int id = queue.Dequeue();
            stack.Push(id);

            Console.WriteLine($"Serving: {students[id]}");
        }

        // 7. Undo Service
        static void UndoService()
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("No service to undo.");
                return;
            }

            int id = stack.Pop();
            queue.Enqueue(id);

            Console.WriteLine($"{students[id]} returned to queue.");
        }

        // 8. Show Queue
        static void ShowQueue()
        {
            foreach (int id in queue)
            {
                Console.WriteLine($"{id} -> {students[id]}");
            }

            Console.WriteLine($"Total in queue: {queue.Count}");
        }
    }
}