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

        string defaultFileName = "Untitled.ncp";
        private Timer autosaveTimer = new Timer();

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
            File.WriteAllText("autosave.ncp", text);
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

        private string[] FormatLines(string[] text)
        {
            for(int i = 0; i < text.Length; i++)
            {
                string regex = @"N[0-9]{1,4}\s*";
                text[i] = Regex.Replace(text[i], regex, "");
                text[i] = string.Format("N{0} {1}", (i + 1).ToString("D4"), text[i]); 
            }
            return text;
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
            int caretPosition = richTextBox.SelectionStart;
            richTextBox.Select(0, richTextBox.Text.Length);
            richTextBox.SelectionColor = Color.Black;
            KeyValuePair<string, Color>[] pattern = new KeyValuePair<string, Color>[] {
                new KeyValuePair<string, Color>(@"N[0-9]{1,4}", Color.Red),
                new KeyValuePair<string, Color>(@"G[0-2]", Color.Purple),
                new KeyValuePair<string, Color>(@"[X|Y|I|J]{1}[0-9]{1,6}", Color.Green),
                new KeyValuePair<string, Color>(@"TECHNOLOGY_O(N|FF)", Color.DarkRed),
                new KeyValuePair<string, Color>(@"(PROGRAM|INIT|DONE|ENDPROGRAM)", Color.DarkRed),
                new KeyValuePair<string, Color>(@"USE_(PRESELECTED|PLASMA|MARKER|OXYGEN)", Color.DarkRed)
            };
            foreach(KeyValuePair<string, Color> pair in pattern)
            {
                MatchCollection matches = Regex.Matches(richTextBox.Text, pair.Key);
                foreach (Match match in matches)
                {
                    richTextBox.Select(match.Index, match.Length);
                    richTextBox.SelectionColor = pair.Value;
                }
            }
            richTextBox.Select(caretPosition, 0);
        }

        public void ShowSaveDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = defaultFileName,
                Filter = "NCP File (*.ncp)|*.ncp",
                DefaultExt = "ncp"
            };
            saveFileDialog.FileOk += SaveFileDialog_FileOk;
            saveFileDialog.ShowDialog();
        }


        private void richTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                int currentLine = richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart);
                string currentLineText = richTextBox.Lines[currentLine].Substring(0, richTextBox.SelectionStart - richTextBox.GetFirstCharIndexOfCurrentLine());
                string pattern = @"G[0-2]\sX[0-9]{1,6}\s$";
                string pattern2 = @"G2\sX[0-9]{1,6}\sY[0-9]{1,6}\s$";
                string pattern3 = @"G2\sX[0-9]{1,6}\sY[0-9]{1,6}\sI[0-9]{1,6}\s$";
                if (Regex.IsMatch(currentLineText, pattern))
                    Write("Y");
                else if (Regex.IsMatch(currentLineText, pattern2))
                    Write("I");
                else if (Regex.IsMatch(currentLineText, pattern3))
                    Write("J");
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
            //File.WriteAllText("rtf.txt", richTextBox.Rtf);
            defaultFileName = ((SaveFileDialog)sender).FileName;
            this.Text = string.Concat("GCode Editor - ", Path.GetFileName(defaultFileName));
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
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch(MessageBox.Show("Do you want to save before exit?", "Exit now?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
            {
                case DialogResult.Cancel : e.Cancel = true; break;
                case DialogResult.Yes: e.Cancel = true; ShowSaveDialog(); break;
            }
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            PaintText();
        }
    }
}
