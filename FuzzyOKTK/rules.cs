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
    public partial class rules : Form
    {
        fuzzyModel1 model1;
        public rules(ref fuzzyModel1 model1)
        {
            InitializeComponent();
            this.model1 = model1;
        }
        void fillcombos()
        {
            comboBoxInTime.Items.Add("");
            for (int i = 0; i < model1.inTime.funcs.Count; i++)
            {
                comboBoxInTime.Items.Add(model1.inTime.funcs[i].fuzzyName);
            }
            comboBoxInConsult.Items.Add("");
            for (int i = 0; i < model1.inConsult.funcs.Count; i++)
            {
                comboBoxInConsult.Items.Add(model1.inConsult.funcs[i].fuzzyName);
            }
            comboBoxInCost.Items.Add("");
            for (int i = 0; i < model1.inCost.funcs.Count; i++)
            {
                comboBoxInCost.Items.Add(model1.inCost.funcs[i].fuzzyName);
            }
            comboBoxOutService.Items.Add("");
            for (int i = 0; i < model1.outService.funcs.Count; i++)
            {
                comboBoxOutService.Items.Add(model1.outService.funcs[i].fuzzyName);
            }
        }
        private void rules_Load(object sender, EventArgs e)
        {
            fillcombos();
            updateList();
        }
        void updateList()
        {
            dataGridRules.Rows.Clear();

            string[] s = new string[3];
     
            List<fuzzyRule> r = model1.rules;
            for (int i = 0; i < r.Count; i++)
            {
                s[0] = "***"; s[1] = "***"; s[2] = "***";

                List<inRule> list = r[i].inFunc;
                for (int n = 0; n < list.Count; n++)
                {
                    switch (list[n].lingvo.nameLingvo)
                    {
                        case "Оперативность обслуживания": s[0] = list[n].termName;  break;
                        case "Техническая поддержка (консультации)": s[1] = list[n].termName; break;
                        case "Стоимость услуг": s[2] = list[n].termName; break;
                    }
                }
                dataGridRules.Rows.Add(model1.rules[i], "IF", s[0], "AND", s[1], "AND", s[2], "THEN", r[i].outTerm);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridRules.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(this, "Изменить выбранное правило?", "Подтверждение редактирования", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string outTerm = "";
                    List<inRule> inRules = new List<inRule>();
                    if (Convert.ToString(comboBoxOutService.SelectedItem).CompareTo("") != 0)
                    {
                        outTerm = model1.outService.funcs[comboBoxOutService.SelectedIndex - 1].fuzzyName;
                    }
                    if (Convert.ToString(comboBoxInTime.SelectedItem).CompareTo("") != 0)
                    {
                        inRules.Add(new inRule(model1.inTime, model1.inTime.funcs[comboBoxInTime.SelectedIndex - 1].fuzzyName));
                    }
                    if (Convert.ToString(comboBoxInConsult.SelectedItem).CompareTo("") != 0)
                    {
                        inRules.Add(new inRule(model1.inConsult, model1.inConsult.funcs[comboBoxInConsult.SelectedIndex - 1].fuzzyName));
                    }
                    if (Convert.ToString(comboBoxInCost.SelectedItem).CompareTo("") != 0)
                    {
                        inRules.Add(new inRule(model1.inCost, model1.inCost.funcs[comboBoxInCost.SelectedIndex - 1].fuzzyName));
                    }
                    if (outTerm.CompareTo("") != 0 && inRules.Count != 0)
                    {
                        fuzzyRule rule = new fuzzyRule(inRules, 'A', outTerm);
                        model1.rules[dataGridRules.SelectedRows[0].Index] = rule;
                        updateList();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridRules.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(this, "Удалить выбранное правило?", "Подтверждение удаления", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    fuzzyRule rule = (fuzzyRule)dataGridRules.SelectedRows[0].Cells[0].Value;
                    model1.rules.Remove(rule);
                    updateList();
                }
            }
        }
        void addRule()
        {
            string outTerm = "";
            List<inRule> inRules = new List<inRule>();
            if (Convert.ToString(comboBoxOutService.SelectedItem).CompareTo("") != 0)
            {
                outTerm = model1.outService.funcs[comboBoxOutService.SelectedIndex - 1].fuzzyName;
            }
            if (Convert.ToString(comboBoxInTime.SelectedItem).CompareTo("") != 0)
            {
                inRules.Add(new inRule(model1.inTime, model1.inTime.funcs[comboBoxInTime.SelectedIndex - 1].fuzzyName));
            }
            if (Convert.ToString(comboBoxInConsult.SelectedItem).CompareTo("") != 0)
            {
                inRules.Add(new inRule(model1.inConsult, model1.inConsult.funcs[comboBoxInConsult.SelectedIndex - 1].fuzzyName));
            }
            if (Convert.ToString(comboBoxInCost.SelectedItem).CompareTo("") != 0)
            {
                inRules.Add(new inRule(model1.inCost, model1.inCost.funcs[comboBoxInCost.SelectedIndex - 1].fuzzyName));
            }
            if (outTerm.CompareTo("") != 0 && inRules.Count != 0)
            {
                fuzzyRule rule = new fuzzyRule(inRules, 'A', outTerm);
                model1.rules.Add(rule);
                updateList();
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addRule();
        }
        void showRule()
        {
            if (dataGridRules.SelectedRows.Count > 0)
            {
                fuzzyRule rule = (fuzzyRule)dataGridRules.SelectedRows[0].Cells[0].Value;

                comboBoxOutService.SelectedItem = rule.outTerm;
                List<inRule> r = rule.inFunc;
                string[] s = new string[3];
                s[0] = ""; s[1] = ""; s[2] = "";
                for (int i = 0; i < r.Count; i++)
                {
                    switch (r[i].lingvo.nameLingvo)
                    {
                        case "Оперативность обслуживания": s[0] = r[i].termName; break;
                        case "Техническая поддержка (консультации)": s[1] = r[i].termName; break;
                        case "Стоимость услуг": s[2] = r[i].termName; break;
                    }
                }
                comboBoxInTime.SelectedItem = s[0];
                comboBoxInConsult.SelectedItem = s[1];
                comboBoxInCost.SelectedItem = s[2];
            }
        }
        private void dataGridRules_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridRules_SelectionChanged(object sender, EventArgs e)
        {
            showRule();
        }
/*
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < comboBoxInTime.Items.Count; i++)
            {
                comboBoxInTime.SelectedIndex = i;
                for (int j = 1; j < comboBoxInConsult.Items.Count; j++)
                {
                    comboBoxInConsult.SelectedIndex = j;
                    for (int k = 1; k < comboBoxInCost.Items.Count; k++)
                    {
                        comboBoxInCost.SelectedIndex = k;
                        addRule();
                    }
                }
            }
        }*/


    }
}
