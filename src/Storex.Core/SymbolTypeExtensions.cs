namespace Storex
{
    /// <summary>
    /// <see cref="SymbolType"/> 用の拡張メソッドを定義します。
    /// </summary>
    public static class SymbolTypeExtensions
    {
        /// <summary>
        /// 指定されたシンボルの種類が 1次元コードかどうかを返します。
        /// </summary>
        /// <param name="symbolType">シンボルの種類。</param>
        /// <returns></returns>
        public static bool Is1D(this SymbolType symbolType) => symbolType != SymbolType.Unknown & ((int)symbolType & 1) == 1;

        /// <summary>
        /// 指定されたシンボルの種類が 2次元コードかどうかを返します。
        /// </summary>
        /// <param name="symbolType">シンボルの種類。</param>
        /// <returns></returns>
        public static bool Is2D(this SymbolType symbolType) => symbolType != SymbolType.Unknown & ((int)symbolType & 1) == 0;
    }
}
