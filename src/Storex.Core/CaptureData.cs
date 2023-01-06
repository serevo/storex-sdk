using System;
using System.Collections.Generic;
using System.Linq;

namespace Storex
{
    /// <summary>
    /// 撮影した画像や読み取ったシンボル等のデータのセットを表します。
    /// </summary>
    public sealed class CaptureData
    {
        /// <summary>
        /// 撮影したオリジナルの画像。
        /// </summary>
        public IReadOnlyList<byte> OriginalImage { get; }

        /// <summary>
        /// シンボル位置等を示す装飾が追加された画像。
        /// </summary>
        public IReadOnlyList<byte> AdornedImage { get; }

        /// <summary>
        /// 読み取った<see cref="Symbol"/> と、<see cref="C3Label"/> に変換済みのインスタンス。
        /// </summary>
        public IReadOnlyList<ILabelSource> LabelSources { get; }

        /// <summary>
        /// <see cref="CaptureData"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="originalImage"><see cref="OriginalImage"/></param>
        /// <param name="labelSources"><see cref="LabelSources"/></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CaptureData(IReadOnlyList<byte> originalImage, IReadOnlyList<ILabelSource> labelSources)
        {
            OriginalImage = originalImage ?? throw new ArgumentNullException(nameof(originalImage));

            LabelSources = labelSources ?? throw new ArgumentNullException(nameof(labelSources));

            if (labelSources.Any(o => o is null))
                throw new ArgumentOutOfRangeException(nameof(labelSources));
        }

        /// <summary>
        /// <see cref="CaptureData"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="originalImage"></param>
        /// <param name="adornedImage"></param>
        /// <param name="labelSources"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CaptureData(IReadOnlyList<byte> originalImage, IReadOnlyList<byte> adornedImage, IReadOnlyList<ILabelSource> labelSources)
            : this(originalImage, labelSources)
        {
            AdornedImage = adornedImage ?? throw new ArgumentNullException(nameof(adornedImage));
        }
    }
}
