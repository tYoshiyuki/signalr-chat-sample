# signalr-chat-sample
SignalR と React の Webチャット のサンプル

## Feature
- .NET Core 2.2
- ASP.NET Core SignalR
- ASP.NET Core
- React
- Redux

## Demo
- [Demo Site](https://signalr-chat-sample.azurewebsites.net/index.html)

## Note
- サーバサイドは、Web API + SignalR で構成しています。
- フロントエンドは、React + Redux で構成しています。
- SignalRChatSample.sln をVisual Studioで開き、デバッグすることが可能です。
- フロントエンドを更新した場合は yarn build でビルドして下さい。
    - ビルド結果は、/SignalRChatSample/wwwroot に出力されます。
- データストアにSQL Serverが必要です。

## Reference
- https://github.com/jpniederer/NETCorePlayground/tree/master/ChatApp