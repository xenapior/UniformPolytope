using System;
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
            pos = pos.Normalize(2);
        }


		public FundamentalRegion[] ReflectAll()
		{
			FundamentalRegion[] newRegions=new FundamentalRegion[boundary.Length];
			for (int i = 0; i < boundary.Length; i++)
			{
				newRegions[i] = ReflectInMirror(i);
			}

			return newRegions;
		}

	    public Vector<float>[] ReflectPositions()
	    {
	        Vector<float>[] newPos = new Vector<float>[boundary.Length];
            for (int i = 0; i < boundary.Length; i++)
            {
                newPos[i] = boundary[i].Reflect(pos);
            }

            return newPos;
	    }

	    public FundamentalRegion ReflectInMirror(int mirrorId)
		{
			Mirror[] newBoundary = new Mirror[boundary.Length];
	        Mirror m = boundary[mirrorId];
			for (int i = 0; i < boundary.Length; i++)
			{
				newBoundary[i] = m.Reflect(boundary[i]);
			}
			return new FundamentalRegion(newBoundary);
		}
	}
}
