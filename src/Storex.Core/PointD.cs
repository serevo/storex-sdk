using System;

namespace Storex
{
    /// <summary>
    /// 二次元座標を表します。
    /// </summary>
    public struct PointD : IEquatable<PointD>
    {
        /// <summary>
        /// X 座標を取得または設定します。
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y 座標を取得または設定します。
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// <see cref="PointD"/> 構造体の新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="x"><see cref="X"/></param>
        /// <param name="y"><see cref="Y"/></param>
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        #region 等値演算

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => obj is PointD d && Equals(d);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(PointD other) => X == other.X && Y == other.Y;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(PointD left, PointD right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(PointD left, PointD right)
        {
            return !(left == right);
        }

        #endregion
    }
}
