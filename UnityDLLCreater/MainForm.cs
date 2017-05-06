using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UnityDLLCreater
{
    public partial class MainForm : Form
    {
        string g_unityPath; //Unity格納先
        string g_smcsPath; //smcs.batの格納先
        string g_unityEnginePath; //UnityEngine.dllの格納先
        string g_unityEditorPath; //UnityEditor.dllの格納先
        string g_default_Export; //初期出力先
        string g_default_Import; //初期スクリプトディレクトリ
        string g_buidbat; //ビルド用のバッチファイル出力先
        bool g_dllFileOk; //smcs,unityengine,unityeditorがすべて設定されているか

        const string FILENAME_SMCS = "smcs.bat";
        const string FILENAME_UNITYENGINE = "UnityEngine.dll";
        const string FILENAME_UNITYEDITOR = "UnityEditor.dll";
        const string FOUND_NO = ": Not Found";
        const string FOUND_OK = ": Succes";

        enum FILE
        {
            SMCS,
            UNITY_ENGINE,
            UNITY_EDITOR,
        }
        
        enum DIALOG_MODE
        {
            IMPORT,
            EXPORT,
        }

        /// <summary>
        /// 指定したファイルの有無状態を変更する。
        /// </summary>
        /// <param name="target">対象ファイル</param>
        /// <param name="check">有無</param>
        private void FoundTextChange(FILE target, bool check)
        {
            try
            {
                Color color = check == true ? Color.Blue : Color.Red;
                string Str = check == true ? FOUND_OK : FOUND_NO;
                switch (target)
                {
                    case FILE.SMCS:
                        this.labelFound_smcs.Text = Str;
                        this.labelFound_smcs.ForeColor = color;
                        break;
                    case FILE.UNITY_EDITOR:
                        this.labelFoundEditor.Text = Str;
                        this.labelFoundEditor.ForeColor = color;
                        break;
                    case FILE.UNITY_ENGINE:
                        this.labelFoundEngine.Text = Str;
                        this.labelFoundEngine.ForeColor = color;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public MainForm()
        {
            try
            {
                g_unityPath = Properties.Settings.Default.UNITY_PATH;
                InitializeComponent();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Unityフォルダから必須ファイル３つを検索して存在するか確認する
        /// </summary>
        /// <param name="path">Unityインストール先</param>
        /// <returns>検索結果</returns>
        private bool DLLSeach(string path)
        {
            bool result = true;
            try
            {
                g_dllFileOk = false;
                g_smcsPath = "";
                g_unityEditorPath = "";
                g_unityEnginePath = "";
                string[] serach = new string[] { "", "", "" };
                string errStr = "";
                string smcs_path = Properties.Settings.Default.PATH_SMCS;
                string engine_path = Properties.Settings.Default.PATH_UNITYENGINE;
                string editor_path = Properties.Settings.Default.PATH_UNITYEDITOR;
                bool bSmcs = (System.IO.File.Exists(path + smcs_path));
                bool bEditor = (System.IO.File.Exists(path + editor_path));
                bool bEngine = (System.IO.File.Exists(path + engine_path));

                //検索結果
                if (!bEditor)
                {
                    errStr += "UnityEditor.dll\n\r";
                    result = false;
                }
                else
                {
                    g_unityEditorPath = path + editor_path;
                }

                if (!bEngine)
                {
                    errStr += "UnityEngine.dll\n\r";
                    result = false;
                }
                else
                {
                    g_unityEnginePath = path + engine_path;
                }

                if (!bSmcs)
                {
                    errStr += "smcs.bat\n\r";
                    result = false;
                }
                else
                {
                    g_smcsPath = path + smcs_path;
                }

                //ラベルに反映
                FoundTextChange(FILE.SMCS, bSmcs);
                FoundTextChange(FILE.UNITY_EDITOR, bEditor);
                FoundTextChange(FILE.UNITY_ENGINE, bEngine);

                if (result == false)
                {
                    MessageBox.Show("以下のファイルが見つかりませんでした。\n\r" + errStr,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("必須ファイルが見つかりました。","確認");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            g_dllFileOk = result;
            return result;
        }

        /// <summary>
        /// Unityのインストールフォルダを指定させる。
        /// </summary>
        private void UnityPathSet()
        {
            try
            {
                MessageBox.Show("Unityをインストールしているパスを指定してください。");
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "フォルダを指定してください。";
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                //ダイアログを表示する
                if (fbd.ShowDialog(this) == DialogResult.OK)
                {
                    Properties.Settings.Default.UNITY_PATH = fbd.SelectedPath;
                    g_unityPath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    DLLSeach(fbd.SelectedPath);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            g_default_Export = Properties.Settings.Default.DEFAULT_EXP;
            g_unityPath = Properties.Settings.Default.UNITY_PATH;
            g_default_Import = Properties.Settings.Default.DEFAULT_IMP;
            if (g_unityPath.Length <= 0)
            {
                UnityPathSet();
            }else
            {
                DLLSeach(g_unityPath);
            }
        }
        
        /// <summary>
        /// ファイル or ディレクトリの選択を行う。
        /// </summary>
        /// <param name="mode">OpenMode</param>
        /// <returns>結果</returns>
        private string SetFileNameDialog(DIALOG_MODE mode)
        {
            string result = "";
            try
            {
                if (mode == DIALOG_MODE.EXPORT)
                {
                    //OpenFileDialogクラスのインスタンスを作成
                    OpenFileDialog ofd = new OpenFileDialog();

                    //はじめのファイル名を指定する
                    //はじめに表示されるフォルダを指定する
                    //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                    //[ファイルの種類]ではじめに選択されるものを指定する
                    //2番目の「すべてのファイル」が選択されているようにする
                    ofd.FilterIndex = 1;
                    ofd.Title = "DLLの出力先を選択してください";
                    //[ファイルの種類]に表示される選択肢を指定する
                    //指定しないとすべてのファイルが表示される
                    ofd.Filter = "DLLファイル(*.dll)|*.dll";
                    if (g_default_Export.Length > 0)
                        ofd.InitialDirectory = g_default_Export;

                    //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                    ofd.RestoreDirectory = true;
                    //存在しないファイルの名前が指定されたとき警告を表示する
                    //デフォルトでTrueなので指定する必要はない
                    ofd.CheckFileExists = false;
                    //存在しないパスが指定されたとき警告を表示する
                    //デフォルトでTrueなので指定する必要はない
                    ofd.CheckPathExists = false;

                    //ダイアログを表示する
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        result = ofd.FileName;
                    }
                } else
                {
                    //FolderBrowserDialogクラスのインスタンスを作成
                    FolderBrowserDialog fbd = new FolderBrowserDialog();

                    //上部に表示する説明テキストを指定する
                    fbd.Description = "スクリプトが保存されているフォルダを指定してください。";
                    //ルートフォルダを指定する
                    //デフォルトでDesktop

                        fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                    //最初に選択するフォルダを指定する
                    //RootFolder以下にあるフォルダである必要がある
                    if (g_default_Import.Length > 0)
                        fbd.SelectedPath = g_default_Import;
                    //ユーザーが新しいフォルダを作成できるようにする
                    //デフォルトでTrue
                    fbd.ShowNewFolderButton = true;

                    //ダイアログを表示する
                    if (fbd.ShowDialog(this) == DialogResult.OK)
                    {
                        //選択されたフォルダを表示する
                        result = fbd.SelectedPath;
                    }
                }
                if(mode == DIALOG_MODE.EXPORT)
                {
                    Properties.Settings.Default.DEFAULT_EXP = System.IO.Directory.GetParent(result).FullName; 
                    g_default_Export = System.IO.Directory.GetParent(result).FullName;
                }
                else
                {
                    Properties.Settings.Default.DEFAULT_IMP = result;
                    g_default_Import = result;
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// ビルド用のバッチファイルを生成する。
        /// </summary>
        /// <returns>生成結果</returns>
        private bool CreateBat()
        {
            try
            {
                string db = "\"";
                string exp = this.textBox_Export.Text;
                string imp = this.textBox_Import.Text;
                string batFileName = imp + @"\build.bat";
                string batScript = db + g_smcsPath + db + " -r:" + db + g_unityEnginePath + db + " -r:" + db + g_unityEditorPath + db + " -target:library -out:" + db + exp + db + " " + db + imp +"\\*.cs" + db;
                StreamWriter sr = new StreamWriter((new FileStream(batFileName, FileMode.Create)), Encoding.Default); //書込みモード

                sr.Write(batScript);
                sr.Close();
                g_buidbat = batFileName;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// ビルドを開始する。
        /// </summary>
        /// <returns></returns>
        private bool BuildStart()
        {
            try
            {

                System.IO.File.Delete(this.textBox_Export.Text);
                if (!CreateBat()) return false;
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = g_buidbat;

                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = false;
                //ウィンドウを表示しないようにする
                p.StartInfo.CreateNoWindow = true;

                //p.StartInfo.WorkingDirectory = this.textBox_Export.Text;
                p.Start();
                string logs = p.StandardOutput.ReadToEnd();
                //System.Diagnostics.Process.Start(g_smcsPath,batScript);
                if (System.IO.File.Exists(this.textBox_Export.Text))
                {
                    MessageBox.Show("DLLの生成が完了しました。","確認");
                    this.labelBuild.Text = ":Succes";
                    this.labelBuild.ForeColor = Color.Blue;
                }
                else
                {
                    MessageBox.Show("DLLの生成に失敗しました。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    this.labelBuild.Text = ":Failed";
                    this.labelBuild.ForeColor = Color.Red;
                }

                p.WaitForExit();
                p.Close();
                this.textBoxLog.Text =logs;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("DLLの生成に失敗しました。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                this.labelBuild.Text = ":Failed";
                this.labelBuild.ForeColor = Color.Red;
                return false;
            }
        }
        private void buttonInport_Click(object sender, EventArgs e)
        {
            string ImportPath = SetFileNameDialog(DIALOG_MODE.IMPORT);
            this.textBox_Import.Text = ImportPath;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            string ExportPath = SetFileNameDialog(DIALOG_MODE.EXPORT);
            this.textBox_Export.Text = ExportPath;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void buttonResearch_Click(object sender, EventArgs e)
        {
            UnityPathSet();
        }

        /// <summary>
        /// 必須ファイルが選択されれなければ警告を表示
        /// </summary>
        /// <returns></returns>
        private bool CheckDllFile()
        {
            if (g_dllFileOk == false)
            {
                MessageBox.Show("必須ファイルを先に設定してください",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// スクリプト or 出力先が指定されていないと警告を表示
        /// </summary>
        /// <returns></returns>
        private bool CheckExpImp()
        {
            bool result = false;
            try
            {
                result = this.textBox_Import.Text.Length > 0;
                if (!result)
                    MessageBox.Show("変換元スクリプトが指定されていません。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                result = this.textBox_Export.Text.Length > 0;
                if (!result)
                    MessageBox.Show("DLL出力先が指定されていません。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            this.labelBuild.Text = "";
            if (CheckDllFile() == false) return;
            if (CheckExpImp() == false) return;
            BuildStart();

        }

        private void buttonOpenExp_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.textBox_Export.Text.Length <= 0)
                {
                    MessageBox.Show("DLL出力先が指定されていません。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                System.Diagnostics.Process.Start(System.IO.Directory.GetParent(this.textBox_Export.Text).FullName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
