namespace z1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbTranslation = new System.Windows.Forms.RadioButton();
            this.rbScale = new System.Windows.Forms.RadioButton();
            this.rbRotation = new System.Windows.Forms.RadioButton();
            this.rbShear = new System.Windows.Forms.RadioButton();
            this.tbTranslationX = new System.Windows.Forms.TextBox();
            this.tbTranslationY = new System.Windows.Forms.TextBox();
            this.tbScaleX = new System.Windows.Forms.TextBox();
            this.tbScaleY = new System.Windows.Forms.TextBox();
            this.tbRotaionAngle = new System.Windows.Forms.TextBox();
            this.tbRotateAtX = new System.Windows.Forms.TextBox();
            this.tbRotateAtY = new System.Windows.Forms.TextBox();
            this.tbShearX = new System.Windows.Forms.TextBox();
            this.tbShearY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelbm = new System.Windows.Forms.Panel();
            this.panelbm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(147, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 483);
            this.panel1.TabIndex = 24;
            // 
            // rbTranslation
            // 
            this.rbTranslation.AutoSize = true;
            this.rbTranslation.Location = new System.Drawing.Point(7, 3);
            this.rbTranslation.Name = "rbTranslation";
            this.rbTranslation.Size = new System.Drawing.Size(110, 17);
            this.rbTranslation.TabIndex = 0;
            this.rbTranslation.TabStop = true;
            this.rbTranslation.Text = "ПЕРЕМЕЩЕНИЕ";
            this.rbTranslation.UseVisualStyleBackColor = true;
            // 
            // rbScale
            // 
            this.rbScale.AutoSize = true;
            this.rbScale.Location = new System.Drawing.Point(7, 78);
            this.rbScale.Name = "rbScale";
            this.rbScale.Size = new System.Drawing.Size(131, 17);
            this.rbScale.TabIndex = 1;
            this.rbScale.TabStop = true;
            this.rbScale.Text = "МАШТАБИРОВАНИЕ";
            this.rbScale.UseVisualStyleBackColor = true;
            // 
            // rbRotation
            // 
            this.rbRotation.AutoSize = true;
            this.rbRotation.Location = new System.Drawing.Point(7, 162);
            this.rbRotation.Name = "rbRotation";
            this.rbRotation.Size = new System.Drawing.Size(78, 17);
            this.rbRotation.TabIndex = 2;
            this.rbRotation.TabStop = true;
            this.rbRotation.Text = "ПОВОРОТ";
            this.rbRotation.UseVisualStyleBackColor = true;
            // 
            // rbShear
            // 
            this.rbShear.AutoSize = true;
            this.rbShear.Location = new System.Drawing.Point(7, 275);
            this.rbShear.Name = "rbShear";
            this.rbShear.Size = new System.Drawing.Size(62, 17);
            this.rbShear.TabIndex = 3;
            this.rbShear.TabStop = true;
            this.rbShear.Text = "СДВИГ";
            this.rbShear.UseVisualStyleBackColor = true;
            // 
            // tbTranslationX
            // 
            this.tbTranslationX.Location = new System.Drawing.Point(71, 26);
            this.tbTranslationX.Name = "tbTranslationX";
            this.tbTranslationX.Size = new System.Drawing.Size(50, 20);
            this.tbTranslationX.TabIndex = 4;
            this.tbTranslationX.Text = "0";
            // 
            // tbTranslationY
            // 
            this.tbTranslationY.Location = new System.Drawing.Point(71, 52);
            this.tbTranslationY.Name = "tbTranslationY";
            this.tbTranslationY.Size = new System.Drawing.Size(50, 20);
            this.tbTranslationY.TabIndex = 5;
            this.tbTranslationY.Text = "0";
            // 
            // tbScaleX
            // 
            this.tbScaleX.Location = new System.Drawing.Point(71, 101);
            this.tbScaleX.Name = "tbScaleX";
            this.tbScaleX.Size = new System.Drawing.Size(50, 20);
            this.tbScaleX.TabIndex = 6;
            this.tbScaleX.Text = "1";
            // 
            // tbScaleY
            // 
            this.tbScaleY.Location = new System.Drawing.Point(71, 136);
            this.tbScaleY.Name = "tbScaleY";
            this.tbScaleY.Size = new System.Drawing.Size(50, 20);
            this.tbScaleY.TabIndex = 7;
            this.tbScaleY.Text = "1";
            // 
            // tbRotaionAngle
            // 
            this.tbRotaionAngle.Location = new System.Drawing.Point(70, 185);
            this.tbRotaionAngle.Name = "tbRotaionAngle";
            this.tbRotaionAngle.Size = new System.Drawing.Size(50, 20);
            this.tbRotaionAngle.TabIndex = 8;
            this.tbRotaionAngle.Text = "0";
            // 
            // tbRotateAtX
            // 
            this.tbRotateAtX.Location = new System.Drawing.Point(71, 211);
            this.tbRotateAtX.Name = "tbRotateAtX";
            this.tbRotateAtX.Size = new System.Drawing.Size(50, 20);
            this.tbRotateAtX.TabIndex = 9;
            this.tbRotateAtX.Text = "0";
            // 
            // tbRotateAtY
            // 
            this.tbRotateAtY.Location = new System.Drawing.Point(71, 247);
            this.tbRotateAtY.Name = "tbRotateAtY";
            this.tbRotateAtY.Size = new System.Drawing.Size(50, 20);
            this.tbRotateAtY.TabIndex = 10;
            this.tbRotateAtY.Text = "0";
            // 
            // tbShearX
            // 
            this.tbShearX.Location = new System.Drawing.Point(71, 298);
            this.tbShearX.Name = "tbShearX";
            this.tbShearX.Size = new System.Drawing.Size(50, 20);
            this.tbShearX.TabIndex = 11;
            this.tbShearX.Text = "0";
            // 
            // tbShearY
            // 
            this.tbShearY.Location = new System.Drawing.Point(70, 330);
            this.tbShearY.Name = "tbShearY";
            this.tbShearY.Size = new System.Drawing.Size(50, 20);
            this.tbShearY.TabIndex = 12;
            this.tbShearY.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(47, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(48, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(47, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(48, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(31, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Угол";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(47, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(48, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(46, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 18);
            this.label8.TabIndex = 20;
            this.label8.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(46, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 18);
            this.label9.TabIndex = 21;
            this.label9.Text = "Y";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(31, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Результат";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 448);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Сброс";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button2_KeyDown);
            // 
            // panelbm
            // 
            this.panelbm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelbm.Controls.Add(this.button2);
            this.panelbm.Controls.Add(this.button1);
            this.panelbm.Controls.Add(this.label9);
            this.panelbm.Controls.Add(this.label8);
            this.panelbm.Controls.Add(this.label7);
            this.panelbm.Controls.Add(this.label6);
            this.panelbm.Controls.Add(this.label5);
            this.panelbm.Controls.Add(this.label4);
            this.panelbm.Controls.Add(this.label3);
            this.panelbm.Controls.Add(this.label2);
            this.panelbm.Controls.Add(this.label1);
            this.panelbm.Controls.Add(this.tbShearY);
            this.panelbm.Controls.Add(this.tbShearX);
            this.panelbm.Controls.Add(this.tbRotateAtY);
            this.panelbm.Controls.Add(this.tbRotateAtX);
            this.panelbm.Controls.Add(this.tbRotaionAngle);
            this.panelbm.Controls.Add(this.tbScaleY);
            this.panelbm.Controls.Add(this.tbScaleX);
            this.panelbm.Controls.Add(this.tbTranslationY);
            this.panelbm.Controls.Add(this.tbTranslationX);
            this.panelbm.Controls.Add(this.rbShear);
            this.panelbm.Controls.Add(this.rbRotation);
            this.panelbm.Controls.Add(this.rbScale);
            this.panelbm.Controls.Add(this.rbTranslation);
            this.panelbm.Location = new System.Drawing.Point(5, 5);
            this.panelbm.Name = "panelbm";
            this.panelbm.Size = new System.Drawing.Size(136, 483);
            this.panelbm.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 500);
            this.Controls.Add(this.panelbm);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelbm.ResumeLayout(false);
            this.panelbm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbTranslation;
        private System.Windows.Forms.RadioButton rbScale;
        private System.Windows.Forms.RadioButton rbRotation;
        private System.Windows.Forms.RadioButton rbShear;
        private System.Windows.Forms.TextBox tbTranslationX;
        private System.Windows.Forms.TextBox tbTranslationY;
        private System.Windows.Forms.TextBox tbScaleX;
        private System.Windows.Forms.TextBox tbScaleY;
        private System.Windows.Forms.TextBox tbRotaionAngle;
        private System.Windows.Forms.TextBox tbRotateAtX;
        private System.Windows.Forms.TextBox tbRotateAtY;
        private System.Windows.Forms.TextBox tbShearX;
        private System.Windows.Forms.TextBox tbShearY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelbm;
    }
}

