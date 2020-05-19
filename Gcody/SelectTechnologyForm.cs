using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gcody
{
    public partial class SelectTechnologyForm : Form
    {
        public SelectTechnologyForm()
        {
            InitializeComponent();
        }

        private void OnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = (DialogResult)1;
            this.Close();
        }

        private void OffButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = (DialogResult)2;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = (DialogResult)3;
            this.Close();
        }
    }
}
