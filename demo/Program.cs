using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Execute Async.");
            //Execute method with no arguments
            Async.Execute(VoidMethod, 5, 6, 7, null, VoidMethodCallback);
            Async.Execute(ReturnMethod, 1, 2, 3, null, ReturnMethodCallback);
            //Initialize state, this will be available in the callback. Any object can be passed with state.
            Async.Execute(ReturnMethod, 1, 2, 3, new int[] { 99, 99}, ReturnMethodWithStateCallback);
            //Exception in method
            Async.Execute(MethodWithException, null, ReturnMethodWithStateCallback);
            Console.ReadKey();
        }                

        static void VoidMethod(int a, int b, int c)
        {
            Console.WriteLine("VoidMethod()");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("VoidMethod() ==> Sum = " + (a + b + c));
        }        

        static int ReturnMethod(int a, int b, int c)
        {
            Console.WriteLine("ReturnMethod()");
            System.Threading.Thread.Sleep(5000);
            return a + b + c;
        }

        static int MethodWithException()
        {
            System.Threading.Thread.Sleep(5000);
            throw new ApplicationException("Application Exception!");
        }


        private static void VoidMethodCallback(object state, Exception ex)
        {
            Console.WriteLine("VoidMethodCallback()");
        }

        private static void ReturnMethodCallback(int sum, object state, Exception ex)
        {
            if (ex != null)
            {
                Console.WriteLine("Exception caught." + ex.Message);
                return;
            }
            Console.WriteLine("Callback() ==> Sum = " + sum);
        }

        private static void ReturnMethodWithStateCallback(int sum, object state, Exception ex)
        {
            if (ex != null)
            {
                Console.WriteLine("Exception caught." + ex.Message);
                return;
            }
            
            Console.WriteLine("Callback() ==> Sum = " + sum + " State = " + state.ToString());
        }
    }
}
