using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;

namespace FuzzyOKTK
{
    public partial class Form1 : Form
    {
        Graphics grBack = null;
        Bitmap backBmp = null;

        fuzzyProfit3 model3_1 = null;
        fuzzyProfit3 model3_2 = null;
        fuzzyProfit3 model3_3 = null;
        fuzzyProfit3 model3_4 = null;
        fuzzyProfit3 model3 = null;
        fuzzyModel1 model1 = new fuzzyModel1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //labelAdm.Image = global::callcenter.Properties.Resources.but;
            model3_1 = new fuzzyProfit3(new triangleFunc(200, 300, 800), new trapFunc(250, 500, 800, 2000), new trapFunc(3, 5, 7, 10), new triangleFunc(15, 20, 30));
            model3_2 = new fuzzyProfit3(new trapFunc(200, 270, 420, 800), new triangleFunc(250, 650, 2000), new triangleFunc(3, 6, 10), new trapFunc(15, 18, 25, 30));
            model3_3 = new fuzzyProfit3(new triangleFunc(200, 300, 800), new triangleFunc(250, 650, 2000), new trapFunc(3, 5, 7, 10), new trapFunc(15, 18, 25, 30));
            model3_4 = new fuzzyProfit3(new trapFunc(200, 270, 420, 800), new trapFunc(250, 500, 800, 2000), new triangleFunc(3, 6, 10), new triangleFunc(15, 20, 30));
            model3 = model3_1;
            updateStatM3();
            updateM1();

            openFileDialog1.Filter = "Модель (*.fuzzy)|*.fuzzy";
            saveFileDialog1.Filter = "Модель (*.fuzzy)|*.fuzzy";

        }
        void updateM1()
        {
            dataGridViewM1.Rows.Clear();
            
            dataGridViewM1.Rows.Add(model1.inTime, model1.inTime.nameLingvo, model1.inTime.funcs.Count, "Входная переменная");
            dataGridViewM1.Rows.Add(model1.inConsult, model1.inConsult.nameLingvo, model1.inConsult.funcs.Count, "Входная переменная");
            dataGridViewM1.Rows.Add(model1.inCost, model1.inCost.nameLingvo, model1.inCost.funcs.Count, "Входная переменная");
            dataGridViewM1.Rows.Add(model1.outService, model1.outService.nameLingvo, model1.outService.funcs.Count, "Выходная переменная");

            modelInter();
        }
        void updatemodel3()
        {
            switch (model3.app.GetType().ToString())
            {
                case "sLinear": panelM3App.BackgroundImage = global::FuzzyOKTK.Properties.Resources.sLin; break;
                case "zLinear": panelM3App.BackgroundImage = global::FuzzyOKTK.Properties.Resources.zLin; break;
                case "triangleFunc": panelM3App.BackgroundImage = global::FuzzyOKTK.Properties.Resources.triangle; break;
                case "trapFunc": panelM3App.BackgroundImage = global::FuzzyOKTK.Properties.Resources.trap; break;
            }
            switch (model3.cost.GetType().ToString())
            {
                case "sLinear": panelM3Cost.BackgroundImage = global::FuzzyOKTK.Properties.Resources.sLin; break;
                case "zLinear": panelM3Cost.BackgroundImage = global::FuzzyOKTK.Properties.Resources.zLin; break;
                case "triangleFunc": panelM3Cost.BackgroundImage = global::FuzzyOKTK.Properties.Resources.triangle; break;
                case "trapFunc": panelM3Cost.BackgroundImage = global::FuzzyOKTK.Properties.Resources.trap; break;
            }
            switch (model3.count.GetType().ToString())
            {
                case "sLinear": panelM3Count.BackgroundImage = global::FuzzyOKTK.Properties.Resources.sLin; break;
                case "zLinear": panelM3Count.BackgroundImage = global::FuzzyOKTK.Properties.Resources.zLin; break;
                case "triangleFunc": panelM3Count.BackgroundImage = global::FuzzyOKTK.Properties.Resources.triangle; break;
                case "trapFunc": panelM3Count.BackgroundImage = global::FuzzyOKTK.Properties.Resources.trap; break;
            }
            switch (model3.discount.GetType().ToString())
            {
                case "sLinear": panelM3Discount.BackgroundImage = global::FuzzyOKTK.Properties.Resources.sLin; break;
                case "zLinear": panelM3Discount.BackgroundImage = global::FuzzyOKTK.Properties.Resources.zLin; break;
                case "triangleFunc": panelM3Discount.BackgroundImage = global::FuzzyOKTK.Properties.Resources.triangle; break;
                case "trapFunc": panelM3Discount.BackgroundImage = global::FuzzyOKTK.Properties.Resources.trap; break;
            }
            textBoxM3AppText.Text = model3.app.fuzzyName;
            textBoxM3CountText.Text = model3.count.fuzzyName;
            textBoxM3DiscountText.Text = model3.discount.fuzzyName;
            textBoxM3CostText.Text = model3.cost.fuzzyName;

            textBoxM3AppParams.Text = model3.app.getParamStr();
            textBoxM3CountParams.Text = model3.count.getParamStr();
            textBoxM3DiscountParams.Text = model3.discount.getParamStr();
            textBoxM3CostParams.Text = model3.cost.getParamStr();
            
            calcM3();
        }

