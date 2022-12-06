using System;

namespace Storex
{
    internal struct PointD : IEquatable<PointD>
    {
        public double X { get; set; }

        public double Y { get; set; }

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        #region 等値演算

        public override bool Equals(object obj) => obj is PointD d && Equals(d);

        public bool Equals(PointD other) => X == other.X && Y == other.Y;

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(PointD left, PointD right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PointD left, PointD right)
        {
            return !(left == right);
        }

        #endregion
    }
}
