## UnityDLLCreater

Unityに限ったことではないですが、プログラムが肥大化するとビルドに時間がかかり、開発効率が低下します。  
そこで、事前にいくつのソースファイルをDLLとして生成することで、ビルド時間を短縮し、開発効率を向上させることができます。  
また、頻繁に使用する関数などは１つのDLLにモジュールとしてまとめることで、開発のたびに車輪の再発明をしなくて済みます。  

 
# 使い方
## ソースファイルを作成する。
ライブラリ化するソースファイルを作成します

## UnityDLLCreater.exeを実行する
初回起動時にUnityがインストールされているフォルダが聞かれますので、Unityのフォルダを指定してください（初期設定であればPrograms Filesに入ってると思います）   
 ちなみにこの設定は初回起動時のみで、以降表示されません。  
 
## 変換するスクリプトと出力先を指定する。
正しくフォルダが指定されるとウィンドウが立ち上がり、「smcs.bat」、「UnityEngine.dll」、「UnityEditor.dll」の３つに「Succes」が表示されます。  
この状態で「変換元スクリプト」と「出力先」を指定します。今回は「testlib.dll」というDLLを生成します。  
※変換元スクリプトは"*.cs"ファイルが存在するディレクトリを指定してください。  
指定が完了したら「DLL生成」をクリックしてください。ビルド：Succesが表示されていれば無事にDLLが生成されています。「出力先」をクリックしてDLLの出力先フォルダを開きます。  
 
## 出力したDLLをアセットフォルダに入れる。
生成されたDLL（testlib.dll）はアセットフォルダ配下にコピーすることで、使用できるようになります。  
ちなみにUnityではアセットフォルダ配下にあるdllは自動で参照設定が行われるため、コピーするだけで使用可能な状態になります。この状態で今回作成したtestlib.dllが使える状態になります。  
