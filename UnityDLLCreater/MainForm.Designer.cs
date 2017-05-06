namespace UnityDLLCreater
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Import = new System.Windows.Forms.TextBox();
            this.textBox_Export = new System.Windows.Forms.TextBox();
            this.buttonInport = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEditor = new System.Windows.Forms.Button();
            this.labelFoundEditor = new System.Windows.Forms.Label();
            this.labelFoundEngine = new System.Windows.Forms.Label();
            this.labelFound_smcs = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOpenExp = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelBuild = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "変換元スクリプト：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "DLL出力先：";
            // 
            // textBox_Import
            // 
            this.textBox_Import.Location = new System.Drawing.Point(115, 20);
            this.textBox_Import.Name = "textBox_Import";
            this.textBox_Import.Size = new System.Drawing.Size(289, 19);
            this.textBox_Import.TabIndex = 2;
            // 
            // textBox_Export
            // 
            this.textBox_Export.Location = new System.Drawing.Point(115, 55);
            this.textBox_Export.Name = "textBox_Export";
            this.textBox_Export.Size = new System.Drawing.Size(289, 19);
            this.textBox_Export.TabIndex = 3;
            // 
            // buttonInport
            // 
            this.buttonInport.Location = new System.Drawing.Point(410, 18);
            this.buttonInport.Name = "buttonInport";
            this.buttonInport.Size = new System.Drawing.Size(75, 23);
            this.buttonInport.TabIndex = 4;
            this.buttonInport.Text = "参照";
            this.buttonInport.UseVisualStyleBackColor = true;
            this.buttonInport.Click += new System.EventHandler(this.buttonInport_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(410, 53);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "参照";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(366, 147);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(100, 38);
            this.buttonCreate.TabIndex = 6;
            this.buttonCreate.Text = "DLL生成";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonEditor);
            this.groupBox1.Controls.Add(this.labelFoundEditor);
            this.groupBox1.Controls.Add(this.labelFoundEngine);
            this.groupBox1.Controls.Add(this.labelFound_smcs);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 115);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "必須ファイル";
            // 
            // buttonEditor
            // 
            this.buttonEditor.Location = new System.Drawing.Point(219, 80);
            this.buttonEditor.Name = "buttonEditor";
            this.buttonEditor.Size = new System.Drawing.Size(75, 23);
            this.buttonEditor.TabIndex = 8;
            this.buttonEditor.Text = "再検索";
            this.buttonEditor.UseVisualStyleBackColor = true;
            this.buttonEditor.Click += new System.EventHandler(this.buttonResearch_Click);
            // 
            // labelFoundEditor
            // 
            this.labelFoundEditor.AutoSize = true;
            this.labelFoundEditor.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelFoundEditor.ForeColor = System.Drawing.Color.Red;
            this.labelFoundEditor.Location = new System.Drawing.Point(112, 85);
            this.labelFoundEditor.Name = "labelFoundEditor";
            this.labelFoundEditor.Size = new System.Drawing.Size(70, 12);
            this.labelFoundEditor.TabIndex = 13;
            this.labelFoundEditor.Text = ":Not Found";
            // 
            // labelFoundEngine
            // 
            this.labelFoundEngine.AutoSize = true;
            this.labelFoundEngine.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelFoundEngine.ForeColor = System.Drawing.Color.Red;
            this.labelFoundEngine.Location = new System.Drawing.Point(112, 54);
            this.labelFoundEngine.Name = "labelFoundEngine";
            this.labelFoundEngine.Size = new System.Drawing.Size(70, 12);
            this.labelFoundEngine.TabIndex = 12;
            this.labelFoundEngine.Text = ":Not Found";
            // 
            // labelFound_smcs
            // 
            this.labelFound_smcs.AutoSize = true;
            this.labelFound_smcs.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelFound_smcs.ForeColor = System.Drawing.Color.Red;
            this.labelFound_smcs.Location = new System.Drawing.Point(112, 24);
            this.labelFound_smcs.Name = "labelFound_smcs";
            this.labelFound_smcs.Size = new System.Drawing.Size(70, 12);
            this.labelFound_smcs.TabIndex = 11;
            this.labelFound_smcs.Text = ":Not Found";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "UnityEditor.dll";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "UnityEngine.dll";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "smcs.bat";
            // 
            // buttonOpenExp
            // 
            this.buttonOpenExp.Location = new System.Drawing.Point(366, 104);
            this.buttonOpenExp.Name = "buttonOpenExp";
            this.buttonOpenExp.Size = new System.Drawing.Size(100, 25);
            this.buttonOpenExp.TabIndex = 8;
            this.buttonOpenExp.Text = "出力先";
            this.buttonOpenExp.UseVisualStyleBackColor = true;
            this.buttonOpenExp.Click += new System.EventHandler(this.buttonOpenExp_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxLog);
            this.groupBox2.Location = new System.Drawing.Point(12, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 196);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ログ";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(6, 18);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(461, 171);
            this.textBoxLog.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "ビルド";
            // 
            // labelBuild
            // 
            this.labelBuild.AutoSize = true;
            this.labelBuild.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelBuild.ForeColor = System.Drawing.Color.Red;
            this.labelBuild.Location = new System.Drawing.Point(394, 196);
            this.labelBuild.Name = "labelBuild";
            this.labelBuild.Size = new System.Drawing.Size(60, 12);
            this.labelBuild.TabIndex = 15;
            this.labelBuild.Text = "           ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 422);
            this.Controls.Add(this.labelBuild);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonOpenExp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonInport);
            this.Controls.Add(this.textBox_Export);
            this.Controls.Add(this.textBox_Import);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnityDLLCreater";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Import;
        private System.Windows.Forms.TextBox textBox_Export;
        private System.Windows.Forms.Button buttonInport;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelFound_smcs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonEditor;
        private System.Windows.Forms.Label labelFoundEditor;
        private System.Windows.Forms.Label labelFoundEngine;
        private System.Windows.Forms.Button buttonOpenExp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelBuild;
    }
}

