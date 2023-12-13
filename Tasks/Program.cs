using System;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace Tasks
{
    class Program
    {
        static void Main()
        {
            //Задача 1 - написать программу , в которой реализовано 3 потока, печатающих числа от 1 до 10.
            Console.WriteLine("Задача 1 - написать программу , в которой реализовано 3 потока, печатающих числа от 1 до 10.");
            Thread thread1 = new Thread(PrintNumbers);
            Thread thread2 = new Thread(PrintNumbers);
            Thread thread3 = new Thread(PrintNumbers);

            //запускаем потоки
            thread1.Start();
            thread2.Start();
            thread3.Start();

            //ждем окончания работы всех потоков
            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("\nПотоки завершили работу.\n");


            //Задача 2 - написать программу которая асинхронно вычисляет факториал и синхронно вычисляет квадрат числа.
            Console.WriteLine("Задача 2 - написать программу которая асинхронно вычисляет факториал и синхронно вычисляет квадрат числа.");
            Console.Write("\nВведите число: ");
            int number = int.Parse(Console.ReadLine());

            Task<long> factorialTask = CalculateFactorialAsync(number);
            long squareResult = CalculateSquare(number);

            Console.WriteLine($"Факториал числа {number} = {factorialTask.Result}");
            Console.WriteLine($"Квадрат числа {number} = {squareResult}");


            //Задача 3 - вывести все(!) методы для обьекта.(Рефлексия)
            Console.WriteLine("Задача 3 - вывести все(!) методы для обьекта.");
            // Получение типа объекта
            Type type = typeof(Program);
            // Получение всех методов в типе
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            // Вывод имен всех методов
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
            Console.ReadLine();
        }
        //метод для задачи 1
        static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Поток {0}: {1}\n", Thread.CurrentThread.ManagedThreadId, i);
                Thread.Sleep(500); //остановка выполнения потока на 0.5 секунды
            }
        }
        //задача 2 - асинхронное вычисление факториала
        static async Task<long> CalculateFactorialAsync(int number)
        {
            await Task.Delay(8000); //задержка потока на 8 секунд(из условия задачи)

            long factorial = 1;

            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
        //задача 2 - синхронное вычисление факториала
        static long CalculateSquare(int number) 
        {
            return number * number;
        }
        //задача 3 - методы из условия
        public string Output()
        {
            return "Test-Output";
        }

        public int AddInts(int i1, int i2)
        {
            return i1 + i2;
        }
    }
}
