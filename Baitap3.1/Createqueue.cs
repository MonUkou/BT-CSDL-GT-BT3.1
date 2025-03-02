using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap3._1
{
    class Createqueue
    {
        public class Node2
        {
            public Node2 prev, next;
            public object data;
        }
        public class Myqueue
        {
            public void InputQueue(int n)
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
                    this.Enqueue(x);
                }
            }
            Node2 rear, front;
            public bool IsEmpty() // Kiểm tra queue rỗng
            {
                return rear == null || front == null;
            }
            public void Enqueue(object ele) // Thêm phần tử vào queue
            {
                Node2 n = new Node2();
                n.data = ele;
                if (rear == null)
                {
                    rear = n;
                    front = n;
                }
                else
                {
                    rear.next = n;
                    n.prev = rear;
                    rear = n;
                }
            }
            public Node2 Dequeue() // Lấy và xoá phần tử ở đầu queue
            {
                if (front == null)
                    return null;
                Node2 d = front;
                front = front.next;
                if (front == null)
                    rear = null;
                else
                    front.prev = null;
                return d;
            }
            public int Count() // Đếm số phần tử trong queue
            {
                int dem = 0;
                Node2 temp = front;
                while (temp != null)
                {
                    dem++;
                    temp = temp.next;
                }
                return dem;
            }
            public object Peek() // Xem phần tử ở đầu queue mà không xoá nó
            {
                if (front == null)
                    return null;
                return front.data;
            }
            public bool Contain(object ele) // Kiểm tra phần tử có trong queue không
            {
                Myqueue myqueue = new Myqueue();
                while (rear != null || front != null)
                {
                    int value = (int)Dequeue().data;
                    myqueue.Enqueue(value);
                    if (value == (int)ele)
                    {
                        while (myqueue.front != null)
                        {
                            Enqueue(myqueue.Dequeue().data);
                        }
                        return true;
                    }
                }
                while (myqueue.front != null)
                {
                    Enqueue(myqueue.Dequeue().data);
                }
                return false;
            }
            public void SortIncreaseQueue()
            {
                if (front == null) return;
                Myqueue sortedQueue = new Myqueue();
                while (!IsEmpty())
                {
                    int minValue = (int)Peek();
                    int n = Count();

                    for (int i = 0; i < n; i++)
                    {
                        int value = (int)Dequeue().data;
                        if (value < minValue)
                            minValue = value;
                        Enqueue(value);
                    }
                    bool removed = false;
                    for (int i = 0; i < n; i++)
                    {
                        int value = (int)Dequeue().data;
                        if (!removed && value == minValue)
                            removed = true;
                        else
                            Enqueue(value);
                    }
                    sortedQueue.Enqueue(minValue);
                }
                while (!sortedQueue.IsEmpty())
                    Enqueue(sortedQueue.Dequeue().data);
            }

        }
    }
}
    