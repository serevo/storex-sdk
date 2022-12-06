using System;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Storex
{
    /// <summary>
    /// <see cref="IModule"/> をエクスポートします。
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public abstract class ModuleExportAttribute : ExportAttribute
    {
        /// <summary>
        /// <see cref="IModule"/> を一意に表す識別子。<see cref="Guid"/> の文字列表現推奨。
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// <see cref="IModule"/> の表示名。
        /// </summary>
        public string DisplayName { get; }

        string description;
        /// <summary>
        /// <see cref="IModule"/> を説明する補足情報。
        /// </summary>
        [DefaultValue("")]
        public string Description
        {
            get => description;
            set
            {
                description = value ?? throw new ArgumentNullException(nameof(value));

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        /// <summary>
        /// <see cref="ModuleExportAttribute"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="contractType">コントラクトの型。</param>
        /// <param name="id"><see cref="IModule"/> を一意に表す識別子。<see cref="Guid"/> の文字列表現推奨。</param>
        /// <param name="displayName"><see cref="IModule"/> の表示名。</param>
        protected ModuleExportAttribute(Type contractType, string id, string displayName)
            : base(contractType)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));

            DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));

            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentOutOfRangeException(nameof(id));

            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentOutOfRangeException(nameof(displayName));
        }
    }
}
