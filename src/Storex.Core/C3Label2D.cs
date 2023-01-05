using System;
using System.Collections.Generic;
using System.Linq;

namespace Storex
{
    /// <summary>
    /// 2 次元シンボルの C-3 ラベルを表します。
    /// </summary>
    public sealed class C3Label2D : C3Label
    {
        /// <summary>
        /// 有効なシンボルの種類。
        /// </summary>
        public static readonly IReadOnlyCollection<SymbolType> ValidSymbolTypes = Array.AsReadOnly(new[]
        {
            SymbolType.QrCode,
        });

        /// <summary>
        /// この C-3 ラベルの元となったシンボル。
        /// </summary>
        public Symbol Symbol { get; }

        /// <summary>
        /// この C-3 ラベルの元となったシンボルの種類。
        /// </summary>
        public override SymbolType SymbolType => Symbol.Type;

        internal override Symbol[] GetSymbols() => new[] { Symbol };

        internal C3Label2D(Symbol symbol, string partNumber, int? quantity, string serialNumber, string venderCode, string venderPartNumber)
            : base(partNumber, quantity, serialNumber, venderCode, venderPartNumber)
        {
            Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol));

            if (!ValidSymbolTypes.Contains(symbol.Type))
                throw new ArgumentOutOfRangeException(nameof(symbol));
        }
    }
}
