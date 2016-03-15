using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Grafy_Algorytmy
{
	//fun1 - wypelnianie tablic
	class Program
	{
		static List<Point> list1 = new List<Point>();
		static List<Point> listX = new List<Point>();
		static List<Point> listY = new List<Point>();

		public struct Point
		{
			public Point(double x, double y)
			{
				X = x;
				Y = y;
			}

			public double X { get; set; }
			public double Y { get; set; }
		}

		public static void AddPoint(double x, double y)
		{
			list1.Add(new Point(x, y));
		}

		public static void SortList()
		{
			listX = list1.OrderBy(o => o.X).ToList();
			listY = list1.OrderBy(o => o.Y).ToList();
		}

		public static void PrintList()
		{
			foreach (Point point in list1)
			{
				Console.Write(point.X + " " + point.Y + "|");
			}
			Console.WriteLine("\n");
			foreach (Point point in listX)
			{
				Console.Write(point.X + " " + point.Y + "|");
			}
			Console.WriteLine("\n");
			foreach (Point point in listY)
			{
				Console.Write(point.X + " " + point.Y + "|");
			}
		}

		public static double Distance(Point p1, Point p2)
		{
			return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
		}

		public static void ReadFile()
		{
			using (StreamReader sr = new StreamReader(@"points.txt"))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					string[] array = line.Split(' ');
					AddPoint(double.Parse(array[0]), double.Parse(array[1]));
				}
			}
		}

		public static void SaveToFile(int n)
		{
			Random random = new Random(0);
			string line;
			int i;
			line = Math.Round(random.NextDouble()*10000, 2) + " " + Math.Round(random.NextDouble()*10000, 2);
			using (StreamWriter sw = new StreamWriter(@"points.txt"))
			{
				for (i = 0; i < n; i++)
				{
					line = Math.Round(random.NextDouble()*10000, 2) + " " + Math.Round(random.NextDouble()*10000, 2);
					sw.WriteLine(line);
				}
			}
		}


		static void Main(string[] args)
		{
			SaveToFile(10);
			ReadFile();
			SortList();
			PrintList();
			Console.ReadKey();
		}
	}
}