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
			AddRoute(0, 1, "A5", 103, 100); //Varna-Burgas & Burgas-Varna
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
			double[] times = new double[vertices];
			bool[] visited = new bool[vertices];
			int[] previous = new int[vertices];

			for (int i = 0; i < vertices; i++)
			{
				times[i] = int.MaxValue;
				visited[i] = false;
				previous[i] = -1;
			}

			times[source] = 0;
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

					if (!visited[v] && times[u] + weight < times[v])
					{
						times[v] = times[u] + weight;
						previous[v] = u;
						pq.Enqueue(v, times[v]);
					}
				}
			}

			return GetPath(previous, source, target, times[target]);
		}

		private string GetPath(int[] previous, int source, int target, double time)
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
				return String.Join("-", paths) + ", " + time.ToString() + "hours";
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
