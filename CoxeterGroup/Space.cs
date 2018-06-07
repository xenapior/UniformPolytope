using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

namespace CoxeterGroup
{
	public static class Space
	{
		public static int Dimension;	// Affin space dim to calculate. Euclidean is calculated with +1 dim.
		public static Matrix<float> M;	// inner product matrix
	    public static Matrix<float> I;  //Identity Matrix 

		static Space()
		{
			Dimension = 3;
            M = Matrix.Build.DenseIdentity(Dimension);
            I = Matrix.Build.DenseIdentity(Dimension);
        }

        public static void SetAsEuclidean()
		{
			M[Dimension - 1, Dimension - 1] = 0;
		}
		public static void SetAsSpherical()
		{
            M[Dimension - 1, Dimension - 1] = 1;
        }
        public static void SetAsHyperbolical()
		{
			M[Dimension - 1, Dimension - 1] = -1;
		}

	    public static float InnerProduct(Vector<float> v1, Vector<float> v2)
	    {
	        var res = v1.ToRowMatrix()*M*v2.ToColumnMatrix();
	        return res[0, 0];
	    }

	}
}