        void calcM3()
        {
            textBoxM3Min.Text = model3.getMinProfit().ToString("N2");
            textBoxM3Max.Text = model3.getMaxProfit().ToString("N2");
            textBoxM3TrustMin.Text = model3.getTrustMin().ToString("N2");
            textBoxM3TrustMax.Text = model3.getTrustMax().ToString("N2");
        }


        private void buttonM3Upd_Click(object sender, EventArgs e)
        {
            updateStatM3();
        }

        private void panelM3App_Click(object sender, EventArgs e)
        {
            fuzzyFuncDlg win = new fuzzyFuncDlg(model3.app);
            win.ShowDialog();
            if (win.result)
            {
                model3.setAppFunc(win.curFun);
                updateStatM3();
            }
        }

        private void panelM3Cost_Click(object sender, EventArgs e)
        {
            fuzzyFuncDlg win = new fuzzyFuncDlg(model3.cost);
            win.ShowDialog();
            if (win.result)
            {
                model3.setCostFunc(win.curFun);
                updateStatM3();
            }
        }

        private void panelM3Discount_Click(object sender, EventArgs e)
        {
            fuzzyFuncDlg win = new fuzzyFuncDlg(model3.discount);
            win.ShowDialog();
            if (win.result)
            {
                model3.setSkidkaFunc(win.curFun);
                updateStatM3();
            }
        }

