using System;
using System.Collections.Generic;
using System.Linq;

namespace Storex
{
    internal sealed class SymbolLocation : IEquatable<SymbolLocation>
    {
        public IReadOnlyList<PointD> VertexPoints;

        /// <summary>
        /// 文字の読める向きを0度とし反時計回りの角度とする
        /// </summary>
        public double ValueAngle { get; }

        public SymbolLocation(PointD[] vertexPoints, double valueAngle)
        {
            //四角形のみ対象
            if (vertexPoints.Length != 4)
                throw new InvalidOperationException();

            VertexPoints = Array.AsReadOnly(vertexPoints);

            ValueAngle = valueAngle;
        }

        #region 等値演算

        public override bool Equals(object obj) => Equals(obj as SymbolLocation);

        public bool Equals(SymbolLocation other) => !(other is null)
            && ((VertexPoints is null) & (other.VertexPoints is null) || Enumerable.SequenceEqual(VertexPoints, other.VertexPoints))
            && ValueAngle == other.ValueAngle;

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = -1844779044;
                hashCode = hashCode * -1521134295 + VertexPoints?.Where(e => e != null).Select(e => e.GetHashCode()).Aggregate(17, (a, b) => 23 * a + b) ?? 0;
                hashCode = hashCode * -1521134295 + ValueAngle.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}