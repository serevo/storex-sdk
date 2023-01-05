using System;
using System.Collections.Generic;

namespace Storex
{
    /// <summary>
    /// C-3ラベル (http://ec.jeita.or.jp/jp/uploads/c3label.pdf )を表します。
    /// </summary>
    public abstract class C3Label : ILabel, ILabelSource
    {
        /// <summary>
        /// 発注者品名コード。必須です。
        /// </summary>
        public string PartNumber { get; }

        /// <summary>
        /// 入数。この項目は以前は必須でしたが改定により必須ではなくなりました。
        /// </summary>
        public int? Quantity { get; }

        /// <summary>
        /// シリアルNo. 。
        /// </summary>
        public string SerialNumber { get; }

        /// <summary>
        /// 受注者コード。
        /// </summary>
        public string VenderCode { get; }

        /// <summary>
        /// 受注者品名コードを取得します。
        /// </summary>
        public string VenderPartNumber { get; }

        /// <summary>
        /// シンボルの種類。
        /// </summary>
        public abstract SymbolType SymbolType { get; }

        internal abstract Symbol[] GetSymbols();

        IReadOnlyCollection<Symbol> ILabelSource.Symbols => GetSymbols();

        string ILabel.ItemNumber => PartNumber;

        Symbol[] ILabel.Symbols => GetSymbols();

        internal C3Label(string partNumber, int? quantity, string serialNumber, string venderCode, string venderPartNumber)
        {
            PartNumber = partNumber ?? throw new ArgumentNullException(nameof(partNumber));
            Quantity = quantity;
            SerialNumber = serialNumber;
            VenderCode = venderCode;
            VenderPartNumber = venderPartNumber;
        }
    }
}