        private void panelM3Count_Click(object sender, EventArgs e)
        {
            fuzzyFuncDlg win = new fuzzyFuncDlg(model3.count);
            win.ShowDialog();
            if (win.result)
            {
                model3.setCountFunc(win.curFun);
                updateStatM3();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            model3 = model3_1;
            updateStatM3();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            model3 = model3_2;
            updateStatM3();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            model3 = model3_3;
            updateStatM3();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            model3 = model3_4;
            updateStatM3();
        }

        private void trackBarDiscountA_Scroll(object sender, EventArgs e)
        {
            textBoxM3DiscountA.Text = (trackBarM3DiscountA.Value / 10.0).ToString("N2");
            trackBarM3DiscountD.Value = Math.Max(trackBarM3DiscountA.Value, trackBarM3DiscountD.Value);

            trackBarM3DiscountTrustMin.Value = Math.Max(trackBarM3DiscountTrustMin.Value, trackBarM3DiscountA.Value);
            trackBarM3DiscountTrustMax.Value = Math.Max(trackBarM3DiscountTrustMax.Value, trackBarM3DiscountA.Value);

            updateStatM3();
        }

        private void trackBarDiscountD_Scroll(object sender, EventArgs e)
        {
            textBoxM3DiscountD.Text = (trackBarM3DiscountD.Value/10.0).ToString("N2");
            trackBarM3DiscountA.Value = Math.Min(trackBarM3DiscountA.Value, trackBarM3DiscountD.Value);

            trackBarM3DiscountTrustMin.Value = Math.Min(trackBarM3DiscountTrustMin.Value, trackBarM3DiscountD.Value);
            trackBarM3DiscountTrustMax.Value = Math.Min(trackBarM3DiscountTrustMax.Value, trackBarM3DiscountD.Value);

            updateStatM3();
        }

        private void trackBarM3DiscountTrustMin_Scroll(object sender, EventArgs e)
        {
            trackBarM3DiscountTrustMin.Value = Math.Max(trackBarM3DiscountA.Value, trackBarM3DiscountTrustMin.Value);
            trackBarM3DiscountTrustMin.Value = Math.Min(trackBarM3DiscountD.Value, trackBarM3DiscountTrustMin.Value);

            textBoxM3DiscountTrustMin.Text = (trackBarM3DiscountTrustMin.Value / 10.0).ToString("N2");
            trackBarM3DiscountTrustMax.Value = Math.Max(trackBarM3DiscountTrustMin.Value, trackBarM3DiscountTrustMax.Value);

            updateStatM3();
        }

        private void trackBarM3DiscountTrustMax_Scroll(object sender, EventArgs e)
        {
            trackBarM3DiscountTrustMax.Value = Math.Max(trackBarM3DiscountA.Value, trackBarM3DiscountTrustMax.Value);
            trackBarM3DiscountTrustMax.Value = Math.Min(trackBarM3DiscountD.Value, trackBarM3DiscountTrustMax.Value);

            textBoxM3DiscountTrustMax.Text = (trackBarM3DiscountTrustMax.Value / 10.0).ToString("N2");
            trackBarM3DiscountTrustMin.Value = Math.Min(trackBarM3DiscountTrustMin.Value, trackBarM3DiscountTrustMax.Value);

            updateStatM3();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            textBoxM3CountD.Text = (trackBarM3CountD.Value / 10.0).ToString("N2");
            trackBarM3CountA.Value = Math.Min(trackBarM3CountA.Value, trackBarM3CountD.Value);

            trackBarM3CountTrustMin.Value = Math.Min(trackBarM3CountTrustMin.Value, trackBarM3CountD.Value);
            trackBarM3CountTrustMax.Value = Math.Min(trackBarM3CountTrustMax.Value, trackBarM3CountD.Value);

            updateStatM3();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBarM3CountTrustMin.Value = Math.Max(trackBarM3CountA.Value, trackBarM3CountTrustMin.Value);
            trackBarM3CountTrustMin.Value = Math.Min(trackBarM3CountD.Value, trackBarM3CountTrustMin.Value);

            textBoxM3CountTrustMin.Text = (trackBarM3CountTrustMin.Value / 10.0).ToString("N2");
            trackBarM3CountTrustMax.Value = Math.Max(trackBarM3CountTrustMin.Value, trackBarM3CountTrustMax.Value);

            updateStatM3();
        }

        private void textBoxM3DiscountD_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxM3DiscountTrustMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxM3DiscountTrustMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void trackBarM3CountA_Scroll(object sender, EventArgs e)
        {
            textBoxM3CountA.Text = (trackBarM3CountA.Value / 10.0).ToString("N2");
            trackBarM3CountD.Value = Math.Max(trackBarM3CountA.Value, trackBarM3CountD.Value);

            trackBarM3CountTrustMin.Value = Math.Max(trackBarM3CountTrustMin.Value, trackBarM3CountA.Value);
            trackBarM3CountTrustMax.Value = Math.Max(trackBarM3CountTrustMax.Value, trackBarM3CountA.Value);

            updateStatM3();
        }

        private void trackBarM3CountTrustMax_Scroll(object sender, EventArgs e)
        {
            trackBarM3CountTrustMax.Value = Math.Max(trackBarM3CountA.Value, trackBarM3CountTrustMax.Value);
            trackBarM3CountTrustMax.Value = Math.Min(trackBarM3CountD.Value, trackBarM3CountTrustMax.Value);

            textBoxM3CountTrustMax.Text = (trackBarM3CountTrustMax.Value / 10.0).ToString("N2");
            trackBarM3CountTrustMin.Value = Math.Min(trackBarM3CountTrustMin.Value, trackBarM3CountTrustMax.Value);

            updateStatM3();
        }


        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            updateStatM3();
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            updateStatM3();
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            updateStatM3();
        }

