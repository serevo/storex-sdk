
namespace Storex
{
    /// <summary>
    /// <see cref="ILabel"/> の基本的な実装クラスです。
    /// </summary>
    public class BasicLabel : ILabel
    {
        /// <summary>
        /// このラベルを構成する <see cref="Symbol"/>。
        /// </summary>
        public Symbol[] Symbols { get; set; }

        /// <summary>
        /// アイテムナンバー (型番、型式、型名、品番 等)。
        /// </summary>
        public string ItemNumber { get; set; }

        /// <summary>
        /// シリアルナンバー (連番、ロット 等)。
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// <see cref="BasicLabel"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="symbols"><see cref="ILabel"/> を構成する <see cref="Symbol"/>。</param>
        public BasicLabel(params Symbol[] symbols)
        {
            Symbols = symbols;
        }
    }
}