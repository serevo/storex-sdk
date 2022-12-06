namespace Storex
{
    /// <summary>
    /// シンボルの種類を表します。
    /// 1次元は奇数値, 2次元は偶数値になっています。
    /// </summary>
    public enum SymbolType : byte
    {
        /// <summary>
        /// アプリで定義されていない種類。
        /// </summary>
        Unknown = 0x00,
        /// <summary>
        /// CODE39
        /// </summary>
        Code39 = 0x01,
        /// <summary>
        /// CODE128
        /// </summary>
        Code128 = 0x03,
        /// <summary>
        /// QRコード
        /// </summary>
        QrCode = 0x02,
        /// <summary>
        /// DataMatrix
        /// </summary>
        DataMatrix = 0x04,
    }
}