        private void textBoxM3AppMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxM3AppMin.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBoxM3AppMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxM3AppMax.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBoxM3AppTrustMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxM3AppTrustMin.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBoxM3AppTrustMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxM3AppTrustMax.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBoxM3CostMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxM3CostMin.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBoxM3CostMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxM3CostMax.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBoxM3CostTrustMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxM3CostTrustMin.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBoxM3CostTrustMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                try
                {
                    string _text = textBoxM3CostTrustMax.Text + e.KeyChar;
                    double temp = Convert.ToDouble(_text);

                }
                catch (FormatException ex)
                {
                    string k = ex.Message;
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBox14_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateStatM3();
        }
        void updateStatM3()
        {
            if(textBoxM3AppMin.Text.CompareTo("")==0)
            {
                textBoxM3AppMin.Text = "0";
            }
            if (textBoxM3AppMax.Text.CompareTo("") == 0)
            {
                textBoxM3AppMax.Text = "0";
            }
            if (textBoxM3AppTrustMin.Text.CompareTo("") == 0)
            {
                textBoxM3AppTrustMin.Text = "0";
            }
            if (textBoxM3AppTrustMax.Text.CompareTo("") == 0)
            {
                textBoxM3AppTrustMax.Text = "0";
            }

            if (textBoxM3CostMin.Text.CompareTo("") == 0)
            {
                textBoxM3CostMin.Text = "0";
            }
            if (textBoxM3CostMax.Text.CompareTo("") == 0)
            {
                textBoxM3CostMax.Text = "0";
            }
            if (textBoxM3CostTrustMin.Text.CompareTo("") == 0)
            {
                textBoxM3CostTrustMin.Text = "0";
            }
            if (textBoxM3CostTrustMax.Text.CompareTo("") == 0)
            {
                textBoxM3CostTrustMax.Text = "0";
            }

            model3.app.setVlas(
                Convert.ToDouble(textBoxM3AppMin.Text),
                Convert.ToDouble(textBoxM3AppTrustMin.Text),
                Convert.ToDouble(textBoxM3AppTrustMax.Text),
                Convert.ToDouble(textBoxM3AppMax.Text));
            model3.cost.setVlas(
                Convert.ToDouble(textBoxM3CostMin.Text),
                Convert.ToDouble(textBoxM3CostTrustMin.Text),
                Convert.ToDouble(textBoxM3CostTrustMax.Text),
                Convert.ToDouble(textBoxM3CostMax.Text));

            model3.count.setVlas(
                trackBarM3CountA.Value / 10.0,
                trackBarM3CountTrustMin.Value / 10.0,
                trackBarM3CountTrustMax.Value / 10.0,
                trackBarM3CountD.Value / 10.0);

            model3.discount.setVlas(
                trackBarM3DiscountA.Value / 10.0,
                trackBarM3DiscountTrustMin.Value / 10.0,
                trackBarM3DiscountTrustMax.Value / 10.0,
                trackBarM3DiscountD.Value / 10.0);
            //calc
            textBoxM3StatMin.Text = model3.getMinProfit().ToString("N2");
            textBoxM3StatMax.Text = model3.getMaxProfit().ToString("N2");
            textBoxM3StatTrustMin.Text = model3.getTrustMin().ToString("N2");
            textBoxM3StatTrustMax.Text = model3.getTrustMax().ToString("N2");

            updatemodel3();
        }

        private void textBoxM3CostTrustMax_TextChanged(object sender, EventArgs e)
        {
            updateStatM3();
        }

        private void textBoxM3CostMin_TextChanged(object sender, EventArgs e)
        {
            updateStatM3();
        }

        private void textBoxM3AppTrustMax_TextChanged(object sender, EventArgs e)
        {
            updateStatM3();
        }

        private void textBoxM3AppTrustMin_TextChanged(object sender, EventArgs e)
        {
            updateStatM3();
        }

