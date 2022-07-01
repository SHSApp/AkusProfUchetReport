namespace SHSApp_Profuchet
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isprib = new System.Windows.Forms.CheckBox();
            this.snyatie = new System.Windows.Forms.RadioButton();
            this.postanovka = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.category = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.personal = new System.Windows.Forms.ComboBox();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.go = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.isprib);
            this.groupBox1.Controls.Add(this.snyatie);
            this.groupBox1.Controls.Add(this.postanovka);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.category);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Профилактический учет";
            // 
            // isprib
            // 
            this.isprib.AutoSize = true;
            this.isprib.Location = new System.Drawing.Point(117, 99);
            this.isprib.Name = "isprib";
            this.isprib.Size = new System.Drawing.Size(290, 21);
            this.isprib.TabIndex = 5;
            this.isprib.Text = "По прибытию (для начальника отряда)";
            this.isprib.UseVisualStyleBackColor = true;
            // 
            // snyatie
            // 
            this.snyatie.AutoSize = true;
            this.snyatie.Location = new System.Drawing.Point(276, 72);
            this.snyatie.Name = "snyatie";
            this.snyatie.Size = new System.Drawing.Size(77, 21);
            this.snyatie.TabIndex = 4;
            this.snyatie.Text = "Снятие";
            this.snyatie.UseVisualStyleBackColor = true;
            // 
            // postanovka
            // 
            this.postanovka.AutoSize = true;
            this.postanovka.Checked = true;
            this.postanovka.Location = new System.Drawing.Point(117, 72);
            this.postanovka.Name = "postanovka";
            this.postanovka.Size = new System.Drawing.Size(107, 21);
            this.postanovka.TabIndex = 3;
            this.postanovka.TabStop = true;
            this.postanovka.Text = "Постановка";
            this.postanovka.UseVisualStyleBackColor = true;
            this.postanovka.CheckedChanged += new System.EventHandler(this.postanovka_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тип рапорта";
            // 
            // category
            // 
            this.category.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.category.DropDownHeight = 206;
            this.category.DropDownWidth = 626;
            this.category.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.category.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.category.FormattingEnabled = true;
            this.category.IntegralHeight = false;
            this.category.Location = new System.Drawing.Point(12, 38);
            this.category.MaxDropDownItems = 16;
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(446, 27);
            this.category.TabIndex = 1;
            this.category.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cb_DrawItem);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Категория профилактическго учета";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.personal);
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 76);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Инициатор";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сотрудник от которого составляется рапорт";
            // 
            // personal
            // 
            this.personal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.personal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.personal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.personal.FormattingEnabled = true;
            this.personal.Location = new System.Drawing.Point(9, 40);
            this.personal.Name = "personal";
            this.personal.Size = new System.Drawing.Size(449, 27);
            this.personal.TabIndex = 0;
            this.personal.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cb_DrawItem);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(12, 233);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(384, 27);
            this.pb.TabIndex = 2;
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(411, 229);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(68, 35);
            this.go.TabIndex = 3;
            this.go.Text = "GO";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 272);
            this.Controls.Add(this.go);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рапорт на профучет - SHSApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox personal;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.CheckBox isprib;
        private System.Windows.Forms.RadioButton snyatie;
        private System.Windows.Forms.RadioButton postanovka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox category;
        private System.Windows.Forms.Label label2;
    }
}

