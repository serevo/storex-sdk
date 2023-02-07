# STOCK-MAN SDK

[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Storex.Core)](https://www.nuget.org/packages/Storex.Core)



STOCK-MAN アプリ (開発コードネーム: Storex [^1]) モジュール開発用 SDK です。

STOCK-MAN やモジュール開発の概要については次のページをご覧ください。

- [STOCK-MAN](https://docs.serevo.net/stockman)
- [モジュール開発 - STOCK-MAN ガイド](https://docs.serevo.net/stockman/modules-dev)



[^1]: コードネームは各種ファイル名やパッケージ名、ソースコードの他、GitHub 等の開発者用向けサービスやリソースのURL にも使用しています。

 

## バージョンと依存関係

- この SDK は [SemVer (セマンティック バージョニング 2.0.0)](https://semver.org/lang/ja/) に則ってバージョニングしています。
- アクセス修飾子が `public` や `protected` な型やメンバについて、変更や削除に加えて抽象メンバやインターフェイスメンバの追加は破壊的変更となります 。このような場合はメジャー番号をインクリメントして他の番号はリセットします。インターフェイスへのメンバの追加はインターフェイス型の追加によって代替します (例えば `IAuthenticatorModule ` + `IAuthenticatorModule2` )。
- アクセス修飾子が `public` や `protected` な型やメンバについて、型や上記以外のメンバの追加は機能追加となります。このような場合はマイナー番号をインクリメントしてビルド番号はリセットします。機能追加でも上記のような破壊的変更でもない場合は ビルド番号 をインクリメントします。
- モジュールで使用可能な SDK のバージョンは、アプリで直接参照する SDK とメジャー番号が同じ且つマイナー番号が同じか低いものとしています。例えばアプリで v1.2.0 が参照されている場合、モジュールで使用可能なのは v1.0.0 以上 v1.3.0 未満です。これを遵守するようにしてください。
- 厳密名は異なるバージョン間で別の型と認識される為、またアプリで バージョンのリダイレクト (バインドリダイレクト) をしない為不可です。



## コードレビュー用 Nuget パッケージ

このリポジトリでは main ブランチへのプルリクエスト時に自動で GitHub Packages に Nuget パッケージが 発行されるよう GitHub Actions を構成しています。発行する Nuget パッケージのバージョンプリフィックスは `0.0.0` とし、サフィックスとして `-pr.{プリリクエスト番号}.{ビルド番号}` としています。



[Storex.Core | GitHub Packages](https://github.com/serevo/storex-sdk/pkgs/nuget/Storex.Core)

[NuGetレジストリの利用 - GitHub Docs](https://docs.github.com/ja/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry)

