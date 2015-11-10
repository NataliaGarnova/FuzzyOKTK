using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FuzzyOKTK
{
    public partial class inputBox : Form
    {
        public string val = "";
        public bool isOk = false;
        public inputBox(string text, string label, string val)
        {
            InitializeComponent();

            this.Text = text;
            this.label1.Text = label;
            this.textBoxValue.Text = val;
        }

        private void inputBox_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            val = textBoxValue.Text;
            isOk = true;
            Close();
        }
    }
}
