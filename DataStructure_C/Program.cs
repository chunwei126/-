using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CircularQueue Queue = new CircularQueue(5);
			string[] queue = Queue.Queue;
			int rear = 0;
			int front = 0;
			int empty = 0;
			int length = queue.Length;
			while (true)
			{
				Console.WriteLine("請輸入你選擇的工作:");
				Console.WriteLine("----------");
				string instruction = Console.ReadLine().ToLower();

				if (instruction == "e") // 加入一筆新資料
				{
					if (rear+1 <= length-1 && rear+1 != empty)
					{
						Console.WriteLine("請輸入數值:");
						Console.WriteLine("----------");
						string value = Console.ReadLine();
						Console.WriteLine("----------");
						rear += 1;
						Queue.E(rear, front, empty, queue, value);
					}
					else
					{
						if (rear+1 > length-1 && front != empty)
						{
							Console.WriteLine("請輸入數值:");
							Console.WriteLine("----------");
							string value = Console.ReadLine();
							Console.WriteLine("----------");
							rear = empty;
							empty = front;
							queue[empty] = "empty";
							Queue.E(rear, front, empty, queue, value);
						}
						else if (rear+1 <= length-1 && front != empty)
						{
							Console.WriteLine("請輸入數值:");
							Console.WriteLine("----------");
							string value = Console.ReadLine();
							Console.WriteLine("----------");
							rear += 1;
							empty = front;
							queue[empty] = "empty";
							Queue.E(rear, front, empty, queue, value);
						}
						else
						{
							Console.WriteLine("----------");
							Console.WriteLine("空間已滿");
							Console.WriteLine("----------");
						}
					}
				}
				else if (instruction == "d") // 刪除一筆資料
				{
					if (front+1 <= length-1 && queue[front+1] != "目前為空" && front != rear)
					{
						Console.WriteLine("----------");
						front += 1;
						Queue.D(front, rear, empty, queue);
					}
					else
					{
						Console.WriteLine("----------");
						if (front+1 > length-1 && queue[0] != "empty")
						{
							front = 0;
							Queue.D(front, rear, empty, queue);
						}
						else
						{
							Console.WriteLine("佇列是空的，無法執行Dequeue!");
							Console.WriteLine("----------");
						}
					}
				}
				else if (instruction == "l")
				{
					Queue.L(queue);
				}
				else if (instruction == "x")
				{
					break;
				}
			}
		}

			

		public class CircularQueue
		{
			public CircularQueue(int len)
			{
				Queue = new string[len];
				Queue[0] = "empty";
				Queue[1] = "目前為空";
				Queue[2] = "目前為空";
				Queue[3] = "目前為空";
				Queue[4] = "目前為空";
			}
	
			public string[] Queue { get; set; }

			public void E(int rear, int front, int empty, string[] queue, string value)
			{
				queue[rear] = value;
				foreach (var item in queue)
				{
					Console.WriteLine(item);
				}
				Console.WriteLine($"Rear目前位置:{rear}");
				Console.WriteLine($"Front目前位置:{front}");
				Console.WriteLine($"Empty目前位置:{empty}");
			}

			public void D(int front, int rear, int empty, string[] queue)
			{
				queue[front] = "目前為空";
				foreach (var item in queue)
				{
					Console.WriteLine(item);
				}
				Console.WriteLine($"Rear目前位置:{rear}");
				Console.WriteLine($"Front目前位置:{front}");
				Console.WriteLine($"Empty目前位置:{empty}");
			}

			public string A(int rear, string[] queue)
			{
				return queue[rear - 1] = queue[rear - 1] + queue[rear];
			}

			public void L(string[] queue)
			{
				Console.WriteLine(queue[1]);
			}
		}
	}
}

/*
構思:我是透過物件的方式，將環形佇列會使用到的所有Method寫在class CircularQueue裡面，當外界New出CircularQueue這個物件時，就可以使用到Class裡面的所有Method。

作法:首先，我先New出CircularQueue，並將環形佇列會使用到的變數先定義好，最後再利用While迴圈，將所有判斷式都寫在裡面，但由於while迴圈的條件是true，所以使用者無論如何都無法跳出迴圈，除非當使用者按下x，才可以break出來。

技巧:這是一份有bug的作業...如果硬要說技巧的話，大概就是第23行string instruction = Console.ReadLine().ToLower()，這段code無論使用者輸入的指令是大寫還小寫，都會被強制轉為小寫，好讓程式可以判斷並做出相對應的事情，達到一致性。

問題:老師對不起...我的這份作業因為有bug的關係，所以沒有寫完(我拼命去想拼命測也都解不出來...)，我覺得我的盲點應該在if的判斷點，因為if沒有寫好，導致程式出bug。
 */
