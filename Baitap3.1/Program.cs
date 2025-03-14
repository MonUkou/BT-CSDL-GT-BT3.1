﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Mời bạn nhập số phần tử: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Timing timing = new Timing();
            int ntimes = 10000000; //Số lần lặp lại để đo hiệu suất


            // Ngăn xếp Stack
            Console.WriteLine("------------------------------");
            CreateStack.Mystack mystack = new CreateStack.Mystack();
            mystack.InputStack(n);
            Console.WriteLine("-----");
            Console.WriteLine($"Số phần tử trong stack là: {mystack.Count()}");
            if (!mystack.IsEmpty())
                Console.WriteLine($"Phần tử ở đỉnh stack là: {mystack.Peek()}");
            else Console.WriteLine("Stack đang rỗng.");
                Console.Write("Sắp xếp stack tăng dần: ");
            mystack.SortIncreaseStack();
            while (!mystack.IsEmpty())
                Console.Write(mystack.Pop().data + " ");
            timing.StartTime(); //Bắt đầu tính thời gian cho đối tượng
            for (int i = 0; i < ntimes; i++)
            {
                mystack.Peek();
                mystack.SortIncreaseStack();
            }
            timing.StopTime(); // Dừng tính thời gian cho đối tượng khi đặt đến số lần lặp tối đa (10000000)
            Console.WriteLine($"\nDuration: {timing.Result().TotalMilliseconds / ntimes}ms"); //In ra thời gian trung bình lặp
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            //Ngăn xếp Queue
            Console.WriteLine("------------------------------");
            Createqueue.Myqueue myqueue = new Createqueue.Myqueue();
            myqueue.InputQueue(n);
            Console.WriteLine("-----");
            Console.WriteLine($"Số phần tử trong queue là: {myqueue.Count()}");
            if (!myqueue.IsEmpty())
                Console.WriteLine($"Phần tử ở đầu queue là: {myqueue.Peek()}");
            else Console.WriteLine("Queue đang rỗng.");
            Console.WriteLine("Sắp xếp queue tăng dần: ");
            myqueue.SortIncreaseQueue();
            while (!myqueue.IsEmpty())
                Console.Write(myqueue.Dequeue().data + " ");
            timing.StartTime(); //Bắt đầu tính thời gian cho đối tượng
            for (int i = 0; i < ntimes; i++)
            {
                myqueue.Peek();
                myqueue.SortIncreaseQueue();
            }
            timing.StopTime(); // Dừng tính thời gian cho đối tượng khi đặt đến số lần lặp tối đa (10000000)
            Console.WriteLine($"\nDuration: {timing.Result().TotalMilliseconds / ntimes}ms"); //In ra thời gian trung bình lặp
            Console.WriteLine("------------------------------");
        }
    }
}
