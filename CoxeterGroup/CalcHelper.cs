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
		public static int Dimension;	// which dimension to calculate
		public static Matrix<float> IPMatrix;	// inner product matrix

		static CalcHelper()
		{
			Dimension = 3;
			SetAsEuclidean();
		}

		public static void SetAsEuclidean()
		{
			IPMatrix = Matrix.Build.DenseIdentity(Dimension);
			IPMatrix[Dimension - 1, Dimension - 1] = 0;
		}
		public static void SetAsSpherical()
		{
			IPMatrix = Matrix.Build.DenseIdentity(Dimension);
		}
		public static void SetAsHyperbolical()
		{
			IPMatrix = Matrix.Build.DenseIdentity(Dimension);
			IPMatrix[Dimension - 1, Dimension - 1] = -1;
		}
	}
}
