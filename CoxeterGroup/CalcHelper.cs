using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

namespace CoxeterGroup
{
	public static class CalcHelper
	{
		public static int Dimension;	// Affin space dim to calculate. Euclidean is calculated with +1 dim.
		public static Matrix<float> MP;	// inner product matrix

		static CalcHelper()
		{
			Dimension = 3;
			SetAsSpherical();
		}

		public static void SetAsEuclidean()
		{
			MP = Matrix.Build.DenseIdentity(Dimension);
			MP[Dimension - 1, Dimension - 1] = 0;
		}
		public static void SetAsSpherical()
		{
			MP = Matrix.Build.DenseIdentity(Dimension);
		}
		public static void SetAsHyperbolical()
		{
			MP = Matrix.Build.DenseIdentity(Dimension);
			MP[Dimension - 1, Dimension - 1] = -1;
		}

	    public static float InnerProduct(Vector<float> v1, Vector<float> v2)
	    {
	        var res = v1.ToRowMatrix()*MP*v2.ToColumnMatrix();
	        return res[0, 0];
	    }
	}
}
