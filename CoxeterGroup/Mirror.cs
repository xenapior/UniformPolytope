using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

namespace CoxeterGroup
{
	public sealed class Mirror
	{
		public Vector Normal;

		public Mirror(float[] normal)
		{
			Normal = new DenseVector(normal);
		}

		public Mirror Reflect(Mirror tobeReflected)
		{
			//TODO: add inner product matrix
			throw new System.NotImplementedException();
		}

        public Vector<float> Reflect(Vector<float> pointToReflect)
        {
            throw new Exception();
        } 
	}
}