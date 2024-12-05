using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routes
{
	internal class Navigator
	{
		public static readonly string[] Cities = {
			"Varna",			//0
			"Burgas",			//1 
			"Dobrich",			//2
			"Silistra",			//3
			"Razgrad",			//4 
			"Tyrgowishte",		//5 
			"Shumen",			//6
			"Veliko Trynovo",	//7 
			"Sliven",			//8
			"Yambol",			//9
			"Kazanlyk",			//10
			"Stara Zagora" };   //11

		//readonly Route[,] x;
		private List<Tuple<int, Route>>[] adjList;
		readonly int vertices;



	public Navigator() 
		{
			//x = new Route[Cities.Length, Cities.Length];
			vertices = Cities.Length;
			adjList = new List<Tuple<int, Route>>[vertices];
			for (int i = 0; i < vertices; i++)
			{
				adjList[i] = new List<Tuple<int, Route>>();
			}
			AddRoute(0, 1, "A5", 131.5, 100); //Varna Section
            AddRoute(0, 2, "A5", 51.8, 100); 
            AddRoute(0, 3, "A5", 141, 100); 
            AddRoute(0, 4, "A5", 128, 100); 
            AddRoute(0, 5, "A5", 121, 100); 
            AddRoute(0, 6, "A5", 88.8, 100);
            AddRoute(0, 7, "A5", 222, 100); 
            AddRoute(0, 8, "A5", 221, 100); 
            AddRoute(0, 9, "A5", 209, 100); 
            AddRoute(0, 10, "A5", 303, 100); 
            AddRoute(0, 11, "A5", 288, 100);
										
            AddRoute(1, 2, "A5", 179, 100); //Burgas Section
            AddRoute(1, 3, "A5", 228, 100);
            AddRoute(1, 4, "A5", 179, 100);
            AddRoute(1, 5, "A5", 149, 100);
            AddRoute(1, 6, "A5", 126, 100);
            AddRoute(1, 7, "A5", 216, 100);
            AddRoute(1, 8, "A5", 114, 100);
            AddRoute(1, 9, "A5", 93.4, 100);
            AddRoute(1, 10, "A5", 190, 100);
            AddRoute(1, 11, "A5", 172, 100);

            AddRoute(2, 3, "A5", 89.7, 100); //Dobrich Section
            AddRoute(2, 4, "A5", 140, 100);
            AddRoute(2, 5, "A5", 133, 100);
            AddRoute(2, 6, "A5", 125, 100);
            AddRoute(2, 7, "A5", 257, 100);
            AddRoute(2, 8, "A5", 247, 100);
            AddRoute(2, 9, "A5", 245, 100);
            AddRoute(2, 10, "A5", 328, 100);
            AddRoute(2, 11, "A5", 324, 100);

            AddRoute(3, 4, "A5", 115, 100); //Silistra Section
            AddRoute(3, 5, "A5", 140, 100);
            AddRoute(3, 6, "A5", 113, 100);
            AddRoute(3, 7, "A5", 229, 100);
            AddRoute(3, 8, "A5", 250, 100);
            AddRoute(3, 9, "A5", 245, 100);
            AddRoute(3, 10, "A5", 245, 100);
            AddRoute(3, 11, "A5", 324, 100);

            AddRoute(4, 5, "A5", 37.7, 100); //Razgrad Section
            AddRoute(4, 6, "A5", 48, 100);
            AddRoute(4, 7, "A5", 114, 100);
            AddRoute(4, 8, "A5", 148, 100);
            AddRoute(4, 9, "A5", 161, 100);
            AddRoute(4, 10, "A5", 201, 100);
            AddRoute(4, 11, "A5", 217, 100);

            AddRoute(5, 6, "A5", 41, 100); //Tyrgowishte Section
            AddRoute(5, 7, "A5", 99.6, 100);
            AddRoute(5, 8, "A5", 112, 100);
            AddRoute(5, 9, "A5", 126, 100);
            AddRoute(5, 10, "A5", 196, 100);
            AddRoute(5, 11, "A5", 205, 100);

            AddRoute(6, 7, "A5", 142, 100); //Shumen Section
            AddRoute(6, 8, "A5", 133, 100);
            AddRoute(6, 9, "A5", 131, 100);
            AddRoute(6, 10, "A5", 217, 100);
            AddRoute(6, 11, "A5", 200, 100);

            AddRoute(7, 8, "A5", 112, 100); //Veliko Tyrnovo Section
            AddRoute(7, 9, "A5", 130, 100);
            AddRoute(7, 10, "A5", 90, 100);
            AddRoute(7, 11, "A5", 106, 100);

            AddRoute(8, 9, "A5", 28, 100); //Sliven Section
            AddRoute(8, 10, "A5", 86, 100);
            AddRoute(8, 11, "A5", 70, 100);

            AddRoute(9, 10, "A5", 105, 100); //Yambol Section
            AddRoute(9, 11, "A5", 83, 100);

            AddRoute(10, 11, "A5", 33, 100); //Kazanlak

        }

		public void AddRoute(int u, int v, string name, double dist, double speed)
		{
			var route = new Route(name, dist, speed);
			adjList[u].Add(new Tuple<int, Route>(v, route));
			var route_back = new Route(name, dist, speed);
			adjList[v].Add(new Tuple<int, Route>(u, route_back)); 
			// Для направленного графа уберите эту строку.
		}

		public string Dijkstra(int source, int target)
		{
			double[] distances = new double[vertices];
			bool[] visited = new bool[vertices];
			int[] previous = new int[vertices];

			for (int i = 0; i < vertices; i++)
			{
				distances[i] = int.MaxValue;
				visited[i] = false;
				previous[i] = -1;
			}

			distances[source] = 0;
			PriorityQueue<int, double> pq = new PriorityQueue<int, double>();
			pq.Enqueue(source, 0);

			while (pq.Count > 0)
			{
				int u = pq.Dequeue();

				if (u == target) break; // Мы достигли целевой вершины.

				if (visited[u])
					continue;

				visited[u] = true;

				foreach (var neighbor in adjList[u])
				{
					int v = neighbor.Item1;
					double weight = neighbor.Item2.Time;

					if (!visited[v] && distances[u] + weight < distances[v])
					{
						distances[v] = distances[u] + weight;
						previous[v] = u;
						pq.Enqueue(v, distances[v]);
					}
				}
			}

			return GetPath(previous, source, target, distances[target]);
		}

		private string GetPath(int[] previous, int source, int target, double distance)
		{
			List<string> paths = new List<string>();
			//List<int> path = new List<int>();
			for (int at = target; at != -1; at = previous[at])
			{
				paths.Insert(0, Cities[at]);
				//path.Add(at);
			}
			//path.Reverse();
			if (paths.Count > 0 && paths[0] == Cities[source])
				return String.Join("-", paths) + " " + distance.ToString() + "km";
			else
				return "No way found"; // Путь не найден.
		}
	}
	internal class Route
	{

		

		private Route() { }
		
		public Route(string name, double distance, double speed) {  
			_name = name; 
			_distance = distance;	
			_speed = speed;
		
		}
	
		private string _name = string.Empty;
		private double _distance = 0;
		private double _speed = 0;

		public string Name { 
			get { return _name; }
			set { _name = value; }
		}
		public double Distance { 
			get { return _distance; } 
			set { _distance = value; }
		}	
		public double Speed { 
			get { return _speed; } 
			set { _speed = value; }
		}
		public double Time { 
			get
			{
				if (_distance > 0 && _speed > 0)
				{
					return _distance / _speed;
				}
				else
				{
					return 0;
				}
			} 
		}
	}
}
