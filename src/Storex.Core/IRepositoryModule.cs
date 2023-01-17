using System;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;

namespace Storex
{
    /// <summary>
    /// データ保管モジュールのインターフェースです。
    /// </summary>
    public interface IRepositoryModule : IModule
    {
        /// <summary>
        /// 動作モード (<see cref="IMode"/>) 設定でこのモジュール用の追加の設定ボタンを有効にします。
        /// </summary>
        bool CanConfigureMode { get; }

        /// <summary>
        /// 動作モード (<see cref="IMode"/>) 設定でこのモジュール用の追加の設定ボタンが押下された場合に呼び出されます。
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        Task ConfigureModeAsync(IMode mode);

        /// <summary>
        /// アプリで ユーザーがモードを指定して操作を開始する際に一度だけ呼び出されます。
        /// </summary>
        /// <param name="mode">選択されたモード。</param>
        /// <param name="user">認証されたユーザー。認証は省略可能な為 <c>null</c> が渡される場合があります。</param>
        /// <returns></returns>
        /// <exception cref="RepositoryModuleException">アプリでエラーメッセージを表示する場合にスローします。</exception>
        Task PrepareAsync(IMode mode, IUser user);

        /// <summary>
        /// 主ラベルを検出して返します。
        /// </summary>
        /// <param name="labelSources">アプリで読み取った <see cref="Symbol"/> と、<see cref="C3Label"/> に変換済みのインスタンス。</param>
        /// <returns></returns>
        ILabel FindPrimaryLabel(ILabelSource[] labelSources);

        /// <summary>
        /// 副ラベルを検出して返します。
        /// </summary>
        /// <param name="primaryLabel"><see cref="FindPrimaryLabel"/>　で検出された主ラベル。</param>
        /// <param name="labelSources">アプリで読み取った <see cref="Symbol"/>と、<see cref="C3Label"/> に変換済みのインスタンス。</param>
        /// <returns></returns>
        ILabel[] FindSecondaryLabels(ILabel primaryLabel, ILabelSource[] labelSources);

        /// <summary>
        /// データを保管・登録します。
        /// </summary>
        /// <param name="primaryLabel"><see cref="FindPrimaryLabel"/>　メソッドで検出された主ラベル。</param>
        /// <param name="secondaryLabel"><see cref="FindSecondaryLabels"/>　メソッドで検出し、ユーザーに確定された副ラベル。</param>
        /// <param name="captureDatas">アプリでワーク (被写体) から収集した全てのデータ。</param>
        /// <param name="tags">アプリでユーザーに指定された追加の文字列。</param>
        /// <returns>成功した場合は <c>true</c>、ユーザーによる再試行が必要な場合は <c>false</c>。</returns>
        /// <exception cref="RepositoryModuleException">失敗した場合にアプリでエラーメッセージを表示する場合にスローします。</exception>
        Task<bool> RegisterAsync(ILabel primaryLabel, ILabel secondaryLabel, CaptureData[] captureDatas, string[] tags);

        /// <summary>
        /// データを保管・登録します。
        /// </summary>
        /// <param name="primaryLabel"><see cref="FindPrimaryLabel"/>　メソッドで検出された主ラベル。</param>
        /// <param name="secondaryLabel"><see cref="FindSecondaryLabels"/>　メソッドで検出し、ユーザーに確定された副ラベル。</param>
        /// <param name="captureDatas">アプリでワーク (被写体) から収集した全てのデータ。</param>
        /// <param name="tags">アプリでユーザーに指定された追加の文字列。</param>
        /// <param name="cancellationToken"></param>
        /// <returns>成功した場合は <c>true</c>、ユーザーによる再試行が必要な場合は <c>false</c>。</returns>
        /// <exception cref="RepositoryModuleException">失敗した場合にアプリでエラーメッセージを表示する場合にスローします。</exception>
        Task<bool> RegisterAsync(ILabel primaryLabel, ILabel secondaryLabel, CaptureData[] captureDatas, string[] tags, CancellationToken cancellationToken);
    }

    /// <summary>
    /// <see cref="IRepositoryModule"/> のメタデータを表します。
    /// 通常、実装クラスでこの型を扱う必要はありません。
    /// </summary>
    public interface IRepositoryModuleMetadata : IModuleMetadata
    {
    }

    /// <summary>
    /// <see cref="IRepositoryModule"/> で正常に処理が終了しない場合にスローしてアプリでエラーメッセージを表示する例外クラスです。
    /// </summary>
    public class RepositoryModuleException : ModuleException
    {
        /// <summary>
        /// <see cref="RepositoryModuleException"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="displayMessage">アプリでエラーメッセージとしてユーザーに表示する文字列。</param>
        public RepositoryModuleException(string displayMessage) : base(displayMessage) { }
    }

    /// <summary>
    /// <see cref="IRepositoryModule"/> をエクスポートします。
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class RepositoryModuleExportAttribute : ModuleExportAttribute
    {
        /// <summary>
        /// <see cref="RepositoryModuleExportAttribute"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="id"><see cref="IRepositoryModule"/> を一意に表す識別子。<see cref="Guid"/> の文字列表現推奨。</param>
        /// <param name="displayName"><see cref="IRepositoryModule"/> の表示名。</param>
        public RepositoryModuleExportAttribute(string id, string displayName)
            : base(typeof(IRepositoryModule), id, displayName)
        {
        }
    }
}
