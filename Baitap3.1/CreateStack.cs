using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Baitap3._1
{
    class CreateStack
    {
        public class Node1
        {
            public Node1 next;
            public object data;
        }
        public class Mystack
        {
            public void InputStack(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Nhập phần tử thứ {i + 1}: ");
                    int x;
                    while (!int.TryParse(Console.ReadLine(), out x))
                    {
                        Console.WriteLine("Vui lòng nhập số nguyên!");
                        Console.Write($"Nhập lại phần tử thứ {i + 1}: ");
                    }
                    this.Push(x);
                }
            }
            Node1 top;
            public int countA = 0;
            public bool IsEmpty() // Kiểm tra stack rỗng
            {
                return top == null;
            }
            public void Push(object ele) // Thêm phần tử vào đỉnh stack
            {
                Node1 n = new Node1();
                n.data = ele;
                n.next = top;
                top = n;
                countA++;
            }
            public Node1 Pop() // Lấy và xoá phần tử ở đỉnh stack
            {
                if (top == null)
                    return null;
                Node1 d = top;
                top = top.next;
                if (countA > 0)
                    countA--;
                return d;
            }
            public int Count() // Đếm số phần tử trong stack
            {

                int count = 0;
                Mystack mystack = new Mystack();
                do
                {
                    count++;
                    mystack.Push(Pop().data);
                }
                while (top != null);
                do
                {
                    Push(mystack.Pop().data);
                }
                while (mystack.top != null);
                return count;
            }
            public object Peek() //  xem phần tử ở đỉnh stack mà không xoá nó
            {
                if (top == null)
                    return null;
                return top.data;
            }
            public bool Contains(object ele) // Kiểm tra phần tử có trong stack không
            {
                Mystack mystack = new Mystack();
                while (top != null)
                {
                    int value = (int)Pop().data;
                    mystack.Push(value);
                    if (value == (int)ele)
                    {
                        while (mystack.top != null)
                            Push(mystack.Pop().data);
                        return true;
                    }
                }
                while (mystack.top != null)
                    Push(mystack.Pop().data);
                return false;
            }
            public void SortIncreaseStack() // Sắp xếp thứ tự tăng dần
            {
                Mystack mystack = new Mystack();
                while (top != null)
                {
                    int value = (int)Pop().data; 
                    while (mystack.top != null && (int)mystack.Peek() > value)
                        Push(mystack.Pop().data);                    
                    mystack.Push(value);
                }
                while (mystack.top != null)
                    Push(mystack.Pop().data);
            }

        }
    }
}
