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
            ""
        };

        static readonly string[] technology =
        {
            null,
            "TECHNOLOGY_ON",
            "TECHNOLOGY_OFF",
            ""
        };

        private void UseButton_Click(object sender, EventArgs e)
        {
            Form form = new SelectUseForm();
            DialogResult result = form.ShowDialog();
            Write(use[(int)result]);
            richTextBox.Focus();
        }

        private void TechnologyButton_Click(object sender, EventArgs e)
        {
            Form form = new SelectTechnologyForm();
            DialogResult result = form.ShowDialog();
            Write(technology[(int)result]);
            richTextBox.Focus();
        }

        private void G0Button_Click(object sender, EventArgs e)
        {
            richTextBox.Focus();
            Write("G0 X");
        }

        private void G1Button_Click(object sender, EventArgs e)
        {
            richTextBox.Focus();
            Write("G1 X");
        }

        private void G2Button_Click(object sender, EventArgs e)
        {
            richTextBox.Focus();
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
            int newLine = currentLine + 10 < richTextBox.Lines.Length ? currentLine + 10 : richTextBox.Lines.Length;
            int charInNewLine = richTextBox.GetFirstCharIndexFromLine(newLine);
            richTextBox.Select(charInNewLine, 0);
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            richTextBox.Focus();
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
            int caretPosition = richTextBox.SelectionStart;
            string start = richTextBox.Text.Substring(0, caretPosition);
            string end = richTextBox.Text.Substring(caretPosition, richTextBox.Text.Length - caretPosition);
            richTextBox.Text = string.Concat(start, text, end);
            richTextBox.Select(caretPosition + text.Length, 0);
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
                {
                    Write("Y");
                }
                else if (Regex.IsMatch(currentLineText, pattern2))
                {
                    Write("I");
                }
                else if (Regex.IsMatch(currentLineText, pattern3))
                {
                    Write("J");
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "NCP File (*.ncp)|*.ncp",
                DefaultExt = "ncp"
            };
            saveFileDialog.FileOk += SaveFileDialog_FileOk;
            saveFileDialog.ShowDialog();
        }

        private void SaveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string text = richTextBox.Text;
            File.WriteAllText(((SaveFileDialog)sender).FileName, text);
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
    }
}