        private void textBoxM3AppMin_TextChanged(object sender, EventArgs e)
        {
            updateStatM3();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewM1.SelectedRows.Count > 0)
            {
                fuzzyLingvo lingvo = (fuzzyLingvo)dataGridViewM1.SelectedRows[0].Cells[0].Value;
                fuzzyFuncAltDlg win = new fuzzyFuncAltDlg(lingvo);
                win.ShowDialog();
                modelInter();
            }
        }

        private void сохранитьМодельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName.CompareTo("") != 0)
            {
                FileStream myStream = File.Create(saveFileDialog1.FileName);
                BinaryFormatter myXMLFormat = new BinaryFormatter();
                myXMLFormat.Serialize(myStream, model1);
                myStream.Close();
            }
        }


        private void загрузитьМодельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.CompareTo("") != 0)
            {
                FileStream myStream = File.OpenRead(openFileDialog1.FileName);
                BinaryFormatter myXMLFormat = new BinaryFormatter();
                model1 = (fuzzyModel1)myXMLFormat.Deserialize(myStream);
                myStream.Close();
                updateM1();
            }
        }

        private void закрытьПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        void modelInter()
        {
            double[] ret = model1.interp((double)trackBarInTime.Value, (double)trackBarInConsult.Value, (double)trackBarInCost.Value);
              
            string s = "[" + ret[0].ToString("N2") + "]";
            for (int i = 1; i < ret.Length; i++)
            { 
                s+="[" + ret[i].ToString("N2") + "]";
            }
            textBoxOut.Text = s;
            textBoxOutServ.Text = ret[0].ToString("N0");
            double[] r = new double[ret.Length - 1];
            for (int i = 0; i < r.Length; i++)
            {
                r[i] = ret[i + 1];
            }
            draw(r);
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            modelInter();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rules win = new rules(ref model1);
            win.ShowDialog();
        }

        private void numericUpDownInTime_ValueChanged(object sender, EventArgs e)
        {
            modelInter();
        }

        private void numericUpInConsult_ValueChanged(object sender, EventArgs e)
        {
            modelInter();
        }

        private void numericInCost_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void panelFuzzy_Paint(object sender, PaintEventArgs e)
        {
            modelInter();
        }
        void draw(double[] r)
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
            for (int i = 0; i < model1.outService.funcs.Count; i++)
            {
                fuzzyFuncs func = model1.outService.funcs[i];
                drawFunc((float)r[i], grBack, func, 250, 230);
            }
            for (int i = 0; i < model1.outService.funcs.Count; i++)
            {
                fuzzyFuncs func = model1.outService.funcs[i];
                drawFunc(grBack, func, 250, 230);
            }
            //axis
            drawAxis(grBack, 250, 230);

            gr.DrawImage(backBmp, 0, 0);
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
            float dist = (float)((250 - 20.0f) / model1.outService.dist);

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
                grBack.DrawString((0 + model1.outService.dist / 5 * i).ToString("N2"), new Font("Arial", 8), new SolidBrush(Color.Black), new Point(x, h2 + 5));
            }
        }
        void drawFunc(float r, Graphics grBack, fuzzyFuncs func, int w, int h)
        {
            float dist = (float)((w - 20.0f) / model1.outService.dist);
            //solution
            List<PointF> ptSolution = func.getValues(r);
            PointF[] ptsSolution = new PointF[ptSolution.Count];
            for (int i = 0; i < ptSolution.Count; i++)
            {
                ptsSolution[i] = new PointF((ptSolution[i].X * dist) + 10, (h - 30.0f) - ptSolution[i].Y * (h - 30.0f) + 10.0f);
            }
            grBack.FillPolygon(new HatchBrush(HatchStyle.Weave, Color.Black, Color.White), ptsSolution);
        }
        void drawFunc(Graphics grBack, fuzzyFuncs func, int w, int h)
        {
            List<PointF> pt = func.getValues();
            float dist = (float)((w - 20.0f) / model1.outService.dist);
            //term
            PointF[] points = new PointF[pt.Count];
            for (int i = 0; i < pt.Count; i++)
            {
                points[i] = new PointF((pt[i].X * dist) + 10, (h - 30.0f) - pt[i].Y * (h - 30.0f) + 10.0f);
            }
            grBack.DrawLines(new Pen(Color.Green, 2), points);


            for (int i = 0; i < points.Length; i++)
            {
                PointF p = points[i];
                grBack.FillEllipse(new SolidBrush(Color.Green), new RectangleF(p.X - 3, p.Y - 3, 6, 6));

            }
            //labels
            List<PointF> l = func.getValues(1.0f);
            float x = (l[1].X * dist) + 10;
           // for (int i = 0; i < l.Count-2; i++)
           // {
           //     x += (l[i].X * dist) + 10;
           // }
            //= (points[0].X+points[points.Length-1].X)/2.0f;            
            //x /= 2;
            grBack.DrawString(func.fuzzyName, new Font("Arial", 8), new SolidBrush(Color.Red), new PointF(x, -2));
        }

        private void trackBarInTime_Scroll(object sender, EventArgs e)
        {
            textBoxInTime.Text = trackBarInTime.Value.ToString();
            modelInter();
        }

        private void trackBarInConsult_Scroll(object sender, EventArgs e)
        {
            textBoxInConsult.Text = trackBarInConsult.Value.ToString();
            modelInter();
        }

        private void trackBarInCost_Scroll(object sender, EventArgs e)
        {
            textBoxInCost.Text = trackBarInCost.Value.ToString();
            modelInter();
        }

        private void textBoxInConsult_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
