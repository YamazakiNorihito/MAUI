
プロジェクトでは、以下の項目に注意してください。

- Resources フォルダには、すべてのプラットフォームで使用される共有フォント、画像、およびアセットが含まれています。
- MauiProgram.csファイルには、アプリを構成するコードと、アプリケーションを実行するためにAppクラスを使用することを指定するコードが含まれています。
- App.xaml.csファイルは、AppクラスのコンストラクタがAppShellクラスの新しいインスタンスを作成し、アプリケーションウィンドウに表示されます。
- AppShell.xamlファイルには、アプリケーションのメインレイアウトとMainPageの開始ページが含まれています。
- MainPage.xamlファイルは、ページのレイアウトを含んでいます。このレイアウトには、Click meというキャプションを持つボタンのXAMLコードと、dotnet_bot.pngファイルを表示する画像が含まれています。他にも、2つのラベルがあります。
- MainPage.xaml.csファイルには、このページのアプリケーション・ロジックが含まれています。具体的には、MainPageクラスには、ユーザーがClick meボタンをタップしたときに実行されるOnCounterClickedという名前のメソッドが含まれています。


MAUIアプリで使用される一般的な型のほとんどは、Microsoft.Maui.DependenciesとMicrosoft.Maui.Extensionsパッケージにあります。


コード内でイベントハンドラを作成するには、+=演算子を使用してイベントを購読します。この操作は、通常、ページのコンストラクタでInitializeComponentを呼び出した後に実行します。
```C#
public partial class MainPage : ContentPage, IPage
{
    public MainPage()
    {
        InitializeComponent();
        Counter.Clicked += OnCounterClicked;
    }

    ...

    private void OnCounterClicked(object sender, EventArgs e)
    {
        ...
    }
}
```
この方法を使うと、同じイベントに対して複数のイベント処理メソッドをサブスクライブすることができます。各イベント処理メソッドはイベントが発生したときに実行されますが、特定の順序で実行されることを想定していないため、それらの間に依存関係を導入しないようにしましょう。




ネットワーク接続の検出
.NET MAUIアプリでネットワーク接続を確認するには、Connectivityクラスを使用します。このクラスは、NetworkAccessというプロパティとConnectivityChangedというイベントを公開しています。これらのメンバを使用して、ネットワークの変化を検出することができます。

NetworkAccessプロパティには、Currentという別のプロパティを通してアクセスします。これは、Connectivity がプラットフォーム固有の実装にアクセスするために取る仕組みです。

NetworkAccess プロパティは、NetworkAccess 列挙型からの値を返します。この列挙には、5つの値があります： この列挙には、ConstrainedInternet、Internet、Local、None、および Unknown の 5 つの値があります。NetworkAccessプロパティがNetworkAccess.Noneの値を返す場合、インターネットへの接続がないことを意味し、ネットワークコードを実行してはいけません。この仕組みは、プラットフォーム間で移植可能です。次のコードは、その例を示しています：

```c#
if (Connectivity.Current.NetworkAccess == NetworkAccess.None)
{
    ...
}
```

また、ConnectivityChangedイベントにより、デバイスがインターネットに接続されているかどうかを判断することができます。ConnectivityChangedイベントは、ネットワークの状態が変化したときに自動的にトリガーされます。例えば、アクティブなネットワーク接続で開始し、最終的にそれを失った場合、ConnectivityChanged イベントが発生し、その変化を通知します。ConnectivityChanged イベントハンドラに渡されるパラメータの 1 つは、ConnectivityChangedEventArgs オブジェクトです。このオブジェクトには、IsConnected と呼ばれるプロパティが含まれています。IsConnectedプロパティを使用すると、インターネットに接続されているかどうかを判断することができます。以下はその例です：

```c#
Connectivity.Current.ConnectivityChanged += Connectivity_ConnectivityChanged;
...
void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs  e)
{
    bool stillConnected = e.IsConnected;
}
```