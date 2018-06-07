using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

namespace CoxeterGroup
{
    public sealed class Mirror
    {
        internal Vector Normal;

        public float[] NormalArray
        {
            get { return Normal.ToArray(); }
            set { Normal = new DenseVector(value); }
        }

        public Mirror(float[] normal)
        {
            Normal = new DenseVector(normal);
        }

        public Mirror Reflect(Mirror tobeReflected)
        {
            var T=Space.I
        }

        internal Vector<float> ReflectPos(Vector<float> pointToReflect)
        {
            throw new Exception();
        }

    }
}