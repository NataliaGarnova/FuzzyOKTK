using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FuzzyOKTK
{
    public partial class fuzzyFuncAltDlg : Form
    {
        float ktrack = 1.0f;
        Graphics grBack = null;
        Bitmap backBmp = null;
        public bool result = false;
        public List<fuzzyFuncs> fuzzyFlist = null;
        string lingvoName;
        double U;
        fuzzyLingvo ling = null;

        public fuzzyFuncAltDlg(fuzzyLingvo ling)
        {
            InitializeComponent();
            fuzzyFlist = new List<fuzzyFuncs>();
            this.ling = ling;
            lingvoName = ling.nameLingvo;
            U = ling.dist;
            for (int i = 0; i < ling.funcs.Count; i++)
            {
                fuzzyFlist.Add(ling.funcs[i].getClone());
            }
        }

        string getFuzzyTypeName(string type)
        {
            string s = "";
            switch (type)
            {
                case "sLinear":
                    s = "Линейная Сплайн"; break;
                case "zLinear":
                    s = "Линейная Z"; break;
                case "triangleFunc":
                    s = "Треугольная"; break;
                case "trapFunc":
                    s = "Трапецевидная"; break;

            }
            return s;
        }
        void updTermsList()
        {
            textBoxName.Text = lingvoName;
            textBoxU.Text = U.ToString("N2");

            dataGridTerms.Rows.Clear();
            for (int i = 0; i < fuzzyFlist.Count; i++)
            {
                fuzzyFuncs func = fuzzyFlist[i];
                dataGridTerms.Rows.Add(func, func.fuzzyName, getFuzzyTypeName(func.GetType().ToString()), func.getParamStr());
            }
            showTerm();
        }

        private void fuzzyFuncDlg_Load(object sender, EventArgs e)
        {
            ktrack = (float)(1000.0 / U);

            updTermsList();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panelFuzzy_Paint(object sender, PaintEventArgs e)
        {
            draw();
        }
        void draw()
        {
            if (dataGridTerms.Rows.Count > 0)
            {
                Graphics gr = Graphics.FromHwnd(panelFuzzy.Handle);
                if (grBack == null)
                {
                    backBmp = new Bitmap(panelFuzzy.Width, panelFuzzy.Height);
                    grBack = Graphics.FromImage(backBmp);

                    grBack.SmoothingMode = SmoothingMode.AntiAlias;
                    grBack.InterpolationMode = InterpolationMode.Bicubic;
                }
                //data
                grBack.Clear(Color.White);
                bool key = false;
                for (int i = 0; i < dataGridTerms.Rows.Count; i++)
                {
                    fuzzyFuncs func = (fuzzyFuncs)dataGridTerms.Rows[i].Cells[0].Value;
                    int n = -1; ;
                    if (dataGridTerms.SelectedRows.Count > 0)
                    {
                        n = dataGridTerms.SelectedRows[0].Index;
                    }
                    key = false;
                    if (n == i)
                    {
                        key = true;
                    }
                    drawFunc(key, grBack, func, 250, 230);

                }
                //axis
                drawAxis(grBack, 250, 230);

                gr.DrawImage(backBmp, 0, 0);
            }
        }
        void drawAxis(Graphics grBack, int w, int h)
        {
            //axis
            grBack.DrawLine(new Pen(Color.Blue, 3), 10, (h - 15), 10, 5);
            grBack.DrawLine(new Pen(Color.Blue, 2), 10, 5, 6, 18);
            grBack.DrawLine(new Pen(Color.Blue, 2), 10, 5, 14, 18);

            grBack.DrawLine(new Pen(Color.Blue, 3), 5, h - 20, w + 8, h - 20);
            grBack.DrawLine(new Pen(Color.Blue, 2), w + 8, h - 20, w - 9, h - 24);
            grBack.DrawLine(new Pen(Color.Blue, 2), w + 8, h - 20, w - 9, h - 16);
            //ticks
            drawTicks(grBack, w, h);
        }
        void drawTicks(Graphics grBack, int w, int h)
        {
            float dist = (float)((250 - 20.0f) / U);

            int h1 = 10;
            int h2 = h - 20;
            Pen pen = new Pen(Color.LightGray, 1);
            pen.DashStyle = DashStyle.Dash;
            int _h = h1;
            for (int i = 0; i < 4; i++)
            {
                grBack.DrawLine(pen, 15, _h, 250, _h);
                grBack.DrawString((1.0 - i / 4.0).ToString("N2"), new Font("Arial", 8), new SolidBrush(Color.Black), new Point(15, _h));
                _h += (h2 - h1) / 4;
            }

            for (int i = 0; i < 6; i++)
            {
                int x = 10 + 230 / 5 * i;
                grBack.DrawLine(new Pen(Color.Blue), x, h2 - 5, x, h2 + 5);
                grBack.DrawString((0 + U / 5 * i).ToString("N2"), new Font("Arial", 8), new SolidBrush(Color.Black), new Point(x, h2 + 5));
            }
        }
        void drawFunc(bool key, Graphics grBack, fuzzyFuncs func, int w, int h)
        {
            List<PointF> pt = func.getValues();
            float dist = (float)((w - 20.0f) / U);
            PointF[] points = new PointF[pt.Count];
            for (int i = 0; i < pt.Count; i++)
            {
                points[i] = new PointF((pt[i].X * dist) + 10, (h - 30.0f) - pt[i].Y * (h - 30.0f) + 10.0f);
            }

            if (key)
            {
                Pen pen = new Pen(Color.Red, 3);
                pen.DashStyle = DashStyle.Dash;
                grBack.DrawLines(pen, points);
            }
            else
            {
                grBack.DrawLines(new Pen(Color.Green, 2), points);
            }
            for (int i = 0; i < points.Length; i++)
            {
                PointF p = points[i];
                grBack.FillEllipse(new SolidBrush(Color.Green), new RectangleF(p.X - 3, p.Y - 3, 6, 6));
            }
        }
        void showTerm()
        {
            if (dataGridTerms.SelectedRows.Count > 0)
            {
                fuzzyFuncs func = (fuzzyFuncs)dataGridTerms.SelectedRows[0].Cells[0].Value;

                textBoxParams.Text = func.getParamStr();

                switch (func.GetType().ToString())
                {
                    case "sLinear":
                        comboType.SelectedItem = "Линейная Сплайн";
                        trackA.Value = (int)(((sLinear)func).A * ktrack);
                        trackB.Value = (int)(((sLinear)func).B * ktrack);
                        trackC.Enabled = false;
                        trackD.Enabled = false;
                        break;
                    case "zLinear":
                        trackA.Value = (int)(((zLinear)func).A * ktrack);
                        trackB.Value = (int)(((zLinear)func).B * ktrack);
                        comboType.SelectedItem = "Линейная Z";
                        trackC.Enabled = false;
                        trackD.Enabled = false;
                        break;
                    case "triangleFunc":
                        trackA.Value = (int)(((triangleFunc)func).A * ktrack);
                        trackB.Value = (int)(((triangleFunc)func).B * ktrack);
                        trackC.Value = (int)(((triangleFunc)func).C * ktrack);
                        comboType.SelectedItem = "Треугольная";
                        trackC.Enabled = true;
                        trackD.Enabled = false;
                        break;
                    case "trapFunc":
                        trackA.Value = (int)(((trapFunc)func).A * ktrack);
                        trackB.Value = (int)(((trapFunc)func).B * ktrack);
                        trackC.Value = (int)(((trapFunc)func).C * ktrack);
                        trackD.Value = (int)(((trapFunc)func).D * ktrack);
                        comboType.SelectedItem = "Трапецевидная";
                        trackC.Enabled = true;
                        trackD.Enabled = true;
                        break;
                }
                draw();
            }
        }
        private void dataGridTerms_Click(object sender, EventArgs e)
        {
            
        }
        private void textBoxB_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxD_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxC_TextChanged(object sender, EventArgs e)
        {

        }
        private void buttonEditTerm_Click(object sender, EventArgs e)
        {
            if (dataGridTerms.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(this, "Изменить выбранный терм?", "Подтверждение операции", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    fuzzyFuncs func = (fuzzyFuncs)dataGridTerms.SelectedRows[0].Cells[0].Value;
                    string fuzzyName = func.fuzzyName;

                    switch (comboType.SelectedItem.ToString())
                    {
                        case "Линейная Z":
                            {
                                double a = Convert.ToDouble(trackA.Value / ktrack);
                                double b = Convert.ToDouble(trackB.Value / ktrack);
                                func = new zLinear(lingvoName, fuzzyName, a, b);
                            } break;
                        case "Линейная Сплайн":
                            {
                                double a = Convert.ToDouble(trackA.Value / ktrack);
                                double b = Convert.ToDouble(trackB.Value / ktrack);
                                func = new sLinear(lingvoName, fuzzyName, a, b);
                            } break;
                        case "Треугольная":
                            {
                                double a = Convert.ToDouble(trackA.Value / ktrack);
                                double b = Convert.ToDouble(trackB.Value / ktrack);
                                double c = Convert.ToDouble(trackC.Value / ktrack);
                                func = new triangleFunc(lingvoName, fuzzyName, a, b, c);
                            } break;
                        case "Трапецевидная":
                            {
                                double a = Convert.ToDouble(trackA.Value / ktrack);
                                double b = Convert.ToDouble(trackB.Value / ktrack);
                                double c = Convert.ToDouble(trackC.Value / ktrack);
                                double d = Convert.ToDouble(trackD.Value / ktrack);
                                func = new trapFunc(lingvoName, fuzzyName, a, b, c, d);
                            } break;
                    }
                    fuzzyFlist[dataGridTerms.SelectedRows[0].Index] = func;

                    dataGridTerms.SelectedRows[0].Cells[0].Value = func;
                    dataGridTerms.SelectedRows[0].Cells[2].Value = comboType.SelectedItem.ToString();
                    showTerm();
                }
            }
        }
        private void buttonAddTerm_Click(object sender, EventArgs e)
        {
            inputBox win = new inputBox("Добавление нового терма", "Введите обозначение для терма:", "новый терм");
            win.ShowDialog();
            if (win.isOk)
            {
                fuzzyFlist.Add(new triangleFunc(lingvoName, win.val, 1, 1, 1));
                updTermsList();
            }
        }
        private void buttonDelTerm_Click(object sender, EventArgs e)
        {
            if (dataGridTerms.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(this, "Удалить выбранный терм?", "Подтверждение операции", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    fuzzyFuncs func = (fuzzyFuncs)dataGridTerms.SelectedRows[0].Cells[0].Value;
                    fuzzyFlist.Remove(func);
                    updTermsList();
                }
            }
        }
        void updModelParams()
        {
            if (dataGridTerms.Rows.Count > 0)
            {
                fuzzyFuncs f = (fuzzyFuncs)dataGridTerms.SelectedRows[0].Cells[0].Value;

                f.setValues(trackA.Value / ktrack, trackB.Value / ktrack, trackC.Value / ktrack, trackD.Value / ktrack);
                textBoxParams.Text = f.getParamStr();

                draw();
            }
        }
        private void trackA_Scroll(object sender, EventArgs e)
        {
            trackB.Value = Math.Max(trackA.Value, trackB.Value);
            trackC.Value = Math.Max(trackC.Value, trackB.Value);
            trackD.Value = Math.Max(trackC.Value, trackD.Value);

            updModelParams();
        }
        private void trackB_Scroll(object sender, EventArgs e)
        {
            trackA.Value = Math.Min(trackA.Value, trackB.Value);

            trackC.Value = Math.Max(trackC.Value, trackB.Value);
            trackD.Value = Math.Max(trackC.Value, trackD.Value);

            updModelParams();
        }
        private void trackC_Scroll(object sender, EventArgs e)
        {
            trackB.Value = Math.Min(trackB.Value, trackC.Value);
            trackA.Value = Math.Min(trackA.Value, trackB.Value);

            trackD.Value = Math.Max(trackC.Value, trackD.Value);

            updModelParams();
        }
        private void trackD_Scroll(object sender, EventArgs e)
        {
            trackC.Value = Math.Min(trackC.Value, trackD.Value);
            trackB.Value = Math.Min(trackB.Value, trackC.Value);
            trackA.Value = Math.Min(trackA.Value, trackB.Value);

            updModelParams();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Сохранить изменения?", "Подтверждение изменений", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ling.funcs = fuzzyFlist;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridTerms.SelectedRows.Count > 0)
            {
                inputBox win = new inputBox("Измениние обзначения терма", "Введите новое обозначение для терма:", Convert.ToString(dataGridTerms.SelectedRows[0].Cells[1].Value));
                win.ShowDialog();
                if (win.isOk)
                {
                    fuzzyFlist[dataGridTerms.SelectedRows[0].Index].fuzzyName = win.val;
                    dataGridTerms.SelectedRows[0].Cells[1].Value = win.val;
                }
            }
        }

        private void dataGridTerms_SelectionChanged(object sender, EventArgs e)
        {
            showTerm();
        }
    }
}
