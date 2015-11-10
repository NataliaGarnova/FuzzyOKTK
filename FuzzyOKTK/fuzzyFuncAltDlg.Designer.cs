namespace FuzzyOKTK
{
    partial class fuzzyFuncAltDlg
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fuzzyFuncAltDlg));
            this.textBoxParams = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.panelFuzzy = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.trackA = new System.Windows.Forms.TrackBar();
            this.trackB = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackC = new System.Windows.Forms.TrackBar();
            this.trackD = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxU = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridTerms = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddTerm = new System.Windows.Forms.Button();
            this.buttonDelTerm = new System.Windows.Forms.Button();
            this.buttonEditTerm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTerms)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxParams
            // 
            this.textBoxParams.Location = new System.Drawing.Point(6, 249);
            this.textBoxParams.Name = "textBoxParams";
            this.textBoxParams.ReadOnly = true;
            this.textBoxParams.Size = new System.Drawing.Size(263, 20);
            this.textBoxParams.TabIndex = 13;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(273, 185);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(156, 20);
            this.textBoxName.TabIndex = 12;
            // 
            // panelFuzzy
            // 
            this.panelFuzzy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelFuzzy.Location = new System.Drawing.Point(6, 12);
            this.panelFuzzy.Name = "panelFuzzy";
            this.panelFuzzy.Size = new System.Drawing.Size(263, 231);
            this.panelFuzzy.TabIndex = 11;
            this.panelFuzzy.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFuzzy_Paint);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(139, 273);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(130, 27);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Закрыть";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboType
            // 
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "Линейная Z",
            "Линейная Сплайн",
            "Треугольная",
            "Трапецевидная"});
            this.comboType.Location = new System.Drawing.Point(273, 214);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(156, 21);
            this.comboType.TabIndex = 16;
            this.comboType.Text = "Трапецевидная";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.trackA, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.trackB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.trackC, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.trackD, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(435, 183);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(152, 117);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // trackA
            // 
            this.trackA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackA.AutoSize = false;
            this.trackA.Location = new System.Drawing.Point(25, 4);
            this.trackA.Maximum = 1000;
            this.trackA.Name = "trackA";
            this.trackA.Size = new System.Drawing.Size(124, 21);
            this.trackA.TabIndex = 0;
            this.trackA.TickFrequency = 40;
            this.trackA.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackA.Value = 5;
            this.trackA.Scroll += new System.EventHandler(this.trackA_Scroll);
            // 
            // trackB
            // 
            this.trackB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackB.AutoSize = false;
            this.trackB.Location = new System.Drawing.Point(25, 33);
            this.trackB.Maximum = 1000;
            this.trackB.Name = "trackB";
            this.trackB.Size = new System.Drawing.Size(124, 21);
            this.trackB.TabIndex = 4;
            this.trackB.TickFrequency = 40;
            this.trackB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackB.Value = 5;
            this.trackB.Scroll += new System.EventHandler(this.trackB_Scroll);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "B";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "C";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "D";
            // 
            // trackC
            // 
            this.trackC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackC.AutoSize = false;
            this.trackC.Location = new System.Drawing.Point(25, 62);
            this.trackC.Maximum = 1000;
            this.trackC.Name = "trackC";
            this.trackC.Size = new System.Drawing.Size(124, 21);
            this.trackC.TabIndex = 5;
            this.trackC.TickFrequency = 40;
            this.trackC.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackC.Value = 5;
            this.trackC.Scroll += new System.EventHandler(this.trackC_Scroll);
            // 
            // trackD
            // 
            this.trackD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.trackD.AutoSize = false;
            this.trackD.Location = new System.Drawing.Point(25, 91);
            this.trackD.Maximum = 1000;
            this.trackD.Name = "trackD";
            this.trackD.Size = new System.Drawing.Size(124, 21);
            this.trackD.TabIndex = 6;
            this.trackD.TickFrequency = 40;
            this.trackD.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackD.Value = 5;
            this.trackD.Scroll += new System.EventHandler(this.trackD_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A";
            // 
            // textBoxU
            // 
            this.textBoxU.Location = new System.Drawing.Point(293, 244);
            this.textBoxU.Name = "textBoxU";
            this.textBoxU.ReadOnly = true;
            this.textBoxU.Size = new System.Drawing.Size(136, 20);
            this.textBoxU.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(274, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "U";
            // 
            // dataGridTerms
            // 
            this.dataGridTerms.AllowUserToAddRows = false;
            this.dataGridTerms.AllowUserToDeleteRows = false;
            this.dataGridTerms.AllowUserToResizeColumns = false;
            this.dataGridTerms.AllowUserToResizeRows = false;
            this.dataGridTerms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTerms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridTerms.Location = new System.Drawing.Point(273, 12);
            this.dataGridTerms.MultiSelect = false;
            this.dataGridTerms.Name = "dataGridTerms";
            this.dataGridTerms.ReadOnly = true;
            this.dataGridTerms.RowHeadersVisible = false;
            this.dataGridTerms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTerms.Size = new System.Drawing.Size(314, 166);
            this.dataGridTerms.TabIndex = 20;
            this.dataGridTerms.SelectionChanged += new System.EventHandler(this.dataGridTerms_SelectionChanged);
            this.dataGridTerms.Click += new System.EventHandler(this.dataGridTerms_Click);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Имя терма";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Тип функции принадлежности";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Параметры";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // buttonAddTerm
            // 
            this.buttonAddTerm.Location = new System.Drawing.Point(360, 276);
            this.buttonAddTerm.Name = "buttonAddTerm";
            this.buttonAddTerm.Size = new System.Drawing.Size(22, 23);
            this.buttonAddTerm.TabIndex = 21;
            this.buttonAddTerm.Text = "+";
            this.buttonAddTerm.UseVisualStyleBackColor = true;
            this.buttonAddTerm.Click += new System.EventHandler(this.buttonAddTerm_Click);
            // 
            // buttonDelTerm
            // 
            this.buttonDelTerm.Location = new System.Drawing.Point(408, 276);
            this.buttonDelTerm.Name = "buttonDelTerm";
            this.buttonDelTerm.Size = new System.Drawing.Size(22, 23);
            this.buttonDelTerm.TabIndex = 22;
            this.buttonDelTerm.Text = "-";
            this.buttonDelTerm.UseVisualStyleBackColor = true;
            this.buttonDelTerm.Click += new System.EventHandler(this.buttonDelTerm_Click);
            // 
            // buttonEditTerm
            // 
            this.buttonEditTerm.Location = new System.Drawing.Point(273, 273);
            this.buttonEditTerm.Name = "buttonEditTerm";
            this.buttonEditTerm.Size = new System.Drawing.Size(85, 28);
            this.buttonEditTerm.TabIndex = 23;
            this.buttonEditTerm.Text = "изменить тип";
            this.buttonEditTerm.UseVisualStyleBackColor = true;
            this.buttonEditTerm.Click += new System.EventHandler(this.buttonEditTerm_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 27);
            this.button1.TabIndex = 24;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(384, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "E";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fuzzyFuncAltDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 308);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonEditTerm);
            this.Controls.Add(this.buttonDelTerm);
            this.Controls.Add(this.buttonAddTerm);
            this.Controls.Add(this.dataGridTerms);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxU);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxParams);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.panelFuzzy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fuzzyFuncAltDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор: Лингвистическая переменная";
            this.Load += new System.EventHandler(this.fuzzyFuncDlg_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTerms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxParams;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Panel panelFuzzy;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxU;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridTerms;
        private System.Windows.Forms.Button buttonAddTerm;
        private System.Windows.Forms.Button buttonDelTerm;
        private System.Windows.Forms.Button buttonEditTerm;
        private System.Windows.Forms.TrackBar trackA;
        private System.Windows.Forms.TrackBar trackB;
        private System.Windows.Forms.TrackBar trackD;
        private System.Windows.Forms.TrackBar trackC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}