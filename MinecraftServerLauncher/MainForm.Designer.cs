using System;
using System.Windows.Forms;

namespace MinecraftServerLauncher
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox comboBoxBatFiles;
        private Button btnAdd;
        private RichTextBox richTextBoxEditor;
        private Button btnRun;
        private Button btnSave;
        private Button btnSelectRoot;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxBatFiles = new ComboBox();
            this.richTextBoxEditor = new RichTextBox();
            this.btnAdd = new Button();
            this.btnRun = new Button();
            this.btnSave = new Button();

            this.SuspendLayout();

            // comboBoxBatFiles
            this.comboBoxBatFiles.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxBatFiles.FormattingEnabled = true;
            this.comboBoxBatFiles.Location = new Point(12, 12);
            this.comboBoxBatFiles.Name = "comboBoxBatFiles";
            this.comboBoxBatFiles.Size = new Size(400, 23);
            
            // richTextBoxEditor
            this.richTextBoxEditor.Location = new Point(12, 50);
            this.richTextBoxEditor.Name = "richTextBoxEditor";
            this.richTextBoxEditor.Size = new Size(560, 350);
            this.richTextBoxEditor.Font = new Font("Consolas", 10);
            
            // btnAdd
            this.btnAdd.Location = new Point(420, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(75, 23);
            this.btnAdd.Text = "Add New";

            // btnRun
            this.btnRun.Location = new Point(12, 410);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new Size(100, 30);
            this.btnRun.Text = "Run";

            // btnSave
            this.btnSave.Location = new Point(120, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.Text = "Save";
            
            // btnSelectRoot
            this.btnSelectRoot = new System.Windows.Forms.Button();
            this.btnSelectRoot.Location = new System.Drawing.Point(510, 12);
            this.btnSelectRoot.Name = "btnSelectRoot";
            this.btnSelectRoot.Size = new System.Drawing.Size(60, 23);
            this.btnSelectRoot.Text = "Path";

            // MainForm
            this.ClientSize = new Size(584, 461);
            this.Controls.Add(this.comboBoxBatFiles);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.richTextBoxEditor);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSelectRoot);
            this.Name = "MainForm";
            this.Text = "Minecraft Server Launcher";
            this.ResumeLayout(false);
        }
    }
}
