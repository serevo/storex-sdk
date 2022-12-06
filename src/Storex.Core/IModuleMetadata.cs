using System;
using System.ComponentModel;

namespace Storex
{
    /// <summary>
    /// <see cref="IModule"/> 用の共通のメタデータを表します。
    /// </summary>
    public interface IModuleMetadata
    {
        /// <summary>
        /// <see cref="IModule"/> を一意に表す識別子。<see cref="Guid"/> の文字列表現推奨。
        /// </summary>
        string Id { get; }

        /// <summary>
        /// <see cref="IModule"/> の表示名。
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// <see cref="IModule"/> を説明する補足情報。
        /// </summary>
        [DefaultValue("")]
        string Description { get; }
    }
}
