
プロジェクトでは、以下の項目に注意してください。

- Resources フォルダには、すべてのプラットフォームで使用される共有フォント、画像、およびアセットが含まれています。
- MauiProgram.csファイルには、アプリを構成するコードと、アプリケーションを実行するためにAppクラスを使用することを指定するコードが含まれています。
- App.xaml.csファイルは、AppクラスのコンストラクタがAppShellクラスの新しいインスタンスを作成し、アプリケーションウィンドウに表示されます。
- AppShell.xamlファイルには、アプリケーションのメインレイアウトとMainPageの開始ページが含まれています。
- MainPage.xamlファイルは、ページのレイアウトを含んでいます。このレイアウトには、Click meというキャプションを持つボタンのXAMLコードと、dotnet_bot.pngファイルを表示する画像が含まれています。他にも、2つのラベルがあります。
- MainPage.xaml.csファイルには、このページのアプリケーション・ロジックが含まれています。具体的には、MainPageクラスには、ユーザーがClick meボタンをタップしたときに実行されるOnCounterClickedという名前のメソッドが含まれています。



https://learn.microsoft.com/ja-jp/training/modules/build-mobile-and-desktop-apps/5-add-controls-to-the-ui