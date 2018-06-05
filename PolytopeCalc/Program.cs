using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoxeterGroup;

using con=System.Console;

namespace PolytopeCalc
{
	class Program
	{
		static void Main(string[] args)
		{
		    Mirror[] ms = {new Mirror(new float[] {1, 2, 3}), new Mirror(new float[] {0, 1, 0})};
		    FundamentalRegion reg = new FundamentalRegion(ms);


			con.ReadKey();
		}
	}
}
