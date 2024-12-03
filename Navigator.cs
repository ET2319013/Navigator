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

		readonly Route[,] x;
		public Navigator() 
		{
			x = new Route[Cities.Length, Cities.Length];
			x[0, 1] = new Route("A5", 103, 100); //Varna-Burgas
			x[1, 0] = new Route("A5", 103, 100); //Burgas-Varna

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
