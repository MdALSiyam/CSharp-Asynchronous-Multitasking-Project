using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTask_Asynchronous
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                DoTask();
			}
			catch (Exception ex)
			{

                Console.WriteLine(ex.Message);
			}
            finally
            {
                Console.ReadLine();
            }
        }

        private static void DoTask()
        {
            Console.WriteLine("Seven ways to start Task in C# .NET");
            Console.WriteLine("===================================");
            Console.WriteLine();
            
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("It is Factory Method");
            });
            Console.WriteLine();
            Console.WriteLine("-----------------1-----------------");

            Task actionTask = new Task ( new Action (CreateTaskUsingAction));
            actionTask.Wait(1000);
            actionTask.Start();
            Console.WriteLine();
            Console.WriteLine("-----------------2-----------------");

            Task delegateTask = new Task ( delegate
            {
                 CreateTaskUsingDelegate();
            });
            delegateTask.Wait(1000);
            delegateTask.Start();
            Console.WriteLine();
            Console.WriteLine("-----------------3-----------------");

            Task lambdaTask = new Task(() =>
            {
                CreateTaskUsingLambdaMethod();
            });
            lambdaTask.Wait(1000);
            lambdaTask.Start();
            Console.WriteLine();
            Console.WriteLine("-----------------4-----------------");

            Task lambdaAnnomynousTask = new Task(() =>
            {
                CreateTaskUsingLambdaAnomynousMethod();
            });
            lambdaAnnomynousTask.Wait(1000);
            lambdaAnnomynousTask.Start();
            Console.WriteLine();
            Console.WriteLine("-----------------5-----------------");
            
            CreateAsynchronousTask();
            Console.WriteLine();
            Console.WriteLine("-----------------6-----------------");
            CreateAsynchronousTaskAndAwait();
            Console.WriteLine();

            Console.WriteLine("-----------------7-----------------");

            Console.WriteLine("Enter first number");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Addition(num1, num2);
            
        }

        private static async void Addition(int num1, int num2)
        {
            int result = await Task.FromResult(AddNumbers(num1, num2));
            await Task.Delay(1000);
            Console.WriteLine($"Result is {result}");
        }

        private static int AddNumbers(int num1, int num2)
        {
            return num1 + num2;
        }

        private static async void CreateAsynchronousTask()
        {
            await Task.Run(() => CreateAsynchronousTask());
        }

        private static void CreateAsynchronousTaskAndAwait()
        {
            Console.WriteLine("It is Asynchronous Task And Await");
        }


        private static void CreateTaskUsingLambdaAnomynousMethod()
        {
            Console.WriteLine("It is Lambda Anomynous Method");
        }

        private static void CreateTaskUsingLambdaMethod()
        {
            Console.WriteLine("It is Lambda Method");
        }

        private static void CreateTaskUsingDelegate()
        {
            Console.WriteLine("It is Delegate Method");
        }

        private static void CreateTaskUsingAction()
        {
            Console.WriteLine("It is Action Method");
        }
    }
}
