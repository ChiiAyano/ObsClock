# ObsClock
OBS Studio Websocket Plugin を使用した時報送出プログラム

## 必要なもの
* [OBS Studio](https://obsproject.com/)
* [obs-websocket](https://github.com/Palakis/obs-websocket)
* .NET Core 3.1

## 使い方
1. 最初に起動すると `settings.json` ができます。特に何もしていなければ、最初の一回目は例外でクラッシュします
1. 設定をし、OBS Studio を起動しておきます。OBS Studio では「テキスト (GDI+)」をソースに追加し、表示する設定を済ませておきます
1. その状態でこのアプリを起動してください
1. テキストを表示するソースの名前を見てアプリが時刻表示に書き換えます

## 設定ファイルの設定項目
| 項目名 | 型 | 説明 | 既定値 |
|--------|---|------|-------|
| `url` | `string` | OBS Studio に接続するアドレスを指定します | ws://127.0.0.1:4444/ |
| `password` | `string?` | 接続パスワードを設定します | 設定無し |
| `sourceName` | `string` | 書き換えるテキストオブジェクトの名前を指定します | Clock |
| `hoursFormat` | `string` | "時" 表示の仕方を設定します。[設定は C# で指定できるものに依存します](https://docs.microsoft.com/ja-jp/dotnet/standard/base-types/custom-date-and-time-format-strings#hSpecifier) | h |
| `noon` | `int` | 正午 (24 時, 12 時) のときの表記方法を設定します。0 はゼロ時として、1 は 12 時または 0 時として表記します | 0 |
| `fillCharacter` | `string` | "hoursFormat" で `hh` または `HH` にしていない場合の埋め文字を指定します | 空文字 |
| `alwaysShowClockTimes` | `TimeRange[]` | 常に表示する時間帯を設定します | 午前 6 時 ～ 午前 10 時 |
| `showDuration` | `int` | 時報表示をする時間を指定します。常に表示する時間帯では無視されます | 5 (秒) |
| `showInterval` | `int` | 時報表示を表示する間隔 (正時 0 分から換算) を指定します。常に表示する時間帯では無視されます | 30 (分) |

### TimeRange
| 項目名 | 型 | 説明 |
|--------|---|------|
| `start` | `time (HH:mm:ss)` | 常に表示する時間帯の開始時刻 |
| `end` | `time (HH:mm:ss)` | 常に表示する時間帯の終了時刻 |
