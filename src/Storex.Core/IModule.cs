﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Storex
{
    /// <summary>
    /// 各モジュールの共通インターフェースです。
    /// </summary>
    public interface IModule : IDisposable
    {
        /// <summary>
        /// アプリでモジュール用設定ボタンを有効にします。
        /// </summary>
        bool IsConfiguable { get; }

        /// <summary>
        /// アプリでモジュール用設定ボタンが押下された場合に呼び出されます。
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ConfigureAsync(CancellationToken cancellationToken);
    }
}
