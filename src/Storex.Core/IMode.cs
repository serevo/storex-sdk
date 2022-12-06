using System;
using System.Collections.Generic;

namespace Storex
{
    /// <summary>
    /// アプリの動作モードを表します。主にワーク (被写体) 上のシンボルやラベル仕様を定義します。
    /// </summary>
    public interface IMode
    {
        /// <summary>
        /// モードを一意に表す識別子。
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// 動作モードに対し、主にデータ保管モジュールで構成した内容を格納するための追加の属性です。
        /// Newtonsoft.Json ライブラリでシリアル化できる様にしてください。
        /// </summary>
        IDictionary<string, object> ExtendedProperties { get; }
    }
}