using System;
using System.Collections.Generic;
using System.Linq;

namespace Storex
{
    /// <summary>
    /// 1 次元シンボルの C-3 ラベルを表します。
    /// </summary>
    public sealed class C3Label1D : C3Label
    {
        /// <summary>
        /// 有効なシンボルの種類。
        /// </summary>
        public static readonly IReadOnlyCollection<SymbolType> ValidSymbolTypes = Array.AsReadOnly(new[]
        {
            SymbolType.Code39,
            SymbolType.Code128
        });

        /// <summary>
        /// この C-3 ラベルの元となったシンボル。
        /// </summary>
        public IReadOnlyList<Symbol> Symbols { get; }

        /// <summary>
        /// この C-3 ラベルの元となったシンボルの種類。
        /// </summary>
        public override SymbolType SymbolType { get; }

        internal override Symbol[] GetSymbols() => Symbols.ToArray();

        internal C3Label1D(IReadOnlyList<Symbol> symbols, string partNumber, int? quantity, string serialNumber, string venderCode, string venderPartNumber)
            : base(partNumber, quantity, serialNumber, venderCode, venderPartNumber)
        {
            Symbols = symbols ?? throw new ArgumentNullException(nameof(symbols));

            if (symbols.Any(o => o is null))
                throw new ArgumentOutOfRangeException(nameof(symbols), "null が含まれています。");

            var symbolTypes = Symbols
                .Select(o => o.Type)
                .Distinct()
                .ToArray();

            if (symbolTypes.Length != 1 || !ValidSymbolTypes.Contains(symbolTypes[0]))
                throw new ArgumentOutOfRangeException(nameof(symbols));

            SymbolType = symbolTypes.Single();
        }
    }
}