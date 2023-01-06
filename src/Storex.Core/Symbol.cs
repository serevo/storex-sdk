using System;
using System.Collections.Generic;

namespace Storex
{
    /// <summary>
    /// 1 次元バーコードや QRコード等の シンボルを表します。
    /// </summary>
    public sealed class Symbol : ILabelSource
    {
        /// <summary>
        /// シンボルの種類。
        /// </summary>
        public SymbolType Type { get; }

        /// <summary>
        /// シンボル化された文字。
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// ロケーション。
        /// </summary>
        public SymbolLocation Location { get; }

        IReadOnlyCollection<Symbol> ILabelSource.Symbols => Array.AsReadOnly(new[] { this });

        internal Symbol(SymbolType type, string value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentOutOfRangeException(nameof(value));

            Type = type;

            Value = value;
        }

        /// <summary>
        /// <see cref="Symbol"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="location"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Symbol(SymbolType type, string value, SymbolLocation location)
            : this(type, value)
        {
            if (location is null)
                throw new ArgumentNullException(nameof(location));

            Location = location;
        }
    }
}