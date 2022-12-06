using System.Collections.Generic;

namespace Storex
{
    /// <summary>
    /// 読み取ったシンボルと、それらのシンボルから構成される C-3 等のラベルを統一して扱うインタフェースです。
    /// </summary>
    public interface ILabelSource
    {
        /// <summary>
        /// 読み取ったシンボル 。
        /// </summary>
        IReadOnlyCollection<Symbol> Symbols { get; }
    }
}