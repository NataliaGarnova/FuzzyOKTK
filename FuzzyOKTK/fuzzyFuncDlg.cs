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
    public partial class fuzzyFuncDlg : Form
    {
        public bool result = false;
        public fuzzyFuncs curFun = null;

        public fuzzyFuncDlg(fuzzyFuncs func)
        {
            InitializeComponent();
            curFun = func;
        }

        private void textBoxA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxA.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBoxB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxB.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBoxC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxC.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBoxD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxD.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboType.SelectedItem.ToString())
            {
                case "Линейная Z":
                    panelFuzzy.BackgroundImage = global::FuzzyOKTK.Properties.Resources.sLin;
                    textBoxC.Enabled = false;
                    textBoxD.Enabled = false;
                    textBoxParams.Text = "A [" + textBoxA.Text + "] B[" + textBoxB.Text + "]";
                    break;
                case "Линейная Сплайн":
                    panelFuzzy.BackgroundImage = global::FuzzyOKTK.Properties.Resources.zLin;
                    textBoxC.Enabled = false;
                    textBoxD.Enabled = false;
                    textBoxParams.Text = "A [" + textBoxA.Text + "] B[" + textBoxB.Text + "]";
                    break;
                case "Треугольная":
                    panelFuzzy.BackgroundImage = global::FuzzyOKTK.Properties.Resources.triangle;
                    textBoxC.Enabled = true;
                    textBoxD.Enabled = false;
                    textBoxParams.Text = "A [" + textBoxA.Text + "] B[" + textBoxB.Text + "] C[" + textBoxC.Text + "]";
                    break;
                case "Трапецевидная":
                    panelFuzzy.BackgroundImage = global::FuzzyOKTK.Properties.Resources.trap;
                    textBoxC.Enabled = true;
                    textBoxD.Enabled = true;
                    textBoxParams.Text = "A [" + textBoxA.Text + "] B[" + textBoxB.Text + "] C[" + textBoxC.Text + "] D[" + textBoxD.Text + "]";
                    break;
            }
        }

        private void fuzzyFuncDlg_Load(object sender, EventArgs e)
        {
            textBoxName.Text = curFun.fuzzyName;
            textBoxParams.Text = curFun.getParamStr();

            switch (curFun.GetType().ToString())
            {
                case "sLinear":
                    comboType.SelectedItem = "Линейная Сплайн";
                    textBoxA.Text = ((sLinear)curFun).A.ToString("N2");
                    textBoxB.Text = ((sLinear)curFun).B.ToString("N2");
                    panelFuzzy.BackgroundImage = global::FuzzyOKTK.Properties.Resources.sLin; break;
                case "zLinear":
                    textBoxA.Text = ((zLinear)curFun).A.ToString("N2");
                    textBoxB.Text = ((zLinear)curFun).B.ToString("N2");
                    comboType.SelectedItem = "Линейная Z";
                    panelFuzzy.BackgroundImage = global::FuzzyOKTK.Properties.Resources.zLin; break;
                case "triangleFunc":
                    textBoxA.Text = ((triangleFunc)curFun).A.ToString("N2");
                    textBoxB.Text = ((triangleFunc)curFun).B.ToString("N2");
                    textBoxC.Text = ((triangleFunc)curFun).C.ToString("N2");
                    comboType.SelectedItem = "Треугольная";
                    panelFuzzy.BackgroundImage = global::FuzzyOKTK.Properties.Resources.triangle; break;
                case "trapFunc":
                    textBoxA.Text = ((trapFunc)curFun).A.ToString("N2");
                    textBoxB.Text = ((trapFunc)curFun).B.ToString("N2");
                    textBoxC.Text = ((trapFunc)curFun).C.ToString("N2");
                    textBoxD.Text = ((trapFunc)curFun).D.ToString("N2");
                    comboType.SelectedItem = "Трапецевидная";
                    panelFuzzy.BackgroundImage = global::FuzzyOKTK.Properties.Resources.trap; break;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxA.Text.CompareTo("") == 0)
            {
                textBoxA.Text = "0";
            }
            if (textBoxB.Text.CompareTo("") == 0)
            {
                textBoxB.Text = textBoxA.Text;
            }
            if (textBoxC.Text.CompareTo("") == 0)
            {
                textBoxC.Text = textBoxB.Text;
            }
            if (textBoxD.Text.CompareTo("") == 0)
            {
                textBoxD.Text = textBoxC.Text;
            }
            result = true;
            switch (comboType.SelectedItem.ToString())
            {
                case "Линейная Z":
                    {
                        double a = Convert.ToDouble(textBoxA.Text);
                        double b = Convert.ToDouble(textBoxB.Text);
                        curFun = new zLinear(a, b);
                    } break;
                case "Линейная Сплайн":
                    {
                        double a = Convert.ToDouble(textBoxA.Text);
                        double b = Convert.ToDouble(textBoxB.Text);
                        curFun = new sLinear(a, b);
                    } break;
                case "Треугольная":
                    {
                        double a = Convert.ToDouble(textBoxA.Text);
                        double b = Convert.ToDouble(textBoxB.Text);
                        double c = Convert.ToDouble(textBoxC.Text);
                        curFun = new triangleFunc(a, b, c);
                    } break;
                case "Трапецевидная":
                    {
                        double a = Convert.ToDouble(textBoxA.Text);
                        double b = Convert.ToDouble(textBoxB.Text);
                        double c = Convert.ToDouble(textBoxC.Text);
                        double d = Convert.ToDouble(textBoxD.Text);
                        curFun = new trapFunc(a, b, c, d);
                    } break;
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
