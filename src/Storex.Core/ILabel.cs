
namespace Storex
{
    /// <summary>
    /// 1 つまたは複数のシンボルで構成される、ワーク (被写体) 上のラベルを表す単位です。
    /// </summary>
    public interface ILabel
    {
        /// <summary>
        /// このラベルを構成するシンボル。
        /// </summary>
        Symbol[] Symbols { get; }

        /// <summary>
        /// アイテムナンバー (型番、型式、型名、品番 等)。
        /// </summary>
        string ItemNumber { get; }

        /// <summary>
        /// シリアルナンバー (連番、ロット 等)。
        /// </summary>
        string SerialNumber { get; }
    }
}
