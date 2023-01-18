using System;

namespace Storex
{
    /// <summary>
    /// <see cref="IModule"/> で正常に処理が終了しない場合にスローしてアプリでエラーメッセージを表示する例外の基底クラスです。
    /// </summary>
    public abstract class ModuleException : Exception
    {
        /// <summary>
        /// <see cref="ModuleException"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="displayMessage">アプリでエラーメッセージとしてユーザーに表示する文字列。</param>
        protected ModuleException(string displayMessage) : base(displayMessage) { }
    }
}
