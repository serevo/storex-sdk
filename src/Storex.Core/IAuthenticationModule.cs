﻿using System;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;

namespace Storex
{
    /// <summary>
    /// ユーザー認証モジュールのインタフェースです。
    /// </summary>
    public interface IAuthenticationModule : IModule
    {
        /// <summary>
        /// モジュールでユーザー認証を実施します。
        /// </summary>
        /// <returns></returns>
        Task<IUser> AuthenticateAsync();

        /// <summary>
        /// モジュールでユーザー認証を実施します。
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IUser> AuthenticateAsync(CancellationToken cancellationToken);
    }

    /// <summary>
    /// <see cref="IAuthenticationModule"/> のメタデータを表します。
    /// 通常、実装クラスでこの型を扱う必要はありません。
    /// </summary>
    public interface IAuthenticationModuleMetadata : IModuleMetadata
    {
    }

    /// <summary>
    /// <see cref="IAuthenticationModule"/> で正常に処理が終了しない場合にスローしてアプリでエラーメッセージを表示する例外クラスです。
    /// </summary>
    public class AuthenticationModuleException : ModuleException
    {
        /// <summary>
        /// <see cref="AuthenticationModuleException"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="displayMessage">アプリでエラーメッセージとしてユーザーに表示する文字列。</param>
        /// <param name="exceptionMessage"><see cref="Exception.Message"/> を指定。省略された場合は <paramref name="displayMessage"/> が使用されます。</param>
        public AuthenticationModuleException(string displayMessage, string exceptionMessage = null) : base(displayMessage, exceptionMessage) { }
    }

    /// <summary>
    /// <see cref="IAuthenticationModule"/> をエクスポートします。
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class AuthenticationModuleExportAttribute : ModuleExportAttribute
    {
        /// <summary>
        /// <see cref="AuthenticationModuleExportAttribute"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="id"><see cref="IAuthenticationModule"/> を一意に表す識別子。<see cref="Guid"/> の文字列表現推奨。</param>
        /// <param name="displayName"><see cref="IAuthenticationModule"/> の表示名。</param>
        public AuthenticationModuleExportAttribute(string id, string displayName)
            : base(typeof(IAuthenticationModule), id, displayName)
        {
        }
    }
}
