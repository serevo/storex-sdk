using System;

namespace Storex
{
    /// <summary>
    /// <see cref="IModule"/> で正常に処理が終了しない場合にスローしてアプリでエラーメッセージを表示する例外の基底クラスです。
    /// </summary>
    public abstract class ModuleException : Exception
    {
        /// <summary>
        /// アプリでエラーメッセージとしてユーザーに表示する文字列。
        /// </summary>
        public string DisplayMessage { get; }

        /// <summary>
        /// <see cref="ModuleException"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="displayMessage">アプリでエラーメッセージとしてユーザーに表示する文字列。</param>
        /// <param name="exceptionMessage"><see cref="Exception.Message"/> を指定。省略された場合は <paramref name="displayMessage"/> が使用されます。</param>
        protected ModuleException(string displayMessage, string exceptionMessage = null)
            : base(exceptionMessage ?? displayMessage)
        {
            DisplayMessage = displayMessage;
        }
    }
}
