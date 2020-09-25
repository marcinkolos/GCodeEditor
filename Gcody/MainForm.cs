using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gcody
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        static readonly string[] use =
        {
            null,
            "USE_PRESELECTED",
            "USE_PLASMA",
            "USE_MARKER",
            "USE_OXYGEN",
            String.Empty
        };

        static readonly string[] technology =
        {
            null,
            "TECHNOLOGY_ON",
            "TECHNOLOGY_OFF",
            String.Empty
        };

        bool lastChange = false;
        string defaultFilePath = "Untitled.ncp";
        private readonly Timer autosaveTimer = new Timer();

        private void MainForm_Load(object sender, EventArgs e)
        {
            richTextBox.Text = "N0001 PROGRAM\nN0002 INIT\nN0003\nN0004\nN0005\nN0006 DONE\nN0007 ENDPROGRAM";
            autosaveTimer.Tick += AutosaveTimer_Tick;
            autosaveTimer.Interval = 30000;
            autosaveTimer.Enabled = true;
        }

        private void AutosaveTimer_Tick(object sender, EventArgs e)
        {
            string text = richTextBox.Text;
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "autosave.ncp"), text);
        }

        private void UseButton_Click(object sender, EventArgs e)
        {
            Form form = new SelectUseForm();
            DialogResult result = form.ShowDialog();
            Write(use[(int)result]);
        }

        private void TechnologyButton_Click(object sender, EventArgs e)
        {
            Form form = new SelectTechnologyForm();
            DialogResult result = form.ShowDialog();
            Write(technology[(int)result]);
        }

        private void G0Button_Click(object sender, EventArgs e)
        {
            Write("G0 X");
        }

        private void G1Button_Click(object sender, EventArgs e)
        {
            Write("G1 X");
        }

        private void G2Button_Click(object sender, EventArgs e)
        {
            Write("G2 X");
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            richTextBox.Focus();
            int currentLine = richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart);
            int newLine = currentLine - 10 > 0 ? currentLine - 10 : 0;
            int charInNewLine = richTextBox.GetFirstCharIndexFromLine(newLine);
            richTextBox.Select(charInNewLine, 0);
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            richTextBox.Focus();
            int currentLine = richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart);
            int newLine = (currentLine + 10) < richTextBox.Lines.Length ? (currentLine + 10) : (richTextBox.Lines.Length - 1);
            int charInNewLine = richTextBox.GetFirstCharIndexFromLine(newLine);
            richTextBox.Select(charInNewLine, 0);
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            Write("\n");
            int currentLine = richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart);
            int lineOffset = richTextBox.SelectionStart - richTextBox.GetFirstCharIndexOfCurrentLine();
            richTextBox.Lines = FormatLines(richTextBox.Lines);
            richTextBox.Select(richTextBox.GetFirstCharIndexFromLine(currentLine) + lineOffset + 6, 0);
        }

        private string[] FormatLines(string[] lines)
        {
            for(int i = 0; i < lines.Length; i++)
            {
                string regex = @"N[0-9]{1,4}\s*";
                lines[i] = Regex.Replace(lines[i], regex, "");
                lines[i] = string.Format("N{0} {1}", (i + 1).ToString("D4"), lines[i]);
            }
            return lines;
        }

        public void Write(string text)
        {
            richTextBox.Focus();
            int caretPosition = richTextBox.SelectionStart;
            string start = richTextBox.Text.Substring(0, caretPosition);
            string end = richTextBox.Text.Substring(caretPosition, richTextBox.Text.Length - caretPosition);
            richTextBox.Text = string.Concat(start, text, end);
            richTextBox.Select(caretPosition + text.Length, 0);
        }

        public void PaintText()
        {
            if (lastChange)
            {
                lastChange = false;
                return;
            }
            string baseText = richTextBox.Text;
            string prefix = string.Concat(@"{\rtf1\ansi\deff0{\fonttbl{\f0\fnil\fcharset238{\*\fname Courier New;}Courier New CE;}}", "\n",
                @"{\colortbl ;\red255\green0\blue0;\red0\green0\blue0;\red139\green0\blue0;\red255\green165\blue0;\red128\green0\blue128;\red0\green128\blue0;}", "\n",
                @"\viewkind4\uc1\pard\cf1\lang1045\b\f0\fs29 ");
            int caretPosition = richTextBox.SelectionStart;
            KeyValuePair<string, string>[] patterns = new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>(@"N[0-9]{1,4}", @"\cf1"),
                new KeyValuePair<string, string>(@"G[0-2]", @"\cf5"),
                new KeyValuePair<string, string>(@"[X|Y|I|J]{1}-?[0-9.]{1,6}", @"\cf6"),
                new KeyValuePair<string, string>(@"TECHNOLOGY_O(N|FF)", @"\cf3"),
                new KeyValuePair<string, string>(@"(ENDPROGRAM|INIT|DONE)", @"\cf3"),
                new KeyValuePair<string, string>(@"PROGRAM", @"\cf3"),
                new KeyValuePair<string, string>(@"USE_(PRESELECTED|PLASMA|MARKER|OXYGEN)", @"\cf3")
            };
            foreach (KeyValuePair<string, string> pattern in patterns)
            {
                string replacement = String.Empty;
                while (true)
                {
                    Match match = Regex.Match(baseText, pattern.Key);
                    if (!match.Success) break;
                    string before = baseText.Substring(0, match.Index);
                    string after = baseText.Substring(match.Index + match.Length);
                    replacement += before;
                    replacement += String.Format("{0} {1}\\cf2 ", pattern.Value, match.Value);
                    baseText = after;
                }
                baseText = String.Concat(replacement, baseText);
            }
            baseText = Regex.Replace(baseText, "\n", "\\par\n");
            baseText = String.Concat(prefix, baseText, "\\par\n}\n");
            lastChange = true;
            richTextBox.Rtf = baseText;
            richTextBox.Select(caretPosition, 0);
        }

        public DialogResult ShowSaveDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = Path.GetFileName(defaultFilePath),
                InitialDirectory = Path.GetDirectoryName(defaultFilePath),
                Filter = "NCP File (*.ncp)|*.ncp",
                DefaultExt = "ncp"
            };
            saveFileDialog.FileOk += SaveFileDialog_FileOk;
            return saveFileDialog.ShowDialog();
        }

        private void richTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                int currentLine = richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart);
                string currentLineText = richTextBox.Lines[currentLine].Substring(0, richTextBox.SelectionStart - richTextBox.GetFirstCharIndexOfCurrentLine());
                string pattern = @"G[0-2]\sX-?[0-9.]{1,6}\s$";
                string pattern2 = @"G2\sX-?[0-9.]{1,6}\sY-?[0-9.]{1,6}\s$";
                string pattern3 = @"G2\sX-?[0-9.]{1,6}\sY-?[0-9.]{1,6}\sI-?[0-9.]{1,6}\s$";
                if (Regex.IsMatch(currentLineText, pattern))
                    Write("Y");
                else if (Regex.IsMatch(currentLineText, pattern2))
                    Write("I");
                else if (Regex.IsMatch(currentLineText, pattern3))
                    Write("J");
            }
            if (e.KeyCode == Keys.Enter)
            {
                int currentLine = richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart);
                int lineOffset = richTextBox.SelectionStart - richTextBox.GetFirstCharIndexOfCurrentLine();
                richTextBox.Lines = FormatLines(richTextBox.Lines);
                richTextBox.Select(richTextBox.GetFirstCharIndexFromLine(currentLine) + lineOffset + 6, 0);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ShowSaveDialog();
        }

        private void SaveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string text = richTextBox.Text;
            File.WriteAllText(((SaveFileDialog)sender).FileName, text);
            defaultFilePath = ((SaveFileDialog)sender).FileName;
            this.Text = string.Concat("GCode Editor - ", Path.GetFileName(defaultFilePath));
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "NCP File (*.ncp)|*.ncp",
                CheckFileExists = true,
                CheckPathExists = true
            };
            openFileDialog.FileOk += OpenFileDialog_FileOk;
            openFileDialog.ShowDialog();
        }

        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string text = File.ReadAllText(((OpenFileDialog)sender).FileName);
            richTextBox.Text = text;
            defaultFilePath = ((OpenFileDialog)sender).FileName;
            this.Text = string.Concat("GCode Editor - ", Path.GetFileName(defaultFilePath));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch(MessageBox.Show("Do you want to save before exit?", "Exit now?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
            {
                case DialogResult.Cancel: 
                    e.Cancel = true; 
                    break;
                case DialogResult.Yes: 
                    if(ShowSaveDialog() == DialogResult.Cancel) e.Cancel = true; 
                    break;
            }
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            PaintText();
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            richTextBox.Focus();
            richTextBox.SelectAll();
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            richTextBox.Focus();
            string selected = richTextBox.Text.Substring(richTextBox.SelectionStart, richTextBox.SelectionLength);
            Clipboard.SetText(selected);
            richTextBox.Text = String.Concat(richTextBox.Text.Substring(0, richTextBox.SelectionStart), richTextBox.Text.Substring(richTextBox.SelectionStart + richTextBox.SelectionLength));
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            richTextBox.Focus();
            string selected = richTextBox.Text.Substring(richTextBox.SelectionStart, richTextBox.SelectionLength);
            Clipboard.SetText(selected);
        }

        private void PasteButton_Click(object sender, EventArgs e)
        {
            richTextBox.Focus();
            Write(Clipboard.GetText());
        }
    }
}
