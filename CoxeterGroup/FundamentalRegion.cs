using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

namespace CoxeterGroup
{
	public sealed class FundamentalRegion
	{
		public static float Tolerance = float.Epsilon*100;

		private Mirror[] boundary;
		private Vector<float> pos;	//Used to identify the region


		public FundamentalRegion(Mirror[] mirrors, float[] markerPos=null)
		{
			int dim = mirrors[0].Normal.Count;
			boundary = mirrors;
			if (markerPos == null)
			{
				pos = new DenseVector(dim);
				foreach (Mirror m in mirrors)
				{
					pos+=m.Normal;
				}
			}
			else
			{
				Debug.Assert(dim == markerPos.Length);
				pos = new DenseVector(markerPos);
			}
		}

		/// <summary>
		/// Reflect this region in all mirrors.
		/// </summary>
		/// <returns></returns>
		public FundamentalRegion[] ReflectAll()
		{
			FundamentalRegion[] newRegions=new FundamentalRegion[boundary.Length];
			for (int i = 0; i < boundary.Length; i++)
			{
				newRegions[i] = ReflectInMirror(boundary[i]);
			}

			return newRegions;
		}

		private FundamentalRegion ReflectInMirror(Mirror mirror)
		{
			Mirror[] newBoundary = new Mirror[boundary.Length];
			for (int i = 0; i < boundary.Length; i++)
			{
				newBoundary[i] = mirror.Reflect(boundary[i]);
			}
			return new FundamentalRegion(newBoundary);
		}
	}
}
