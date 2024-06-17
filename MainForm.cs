using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace PlutoniumPlus
{
    public partial class MainForm : Form
    {
        private string configFilePath = "PlutoniumPlus.config";
        private string defaultInstallDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Plutonium");
        private string selectedInstallDir;
        private bool selectedAutoClose;

        public MainForm(string[] args)
        {
            InitializeComponent();
            LoadSettings();
            UpdateMoveButtonVisibility();

            if (args.Length > 0 && args[0] == "--SkipUI")
            {
                this.Hide();
                RunPlutonium(true);
            }
        }

        private void LoadSettings()
        {
            if (File.Exists(configFilePath))
            {
                var lines = File.ReadAllLines(configFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        var settingName = parts[0].Trim();
                        var settingValue = parts[1].Trim().Trim('"');

                        if (settingName == "InstallDir")
                        {
                            selectedInstallDir = settingValue;
                        }
                        else if (settingName == "AutoClose")
                        {
                            if (settingValue == "True")
                            {
                                selectedAutoClose = true;
                                checkBoxAutoClose.Checked = true;
                            }
                            else
                            {
                                selectedAutoClose = false;
                                checkBoxAutoClose.Checked = false;
                            }
                        }
                    }
                }
            }
            else
            {
                selectedInstallDir = defaultInstallDir;
                SaveSettings();
            }
            textBoxPLInstallLocation.Text = selectedInstallDir;

        }

        private void SaveSettings()
        {
            using (StreamWriter writer = new StreamWriter(configFilePath))
            {
                writer.WriteLine($"InstallDir=\"{selectedInstallDir}\"");
                writer.WriteLine($"AutoClose=\"{selectedAutoClose}\"");
            }
        }

        private void RunPlutonium(bool AutoClose)
        {
            string plutoniumPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plutonium.exe");
            if (File.Exists(plutoniumPath))
            {
                Process.Start(plutoniumPath, $"-install-dir \"{selectedInstallDir}\"");

                if (AutoClose)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("plutonium.exe not found in the current directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void plInstallDirectoryButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.FileName = "Select Folder";
                dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedInstallDir = Path.GetDirectoryName(dialog.FileName);
                    textBoxPLInstallLocation.Text = selectedInstallDir;
                }
            }
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            UpdateMoveButtonVisibility();
            MessageBox.Show("Settings saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateMoveButtonVisibility()
        {
            buttonMovePLInstall.Visible = Directory.Exists(defaultInstallDir) && selectedInstallDir != defaultInstallDir;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            RunPlutonium(selectedAutoClose);
        }

        private void buttonMovePLInstall_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(defaultInstallDir) && selectedInstallDir != defaultInstallDir)
                {
                    CopyDirectory(defaultInstallDir, selectedInstallDir);
                    Directory.Delete(defaultInstallDir, true);
                    MessageBox.Show("Plutonium installation moved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonMovePLInstall.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error moving Plutonium installation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                var destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (var dir in Directory.GetDirectories(sourceDir))
            {
                var destSubDir = Path.Combine(destDir, Path.GetFileName(dir));
                CopyDirectory(dir, destSubDir);
            }
        }

        private void buttonCreateShortcut_Click(object sender, EventArgs e)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string shortcutName = "Plutonium Launcher";
                string shortcutPath = Path.Combine(desktopPath, $"{shortcutName}.lnk");
                string targetPath = Application.ExecutablePath;
                string startInPath = AppDomain.CurrentDomain.BaseDirectory;

                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.Description = "Shortcut to Plutonium Launcher";
                shortcut.TargetPath = targetPath;
                shortcut.Arguments = "--SkipUI";
                shortcut.WorkingDirectory = startInPath;
                shortcut.Save();

                MessageBox.Show("Shortcut created successfully on the desktop.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating shortcut: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxAutoClose_CheckedChanged(object sender, EventArgs e)
        {
            selectedAutoClose = checkBoxAutoClose.Checked;
            SaveSettings();
        }
    }
}
