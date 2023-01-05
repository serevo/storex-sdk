using System;
using System.Collections.Generic;

namespace Storex
{
    /// <summary>
    /// シンボルのロケーションを表します。
    /// </summary>
    public sealed class SymbolLocation
    {
        /// <summary>
        /// 頂点座標。
        /// </summary>
        public IReadOnlyList<PointD> VertexPoints;

        /// <summary>
        /// 反時計回りの回転角度。
        /// </summary>
        public double ValueAngle { get; }

        /// <summary>
        /// <see cref="SymbolLocation"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="vertexPoints"></param>
        /// <param name="valueAngle"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public SymbolLocation(PointD[] vertexPoints, double valueAngle)
        {
            if (vertexPoints is null)
                throw new ArgumentNullException(nameof(vertexPoints));

            if (vertexPoints.Length != 2 & vertexPoints.Length != 4)
                throw new ArgumentOutOfRangeException(nameof(vertexPoints));

            VertexPoints = Array.AsReadOnly(vertexPoints);

            ValueAngle = valueAngle;
        }
    }
}