
namespace Storex
{
    /// <summary>
    /// <see cref="IAuthenticationModule"/> で認証されるユーザーを表します。
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// アプリに表示される名前。
        /// </summary>
        string DisplayName { get; }
    }
}
