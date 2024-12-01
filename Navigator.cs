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

		Route[,] x;
		public Navigator() 
		{
			x = new Route[Cities.Length, Cities.Length];
		}

		public double Calc(int from, int to)
		{
			return 0;
		}
	}
	internal class Route
	{

		

		private Route() { }
		
		public Route(string name, double distance, double speed) {  
			_name = name; 
			_distance = distance;	
			_speed = speed;
			_time = distance / speed;
		}
	
		private readonly string _name = string.Empty;
		private readonly double _distance = 0;
		private readonly double _speed = 0;
		private readonly double _time = 0; //must be != 0

		public string Name { get { return _name; } }
		public double Distance { get { return _distance; } }	
		public double Speed { get { return _speed; } }
		public double Time { get { return _time; } }
	}
}
