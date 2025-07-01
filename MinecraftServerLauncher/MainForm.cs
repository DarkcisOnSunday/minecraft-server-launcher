
using System.Diagnostics;


namespace MinecraftServerLauncher
{
    public partial class MainForm : Form
    {
        private string? _rootFolder;
        private string? _launchersFolder;
        private string? _selectedBatPath;

        public MainForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            btnSelectRoot.Click += (_, _) => BtnSelectRootClick();
            btnRun.Click += (_, _) => BtnRunClick();
            btnSave.Click += (_, _) => BtnSaveClick();
            btnAdd.Click += (_, _) => BtnAddNewBatFile();
            comboBoxBatFiles.SelectedIndexChanged += (_, _) => ComboBoxBatFiles_SelectedIndexChanged();
        }

        private void BtnSelectRootClick()
        {
            using FolderBrowserDialog dialog = new ();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadFromRootFolder(dialog.SelectedPath);
            }
        }

        private void LoadFromRootFolder(string path)
        {
            var versions = Path.Combine(path, "versions");
            var launchers = Path.Combine(path, "launchers");

            if (!Directory.Exists(versions) || !Directory.Exists(launchers))
            {
                MessageBox.Show("Unexpected structure");
                return;
            }

            _rootFolder = path;
            _launchersFolder = launchers;
            LoadBatFiles();
        }

        private void BtnAddNewBatFile()
        {
            if (!Directory.Exists(_launchersFolder)) return;

            var input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter new .bat file name (without extension):",
                "New Launcher File",
                "new_version"
            );

            if (string.IsNullOrWhiteSpace(input)) return;

            var fileName = input.EndsWith(".bat") ? input : input + ".bat";
            var filePath = Path.Combine(_launchersFolder, fileName);

            if (File.Exists(filePath))
            {
                MessageBox.Show("A file with this name already exists.");
                return;
            }
            
            File.WriteAllText(filePath, "");
            LoadBatFiles();
            comboBoxBatFiles.SelectedItem = fileName;
        }


        private void LoadBatFiles()
        {
            comboBoxBatFiles.Items.Clear();
            if (!Directory.Exists(_launchersFolder)) return;

            var batFiles = Directory.GetFiles(_launchersFolder, "*.bat");
            foreach (var batFile in batFiles)
            {
                comboBoxBatFiles.Items.Add(Path.GetFileName(batFile));
            }

            if (comboBoxBatFiles.Items.Count > 0)
                comboBoxBatFiles.SelectedIndex = 0;
        }

        private void ComboBoxBatFiles_SelectedIndexChanged()
        {
            if (comboBoxBatFiles.SelectedItem == null) return;

            _selectedBatPath = Path.Combine(_launchersFolder!, comboBoxBatFiles.SelectedItem.ToString()!);

            try
            {
                richTextBoxEditor.Text = File.ReadAllText(_selectedBatPath);
            }
            catch
            {
                richTextBoxEditor.Text = "";
                MessageBox.Show("Can't read file");
            }
        }

        private void BtnRunClick()
        {
            if (string.IsNullOrEmpty(_selectedBatPath)) return;

            File.WriteAllText(_selectedBatPath, richTextBoxEditor.Text);

            ProcessStartInfo startInfo = new()
            {
                FileName = _selectedBatPath,
                WorkingDirectory = Path.GetDirectoryName(_selectedBatPath),
                UseShellExecute = true
            };

            Process.Start(startInfo);
        }

        private void BtnSaveClick()
        {
            if (string.IsNullOrEmpty(_selectedBatPath)) return;

            File.WriteAllText(_selectedBatPath, richTextBoxEditor.Text);
        }
    }
}
