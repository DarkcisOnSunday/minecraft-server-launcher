using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
namespace MinecraftServerLauncher;

public partial class Form1 : Form
{
    private readonly TextBox _txtPath;
    private readonly Button _btnChoose;
    private readonly Button _btnRun;
    private readonly Button _btnSave;
    private readonly RichTextBox _txtEditor;

    private string _batPath = "";

    public Form1()
    {
        Text = "Minecraft Server Launcher";
        Width = 800;
        Height = 600;

        _txtPath = new TextBox { Left = 10, Top = 10, Width = 600 };
        _btnChoose = new Button { Text = "Выбрать .bat", Left = 620, Top = 10, Width = 150 };
        _txtEditor = new RichTextBox { Left = 10, Top = 50, Width = 760, Height = 400 };
        _btnRun = new Button { Text = "Запустить", Left = 10, Top = 470, Width = 120 };
        _btnSave = new Button { Text = "Сохранить", Left = 140, Top = 470, Width = 120 };

        _btnChoose.Click += BtnChooseClick;
        _btnRun.Click += BtnRunClick;
        _btnSave.Click += BtnSaveClick;

        Controls.Add(_txtPath);
        Controls.Add(_btnChoose);
        Controls.Add(_txtEditor);
        Controls.Add(_btnRun);
        Controls.Add(_btnSave);
    }

    [AllowNull]
    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }

    private void BtnChooseClick(object? sender, EventArgs e)
    {
        OpenFileDialog ofd = new()
        {
            Filter = "BAT files (*.bat)|*.bat"
        };
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            _batPath = ofd.FileName;
            _txtPath.Text = _batPath;
            _txtEditor.Text = File.ReadAllText(_batPath);
        }
    }

    private void BtnRunClick(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_batPath))
        {
            MessageBox.Show("Сначала выбери .bat файл");
            return;
        }

        var tempBat = Path.Combine(Path.GetDirectoryName(_batPath)!, "__temp_launcher.bat");
        File.WriteAllText(tempBat, _txtEditor.Text);

        Process.Start(new ProcessStartInfo
        {
            FileName = tempBat,
            UseShellExecute = true
        });
    }

    private void BtnSaveClick(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_batPath)) return;

        File.WriteAllText(_batPath, _txtEditor.Text);
        MessageBox.Show("Изменения сохранены.");
    }
}