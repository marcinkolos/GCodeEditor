using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gcody
{
    public partial class SelectUseForm : Form
    {
        public string result = null;
        public SelectUseForm()
        {
            InitializeComponent();
        }

        private void PreselectedButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = (DialogResult)1;
            this.Close();
        }

        private void PlasmaButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = (DialogResult)2;
            this.Close();
        }

        private void MarkerButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = (DialogResult)3;
            this.Close();
        }

        private void OxygenButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = (DialogResult)4;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = (DialogResult)5;
            this.Close();
        }
    }
}
